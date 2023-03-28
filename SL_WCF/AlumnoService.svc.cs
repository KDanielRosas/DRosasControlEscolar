using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlumnoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AlumnoService.svc or AlumnoService.svc.cs at the Solution Explorer and start debugging.
    public class AlumnoService : IAlumnoService
    {
        public bool Add(Alumno obj)
        {
            ML.Alumnos alumno = new ML.Alumnos();
            alumno.Nombre = obj.Nombre;
            alumno.ApellidoPaterno = obj.ApellidoPaterno;
            alumno.ApellidoMaterno = obj.ApellidoMaterno;
            ML.Result result = BL.Alumnos.Add(alumno);
            if (result.Correct)
            {
                return true;
            }
            else
            {
                return false;
            }
        }//Add

        public bool Delete(int idAlumno)
        {
            ML.Result result = BL.Alumnos.Delete(idAlumno);
            if (result.Correct)
            {
                return true;
            }
            else
            {
                return false;
            }
        }//Delete

        public bool Update(Alumno obj)
        {
            ML.Alumnos alumno = new ML.Alumnos();
            alumno.IdAlumno = obj.IdAlumno;
            alumno.Nombre = obj.Nombre;
            alumno.ApellidoPaterno = obj.ApellidoPaterno;
            alumno.ApellidoMaterno = obj.ApellidoMaterno;
            ML.Result result = BL.Alumnos.Update(alumno);
            if (result.Correct)
            {
                return true;
            }
            else
            {
                return false;
            }
        }//Update

        public List<Alumno> GetAll()
        {
            ML.Result result = BL.Alumnos.GetAll();
            List<Alumno> list = new List<Alumno>();
            foreach (ML.Alumnos alumno in result.Objects)
            {
                var item = new Alumno
                {
                    IdAlumno = alumno.IdAlumno,
                    Nombre = alumno.Nombre,
                    ApellidoPaterno = alumno.ApellidoPaterno,
                    ApellidoMaterno = alumno.ApellidoMaterno
                };
                list.Add(item);
            }
            return list;
        }//GetAll

        public Alumno GetById(int idAlumno)
        {
            ML.Result result = BL.Alumnos.GetById(idAlumno);
            var item = (ML.Alumnos)result.Object;
            var obj = new Alumno
            {
                IdAlumno = item.IdAlumno,
                Nombre = item.Nombre,
                ApellidoPaterno = item.ApellidoPaterno,
                ApellidoMaterno = item.ApellidoMaterno
            };
            return obj;
        }//GetById
    }
}
