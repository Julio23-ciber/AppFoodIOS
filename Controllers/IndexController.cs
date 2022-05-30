using AppFoodIOS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
 

namespace AppFoodIOS.Controllers
{
    public class IndexController : ApiController
    {
        private SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["proyecto"].ConnectionString);


        // GET: Cantidad de Resetas
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Index/GetCantResetas")]
        public int GetCantResetas(){
            int cantRest = -1;
            try
            {
                using (cn)
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("select COUNT(1) from receta", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cantRest = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


         
            return cantRest;
        }
        // GET: CantUsuarios
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Index/GetCantUsuario")]
        public int GetCantUsuario()
        {
            int cantUsers = -1;
            using (cn)
            {
                cn.Open();
                using (var cmd = new SqlCommand("select COUNT(1) from usuario", cn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cantUsers = (int)cmd.ExecuteScalar();
                }
            }
            {
                
            }
            return cantUsers;
        }
        // GET: CantCategorias
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Index/GetCantCategorias")]
        public int GetCantCategorias()
        {
            int cantCategoria = -1;
            using (cn)
            {
                cn.Open();
                using (var cmd = new SqlCommand("select COUNT(1) from categoria", cn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cantCategoria = (int)cmd.ExecuteScalar();
                }
            }
      

 
            return cantCategoria;
        }
        // GET: CantCocinas
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Index/GetCantCocinas")]
        public int GetCantCocinas()
        {
            

            int cantCocinas = -1;
            using (cn)
            {
                cn.Open();
                using (var cmd = new SqlCommand("select COUNT(1) from cocina", cn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cantCocinas = (int)cmd.ExecuteScalar();
                }
            }
           
            return cantCocinas;
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Index/GetMostLikedRecetas")]
        public List<dynamic> GetMostLikedRecetas()
        {
            /**
             * Pruebas de la funcion
             */
            var lista = new List<dynamic>();            
            using (cn)
            {
                cn.Open();
                using (var cmd = new SqlCommand("select top 5 * from receta order by nro_likes desc", cn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var receta = new
                            {
                                nombre = dr["nombre"],
                                likes = dr["nro_likes"],
                             
                            };
                            lista.Add(receta);
                        }
                        return lista;
                    }
                }
            }
               
        }
        
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Index/GetMostActiveUsers")]
        public List<dynamic> GetMostActiveUsers()
        {
            var lista = new List<dynamic>();
            using (cn)
            {
                cn.Open();
                using (var cmd = new SqlCommand("select top 5 u.nombre, COUNT(r.id) as cant from usuario u join receta r on u.id = r.userid group by u.nombre order by u.nombre desc", cn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var usuario = new
                            {
                                nombre = dr["nombre"],
                                id = dr["cant"],

                            };
                            lista.Add(usuario);
                        }
                        return lista;
                    }
                }
            }
 
        }



    }
}