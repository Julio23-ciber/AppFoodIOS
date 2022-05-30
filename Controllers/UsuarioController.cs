using AppFoodIOS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppFoodIOS.Controllers
{
    public class UsuarioController : ApiController
    {
        //conexion bd
        private SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["proyecto"].ConnectionString);

        [Route("api/Usuario/ListarUsuario")]
        [HttpGet]
        public List<Usuario> ListarUsuario()
        {
            List<Usuario> lista = new List<Usuario>();
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["proyecto"].ConnectionString))
            {
                cn.Open();
                using (var cmd = new SqlCommand("usp_listarUsuario", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            Usuario u = new Usuario()
                            {
                                id = (dr["id"] == DBNull.Value) ? -1 : (int)dr["id"],
                                img = (dr["img"] == DBNull.Value) ? "" : (string)dr[1],
                                nombre = (dr["nombre"] == DBNull.Value) ? "" : (string)dr[2],
                                email = (dr["email"] == DBNull.Value) ? "" : (string)dr[3],
                                tipo_usuario = (dr["tipo_usuario"] == DBNull.Value) ? -1 : (int)dr[4],
                                cantRecetas = (dr["cantRecetas"] == DBNull.Value) ? -1 : (int)dr[5],
                                estado = (dr["estado"] == DBNull.Value) ? -1 : (int)dr[6],
                            };
                            lista.Add(u);
                        }

                    }

                }
            }
            return lista;

        }

        [Route("api/Usuario/GuardarImgUser")]
        [HttpPost]
        public HttpResponseMessage GuardarImgUser(HttpPostedFileBase fileUpload, int idUser)
        {
            return null;
        }

        [Route("api/Usuario/MostarImagenUsuario")]
        [HttpGet]
        public HttpResponseMessage MostarImagenUsuario()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "/App_Data/Upload/1_0000001.png");
            byte[] b = File.ReadAllBytes(path);
            MemoryStream ms = new MemoryStream(b);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType = new
            System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
            //send response of image/png type
            return response;

        }
    }
}
