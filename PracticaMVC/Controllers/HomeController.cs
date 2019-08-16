using PracticaMVC.Metodos;
using PracticaMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;

namespace PracticaMVC.Controllers
{
    public class HomeController : Controller
    {
        //Listar Usuarios
        public ActionResult Index()
        {
            List<ClienteEntity> lst = new List<ClienteEntity>();
            using (PracticaMVCEntities1 db = new PracticaMVCEntities1())
            {
                 lst = (from c in db.Cliente
                           select new PracticaMVC.Models.ClienteEntity
                           {
                               nombreCliente = c.nombreCliente
                           }).ToList();
                          
            }

            #region[Dapper]
            PracticaMVCEntities1 db2 = new PracticaMVCEntities1();
            List<ClienteEntity> lstD = new List<ClienteEntity>();

            var conn = ConfigurationManager.ConnectionStrings["PracticaMVCEntities"].ConnectionString;

            using (IDbConnection db = new SqlConnection(conn))
            {
                lstD = db.Query<ClienteEntity>
                ("Select * From Cliente").ToList();
            }
            #endregion

            return View(lst);
        }
        //Litar Profesiones
        public ActionResult About()
        {
            List<ProfesionEntity> lstP = new List<ProfesionEntity>();
            using (PracticaMVCEntities1 db = new PracticaMVCEntities1())
            {
                lstP = (from p in db.Profesion 
                       
                        
                        select new PracticaMVC.Models.ProfesionEntity
                        {
                            nombreProfesion = p.nombreProfesion,
                            descripcion = p.descripcion,
                            idProfesion = p.idProfesion

                        }

                    ).ToList();

            }

            return View(lstP);
        }
        //Listar profesionesXCliente 
       
        public ActionResult ProfesionXCliente(int idProfesion)
        {
            ClienteB cCliente = new ClienteB();
            List<ClienteEntity> lstClienteXProf = cCliente.ListarClienteXProfesion(idProfesion);


            int m = 0;
            int h = 0;
            foreach (var item in lstClienteXProf)
            {
                if (item.genero == "1")
                {
                    m++;
                }
                if (item.genero == "0")
                {
                    h++;
                }

            }

            ViewBag.TotalMujeres = m;
            ViewBag.TotalHombres = h;
            return View(lstClienteXProf);
        }

        public ActionResult Contact()
        {
            //Class1 cl = new Class1();
            //cl.intan();
            ViewBag.Message = "Your contact page.";

            return View();
        }

      
    }
}