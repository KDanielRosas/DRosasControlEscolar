using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            var serv = new AlumnoServicios.AlumnoServiceClient();

            var list = serv.GetAll();            

            ML.Result result = new ML.Result();
            result.Objects = new List<object>();

            foreach (var item in list)
            {
                ML.Alumnos alumno = new ML.Alumnos();
                alumno.IdAlumno = item.IdAlumno;
                alumno.Nombre = item.Nombre;
                alumno.ApellidoPaterno = item.ApellidoPaterno;
                alumno.ApellidoMaterno = item.ApellidoMaterno;

                result.Objects.Add(alumno);
            }

            return View(result);
        }//GetAll

        public ML.Alumnos GetById(int idAlumno)
        {
            var serv = new AlumnoServicios.AlumnoServiceClient();

            var obj = serv.GetById(idAlumno);
            ML.Alumnos alumno = new ML.Alumnos();
            alumno.IdAlumno = obj.IdAlumno;
            alumno.Nombre = obj.Nombre;
            alumno.ApellidoPaterno = obj.ApellidoPaterno;
            alumno.ApellidoMaterno = obj.ApellidoMaterno;

            return alumno;
        }//GetById

        [HttpGet]
        public ActionResult Form(int? idAlumno)
        {
            ML.Alumnos alumno = new ML.Alumnos();
            if (idAlumno == null)
            {
                //Add Formulario vacio
                return View(alumno);
            }
            else
            {
                //GetById
                alumno = GetById(idAlumno.Value);
                if (alumno != null)
                {
                    return View(alumno);
                }
                else
                {
                    ViewBag.Message = "Error al mostrar la información del alumno";
                    return PartialView("Modal");
                }
            }
        }//Form(get)

        [HttpPost]
        public ActionResult Form(ML.Alumnos alumno)
        {
            if (alumno.IdAlumno == 0)
            {
                //Add
                var obj = new SL_WCF.Alumno
                {
                    Nombre = alumno.Nombre,
                    ApellidoPaterno = alumno.ApellidoPaterno,
                    ApellidoMaterno = alumno.ApellidoMaterno
                };

                var serv = new AlumnoServicios.AlumnoServiceClient();
                var resultado = serv.Add(obj);

                if (resultado) { ViewBag.Message = "Se registró correctamente"; }
                else { ViewBag.Message = "Error al registrar."; }

                return PartialView("Modal");
            }
            else
            {
                //Update
                var obj = new SL_WCF.Alumno
                {
                    IdAlumno = alumno.IdAlumno,
                    Nombre = alumno.Nombre,
                    ApellidoPaterno = alumno.ApellidoPaterno,
                    ApellidoMaterno = alumno.ApellidoMaterno
                };
                var serv = new AlumnoServicios.AlumnoServiceClient();
                var resultado = serv.Update(obj);
                if (resultado) { ViewBag.Message = "Registro actualizado correctamente."; }
                else { ViewBag.Message = "Error al actualizar el registro."; }

                return PartialView("Modal");
            }
        }//Form(post)

        [HttpGet]
        public ActionResult Delete(int idAlumno)
        {
            var serv = new AlumnoServicios.AlumnoServiceClient();
            var resultado = serv.Delete(idAlumno);

            if (resultado) { ViewBag.Message = "Registro eliminado correctamente."; }
            else { ViewBag.Message = "Error al eliminar el registro."; }

            return PartialView("Modal");
        }//Delete


    }
}