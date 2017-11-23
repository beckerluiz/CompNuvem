using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pizzaria_v1._0.Models;
using System.Web.Security;

namespace Pizzaria_v1._0.Controllers
{
    public class EmpresaController : Controller
    {
        private Entities db = new Entities();

        public const string LOGIN_ACTION = "Home";
        public const string LOGIN_CONTROLLER = "Home";

        // GET: Empresa
        public ActionResult Index()
        {
            return View(db.Empresas.ToList());
        }

        // GET: Empresa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpresaId,Login,Senha,Nome,Cnpj,Endereco,Telefone")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Empresas.Add(empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empresa);
        }

        // GET: Empresa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpresaId,Login,Senha,Nome,Cnpj,Endereco,Telefone")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empresa);
        }

        // GET: Empresa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empresa empresa = db.Empresas.Find(id);
            db.Empresas.Remove(empresa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Login, Senha")]Empresa empresaSession)
        {

            Empresa empresa = EmpresaDAO.BuscarEmpresaPorLoginSenha(empresaSession);

            Boolean isNotLoggedIn = System.Web.HttpContext.Current.Session["sessionEmpresaId"] == null
                || string.IsNullOrWhiteSpace(System.Web.HttpContext.Current.Session["sessionEmpresaId"].ToString());

            // Valida se o usuário já está logado
            if (isNotLoggedIn)
            {
                if (empresa != null)
                {
                    //Autenticar
                    FormsAuthentication.SetAuthCookie(empresa.Login, false);

                    // Para recuperar no ListarPedidos
                    System.Web.HttpContext.Current.Session["sessionEmpresaId"] = empresa.EmpresaId;

                    return RedirectToAction("ListaPedidos", "Empresa");
                }
                else
                {
                    ModelState.AddModelError("", "Login ou Senha não coincidem");
                    return View();
                }
            }
            return View();
        }

        public string getLoginAction(HttpContextBase context)
        {
            string loginAction = LOGIN_ACTION;

            if (context.Session["sessionLoginAction"] != null)
            {
                loginAction = context.Session["sessionLoginAction"].ToString();
            }

            return loginAction;
        }

        public string getLoginController(HttpContextBase context)
        {
            string loginController = LOGIN_CONTROLLER;

            if (context.Session["sessionLoginController"] != null)
            {
                loginController = context.Session["sessionLoginController"].ToString();
            }

            return loginController;
        }

        public ActionResult Logout()
        {
            Session.Remove("sessionEmpresaId");
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult ListaPedidos()
        {
            int? empresaId = (int?)Session["sessionEmpresaId"];
            if (!empresaId.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(db.Pedidos.Where(x => x.EmpresaId == empresaId));
        }
    }
}


