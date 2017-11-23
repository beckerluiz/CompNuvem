using Pizzaria_v1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizzaria_v1._0.DAL
{
    public class PedidoDAO
    {
        private static Entities entities = Singleton.Instance.Entities;
        public static List<Pedido> ListarPedidos()
        {
            return entities.Pedidos.ToList();
        }

        public static bool CadastrarPedido(Pedido pedido)
        {
            try
            {
                if (BuscarPedidoPorSabor(pedido) == null)
                {
                    entities.Pedidos.Add(pedido);
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

        public static Pedido BuscarPedidoPorSabor(Pedido pedido)
        {
            return entities.Pedidos.FirstOrDefault(x => x.Sabor.Equals(pedido.Sabor));
        }

        public static Pedido BuscarPedidoPorId(int idPedido)
        {
            return entities.Pedidos.Find(idPedido);
        }

        public static List<Pedido> BuscarPedidoPorCategoria(int idCategoria)
        {
            return entities.Pedidos.Where(x => x.Categoria.CategoriaId == idCategoria).ToList();
        }

        public static bool AtualizarPedido(Pedido pedido)
        {
            try
            {
                entities.Entry(pedido).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RemoverPedido(Pedido pedido)
        {
            try
            {
                entities.Pedidos.Remove(pedido);
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