using Pizzaria_v1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizzaria_v1._0.Models
{
    public class EmpresaDAO
    {
        private static Entities entities = Singleton.Instance.Entities;
        public static bool CadastrarEmpresa(Empresa empresa)
        {
            try
            {
                entities.Empresas.Add(empresa);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public static Empresa BuscarEmpresaPorLogin(Empresa empresa)
        {
            return entities.Empresas.FirstOrDefault(x => x.Login.Equals(empresa.Login));
        }

        public static Empresa BuscarEmpresaPorLoginSenha(Empresa empresa)
        {
            return entities.Empresas.FirstOrDefault(x => x.Login.Equals(empresa.Login) && x.Senha.Equals(empresa.Senha));
        }

        public static Empresa BuscarEmpresaPorId(int idEmpresa)
        {
            return entities.Empresas.Find(idEmpresa);
        }

        public static bool AtualizarEmpresa(Empresa empresa)
        {
            try
            {
                entities.Entry(empresa).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RemoverEmpresa(Empresa empresa)
        {
            try
            {
                entities.Empresas.Remove(empresa);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string RetornarEmpresaId()
        {
            string idEmpresa;

            if (HttpContext.Current.Session["sessionEmpresaId"] == null)
            {
                idEmpresa = "0";
            }
            else
            {
                idEmpresa = HttpContext.Current.Session["sessionEmpresaId"].ToString();
            }

            return idEmpresa;
        }

        public static Empresa BuscarEmpresaComoCategoria(Empresa empresa, Pedido pedido)
        {
            return entities.Empresas.FirstOrDefault(x => x.Nome.Equals(pedido.Empresa));
        }
    }
}