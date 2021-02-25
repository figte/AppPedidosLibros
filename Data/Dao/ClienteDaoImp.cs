using Data.Data;
using Data.Idao;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data.Dao
{
    public class ClienteDaoImp : IClienteDao
    {
        Conexion conn;

        public ClienteDaoImp() {
            conn = new Conexion();
        }

        public Cliente create(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public bool delete(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> getAll()
        {

            List<Cliente> items = new List<Cliente>();

            //conectandome a la base de datos
            conn.conectar();

            string select = "select * from [dbo].[clientes]";

            using (var conexion=conn.getConexion()) {

                conexion.Open();
                using (var tran = conexion.BeginTransaction()) {

                    using (var command = new SqlCommand(select,conexion,tran)) {
                        try
                        {
                            SqlDataReader rdr = command.ExecuteReader();
                            while (rdr.Read())
                            {
                                var item = new Cliente();
                                item.Id = int.Parse( rdr["id"].ToString());
                                item.Nombre =(string) rdr["nombre"];
                                item.Apellidos = (string)rdr["apellidos"];
                                item.FechaNacimiento = (DateTime) rdr["fecha_nacimiento"];
                                item.Direccion = (string) rdr["direccion"];
                                item.Telefono = (string)rdr["telefono"];
                                item.Email = (string)rdr["email"];

                                items.Add(item);
                            }

                            rdr.Close();
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

            return items;
        }

        public Cliente getById(int id)
        {
            Cliente item = new Cliente();

            //conectandome a la base de datos
            conn.conectar();

            string select = "select * from [dbo].[clientes] where id = @Id ";


            using (var conexion = conn.getConexion())
            {

                conexion.Open();
                using (var tran = conexion.BeginTransaction())
                {

                    using (var command = new SqlCommand(select, conexion, tran))
                    {
                        try
                        {

                            command.Parameters.Add("@Id", SqlDbType.NVarChar);
                            command.Parameters["@Id"].Value = id;

                            SqlDataReader rdr = command.ExecuteReader();
                            while (rdr.Read())
                            {
                               
                                item.Id = int.Parse(rdr["id"].ToString());
                                item.Nombre = (string)rdr["nombre"];
                                item.Apellidos = (string)rdr["apellidos"];
                                item.FechaNacimiento = (DateTime)rdr["fecha_nacimiento"];
                                item.Direccion = (string)rdr["direccion"];
                                item.Telefono = (string)rdr["telefono"];
                                item.Email = (string)rdr["email"];

                               
                            }

                            rdr.Close();
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
            return item;
        }

        public bool update(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
