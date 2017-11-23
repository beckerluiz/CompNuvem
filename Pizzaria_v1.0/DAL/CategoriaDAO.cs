using Pizzaria_v1._0.DAL;
using Pizzaria_v1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizzaria_v1._0.DAL
{
    public class CategoriaDAO
    {
        private static Entities entities = Singleton.Instance.Entities;
        public static List<Categoria> RetornarCategorias()
        {
            return entities.Categorias.ToList();
        }

        public static bool CadastrarCategoria(Categoria categoria)
        {
            try
            {
                if (BuscarCategoriaPorNome(categoria) == null)
                {
                    entities.Categorias.Add(categoria);
                    entities.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Categoria BuscarCategoriaPorNome(Categoria categoria)
        {
            return entities.Categorias.FirstOrDefault(x => x.CategoriaNome.Equals(categoria.CategoriaNome));
        }

        public static Categoria BuscarCategoriaPorId(int idCategoria)
        {
            return entities.Categorias.Find(idCategoria);
        }

        public static bool AtualizarCategoria(Categoria categoria)
        {
            try
            {
                entities.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RemoverCategoria(Categoria categoria)
        {
            try
            {
                entities.Categorias.Remove(categoria);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}