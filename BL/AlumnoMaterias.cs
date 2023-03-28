using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMaterias
    {
        public static ML.Result GetByIdAlumno(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DRosasControlEscolarEntities context = new DRosasControlEscolarEntities())
                {
                    var query = context.AlumnoMateriasGetByIdAlumno(IdAlumno).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.AlumnoMaterias alumnoMaterias = new ML.AlumnoMaterias();
                            alumnoMaterias.IdAlumnoMateria = item.IdAlumnoMateria;
                            alumnoMaterias.Alumno = new ML.Alumnos();
                            alumnoMaterias.Alumno.IdAlumno = item.IdAlumno.Value;
                            alumnoMaterias.Alumno.Nombre = item.AlumnoNombre;
                            alumnoMaterias.Alumno.ApellidoPaterno = item.AlumnoApellidoPaterno;
                            alumnoMaterias.Alumno.ApellidoMaterno = item.AlumnoApellidoMaterno;
                            alumnoMaterias.Materia = new ML.Materias();
                            alumnoMaterias.Materia.IdMateria = item.IdMateria.Value;
                            alumnoMaterias.Materia.Nombre = item.MateriaNombre;
                            alumnoMaterias.Materia.Costo = item.Costo.Value;

                            result.Objects.Add(alumnoMaterias);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                throw;
            }

            return result;
        }//GetByIdAlumno

        public static ML.Result Add(int idAlumno, int idMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DRosasControlEscolarEntities context = new DRosasControlEscolarEntities())
                {
                    int query = context.AlumnoMateriasAdd(idAlumno, idMateria);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                throw;
            }
            return result;
        }//Add

        public static ML.Result Update(ML.AlumnoMaterias alumnoMaterias)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DRosasControlEscolarEntities context = new DRosasControlEscolarEntities())
                {
                    int query = context.AlumnoMateriasUpdate(alumnoMaterias.IdAlumnoMateria,
                        alumnoMaterias.Alumno.IdAlumno, alumnoMaterias.Materia.IdMateria);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                throw;
            }
            return result;
        }//Update

        public static ML.Result Delete(int idAlumnoMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DRosasControlEscolarEntities context = new DRosasControlEscolarEntities())
                {
                    int query = context.AlumnoMateriasDelete(idAlumnoMateria);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                throw;
            }
            return result;
        }//Delete

        public static ML.Result GetMateriasDisponibles(int idAlumno)
        {
            ML.Result result = new Result();
            try
            {
                using (DRosasControlEscolarEntities context = new DRosasControlEscolarEntities())
                {
                    var query = context.AlumnoMateriasGetMateriasDisponibles(idAlumno).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Materias materia = new ML.Materias();
                            materia.IdMateria = item.IdMateria;
                            materia.Nombre = item.Nombre;
                            materia.Costo = item.Costo.Value;

                            result.Objects.Add(materia);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                throw;
            }
            return result;
        }//GetMateriasDisponibles
    }//Class
}//NS
