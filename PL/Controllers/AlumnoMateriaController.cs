using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        // GET: AlumnoMateria
        public ActionResult GetAll()
        {
            ML.Result result = BL.Alumnos.GetAll();

            return View(result);
        }//GetAll

        public ActionResult MateriasGetByIdAlumno(int? IdAlumno)
        {
            if (IdAlumno == null)
            {
                IdAlumno = int.Parse(TempData["IdAlumno"].ToString());
            }

            TempData["IdAlumno"] = IdAlumno;
            ML.Result resultAlumno = BL.Alumnos.GetById(IdAlumno.Value);
            ML.Alumnos alumno = (ML.Alumnos)resultAlumno.Object;
            ViewBag.AlumnoNombre = (alumno.Nombre + " " + alumno.ApellidoPaterno + " " + alumno.ApellidoMaterno);
            ML.Result result = BL.AlumnoMaterias.GetByIdAlumno(IdAlumno.Value);

            foreach (ML.AlumnoMaterias item in result.Objects.Cast<AlumnoMaterias>())
            {
                result.SubTotal += item.Materia.Costo;
            }

            return View(result);            
        }//MateriasGetByIdAlumno

        [HttpGet]
        public ActionResult Form()
        {
            /*
            int IdAlumno = int.Parse(TempData["IdAlumno"].ToString());
            ML.Alumnos alumno = GetById(IdAlumno);
            ML.Result result = BL.AlumnoMaterias.GetByIdAlumno(IdAlumno);
            ML.Materias materia = new ML.Materias();
            materia.ListMaterias = result.Objects;
            ViewBag.IdAlumno = IdAlumno;
            ML.AlumnoMaterias alumnoMaterias = new ML.AlumnoMaterias();
            alumnoMaterias.Alumno = alumno;
            alumnoMaterias.Materia = materia;
            */
            int idAlumno = int.Parse(TempData["IdAlumno"].ToString());
            ML.Result resultMaterias = BL.AlumnoMaterias.GetMateriasDisponibles(idAlumno);
            ML.Result resultAlumno = BL.Alumnos.GetById(idAlumno);
            ML.AlumnoMaterias alumnoMaterias = new ML.AlumnoMaterias();
            ML.Materias materias = new ML.Materias();
            materias.ListMaterias = resultMaterias.Objects;
            alumnoMaterias.Materia = materias;
            alumnoMaterias.Alumno = (ML.Alumnos)resultAlumno.Object;
            TempData.Keep();
            return View(alumnoMaterias);
        }

        /*
        [HttpPost]
        public ActionResult Form(ML.AlumnoMaterias alumnoMaterias)
        {
            ML.Result result = BL.AlumnoMaterias.Add(alumnoMaterias.Alumno.IdAlumno, alumnoMaterias.Materia.IdMateria);

            if (result.Correct)
            {
                ViewBag.Message = "Agregada correctamente";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "Error al agregar";
                return PartialView("Modal");
            }
        }
        */

        //[HttpPost]
        public ActionResult MateriasAdd(int IdAlumno, int IdMateria)
        {
            TempData["IdAlumno"] = IdAlumno;
            ML.Result result = BL.AlumnoMaterias.Add(IdAlumno, IdMateria);

            if (result.Correct)
            {
                ViewBag.Message = "Agregada correctamente";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "Error al agregar";
                return PartialView("Modal");
            }
        }//MateriasAdd

        [HttpPost]
        public JsonResult AddMateria(int[] array, int IdAlumno)
        {
            ML.Result result = new Result();
            TempData["IdAlumno"] = IdAlumno;
            //ML.Result result = BL.AlumnoMaterias.Add(IdAlumno, IdMateria);

            if (array == null)
            {
                return null;
            }

            foreach (int id in array)
            {
                result = BL.AlumnoMaterias.Add(IdAlumno, id);
                if (!result.Correct)
                {
                    break;
                }
            }
            if (result.Correct)
            {
                return Json(result);
            }
            else
            {
                return null;
            }
            
        }//MateriasAdd

        public ActionResult AlumnoMateriasDelete(int IdAlumnoMaterias)
        {
            TempData.Keep();
            ML.Result result = BL.AlumnoMaterias.Delete(IdAlumnoMaterias);
            if (result.Correct)
            {
                ViewBag.Message = "Eliminada correctamente";
                return PartialView("ModalDelete");
            }
            else
            {
                ViewBag.Message = "Error al eliminar";
                return PartialView("ModalDelete");
            }
        }//Delete
    }
}