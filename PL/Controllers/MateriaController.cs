using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {        
       
        ////Inyeccion de dependencias-- patron de diseño
        //private readonly Configuration _configuration;
        //private readonly HostingEnvironment _hostingEnvironment;

        //public MateriaController(Configuration configuration, HostingEnvironment hostingEnvironment)
        //{
        //    _configuration = configuration;
        //    _hostingEnvironment = hostingEnvironment;
        //}

        [HttpGet]      
        public ActionResult GetAll()
        {
            ML.Materias materias = new ML.Materias();
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            try
            {
                using (var client = new HttpClient())
                {
                    string urlApi = ConfigurationManager.AppSettings["urlApi"];
                    client.BaseAddress = new Uri(urlApi);
                    
                    var responseTask = client.GetAsync("Materias/GetAll");
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var item in readTask.Result.Objects)
                        {
                            ML.Materias resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materias>(item.ToString());
                            result.Objects.Add(resultItemList);
                        }
                    }
                    materias.ListMaterias = result.Objects;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error al mostrar los datos: " + ex.Message;
                return PartialView("Modal");
                throw;
            }
            return View(materias);
        }//GetAll

        [HttpGet]
        public ActionResult Form(int? IdMateria)
        {
            ML.Materias materia = new ML.Materias();

            if (IdMateria == null)
            {
                //Add Form Vacio
                return View(materia);
            }
            else
            {
                ML.Result result = new ML.Result();
                result.Object = new object();
                using (var client = new HttpClient())
                {
                    string url = ConfigurationManager.AppSettings["urlApi"];
                    client.BaseAddress = new Uri(url);

                    var responseTask = client.GetAsync("Materias/GetById?IdMateria=" +  IdMateria);
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        var resultItem = readTask.Result.Object;

                        ML.Materias materiaItem = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materias>(resultItem.ToString());
                        result.Object = materiaItem;
                        result.Correct = true;
                    }
                }
                if (result.Correct)
                {
                    materia = (ML.Materias)result.Object;

                    //Update
                    return View(materia);
                }
                else
                {
                    ViewBag.Message = "Error al mostrar la información";
                    return PartialView("Modal");
                }
            }
        }//Form(get)

        [HttpPost]
        public ActionResult Form(ML.Materias materia)
        {
            string url = ConfigurationManager.AppSettings["urlApi"];
            //Add
            if (materia.IdMateria == 0)
            {
                using (var client = new HttpClient())
                {
                    
                    client.BaseAddress = new Uri(url);
                    //HTTP POST
                    var postTask = client.PostAsJsonAsync("Materias/Add", materia);
                    postTask.Wait();

                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se ha registrado la materia correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "Error al registrar la materia";
                    }
                    return PartialView("Modal");
                }
            }//if

            //Update
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync("Materias/Update", materia);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se ha actualizado la información del registro correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "Ha ocurrido un error";
                    }
                    return PartialView("Modal");
                }
            }
        }//Form(post)

        [HttpGet]
        public ActionResult Delete(int IdMateria)
        {
            string url = ConfigurationManager.AppSettings["urlApi"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                //HttpPOST
                var deleteTask = client.PostAsync("Materias/Delete?IdMateria=" + IdMateria, null);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Registro eliminado";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Error al eliminar";
                    return PartialView("Modal");
                }
            }
        }//Delete
    }//Controller
}//NS