using DataPedidos.Data;
using DataPedidos.IDao;
using DataPedidos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataPedidos.Dao
{
    public class PedidoDaoImp : IPedidoDao
    {

        Conexion conn;
        public PedidoDaoImp() {
            conn = new Conexion();
        }


        public Pedido create(Pedido pedido)
        {

            Pedido item = new Pedido();

            //conectandome a la base de datos
            conn.conectar();

          
            string sql = "Insert into pedidos(id_cliente,id_book,book_title,book_author,publisher) "
               + " output INSERTED.id, INSERTED.id_cliente, INSERTED.id_book, INSERTED.book_title, INSERTED.book_author, INSERTED.publisher "
                + " values ('" + pedido.IdCliente + "','" + pedido.IdBook + "','" + pedido.BookTitle + "','" + pedido.BookAuthor + "','" + pedido.Publisher +  "') ";


            using (var conexion = conn.getConexion())
            {

                conexion.Open();

                using (var tran = conexion.BeginTransaction())
                {

                    using (var command = new SqlCommand(sql, conexion, tran))
                    {
                        try
                        {
                            try
                            {

                                //int r= command.ExecuteNonQuery();


                                SqlDataReader rdr = command.ExecuteReader();

                                while (rdr.Read())
                                {

                                    item.Id = (int) rdr["id"];
                                    item.IdCliente = (int)rdr["id_cliente"];
                                    item.IdBook = (int) rdr["id_book"];
                                    item.BookTitle = (string) rdr["book_title"];
                                    item.BookAuthor = (string)rdr["book_author"];
                                    item.Publisher = (string)rdr["publisher"];
                                 

                                }

                                rdr.Close();

                                tran.Commit();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("error: " + e.Message);
                            }


                        }
                        catch (Exception ex)
                        {
                            conexion.Close();
                            string msg = ex.Message.ToString();
                            Console.WriteLine("error: " + ex.Message);
                            tran.Rollback();
                            throw;
                        }

                    }

                }
            }

            conn.desconectar(); //cerrando conexion y quitando valor de la cadena

            return item;
        }

        public bool delete(Pedido pedido)
        {

            //conectandome a la base de datos
            conn.conectar();

            string sql = "delete from [dbo].[pedidos] where id = @Id ";

            try
            {
                using (var conexion = conn.getConexion())
                {

                    conexion.Open();
                    using (var tran = conexion.BeginTransaction())
                    {

                        using (var command = new SqlCommand(sql, conexion, tran))
                        {
                            try
                            {

                                command.Parameters.Add("@Id", SqlDbType.NVarChar);
                                command.Parameters["@Id"].Value = pedido.Id;

                                command.ExecuteNonQuery();

                                tran.Commit();

                            }
                            catch (Exception ex)
                            {
                                conexion.Close();
                                string msg = ex.Message.ToString();
                                tran.Rollback();
                                throw;
                            }

                        }

                    }
                }

                conn.desconectar(); //cerrando conexion y quitando valor de la cadena
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Pedido> getAll()
        {

           List<Pedido> items = new List<Pedido>();

            //conectandome a la base de datos
            conn.conectar();


            string sql = "select * from pedidos";

            using (var conexion = conn.getConexion())
            {

                conexion.Open();

                using (var tran = conexion.BeginTransaction())
                {

                    using (var command = new SqlCommand(sql, conexion, tran))
                    {
                        try
                        {
                            try
                            {

                                //int r= command.ExecuteNonQuery();


                                SqlDataReader rdr = command.ExecuteReader();

                                while (rdr.Read())
                                {
                                    Pedido item = new Pedido();
                                    item.Id = (int)rdr["id"];
                                    item.IdCliente = (int)rdr["id_cliente"];
                                    item.IdBook = (int)rdr["id_book"];
                                    item.BookTitle = (string)rdr["book_title"];
                                    item.BookAuthor = (string)rdr["book_author"];
                                    item.Publisher = (string)rdr["publisher"];

                                    items.Add(item);
                                }

                                rdr.Close();

                                tran.Commit();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("error: " + e.Message);
                            }


                        }
                        catch (Exception ex)
                        {
                            conexion.Close();
                            string msg = ex.Message.ToString();
                            Console.WriteLine("error: " + ex.Message);
                            tran.Rollback();
                            throw;
                        }

                    }

                }
            }

            conn.desconectar(); //cerrando conexion y quitando valor de la cadena

            return items;
        }

        public Pedido getById(int id)
        {

            return null;
        }

        public bool update(Pedido pedido)
        {
            //conectandome a la base de datos
            conn.conectar();
           
            string sql = "update  [dbo].[pedidos] " +
                "set id_cliente= '" + pedido.IdCliente + "'," +
                "id_book= '" + pedido.IdBook + "'," +
                "book_title='" + pedido.BookTitle + "'," +
                "book_author='" + pedido.BookAuthor + "'," +
                "publisher='" + pedido.Publisher + "' " +
                " where id = " + pedido.Id;

            try
            {
                using (var conexion = conn.getConexion())
                {

                    conexion.Open();
                    using (var tran = conexion.BeginTransaction())
                    {

                        using (var command = new SqlCommand(sql, conexion, tran))
                        {
                            try
                            {


                                command.ExecuteNonQuery();

                                tran.Commit();

                            }
                            catch (Exception ex)
                            {
                                conexion.Close();
                                string msg = ex.Message.ToString();
                                tran.Rollback();
                                throw;
                            }

                        }

                    }
                }

                conn.desconectar(); //cerrando conexion y quitando valor de la cadena
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
