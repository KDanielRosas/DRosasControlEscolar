using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materias
    {
        public static ML.Result Add(ML.Materias materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DRosasControlEscolarEntities context = new DRosasControlEscolarEntities())
                {
                    int query = context.MateriasAdd(materia.Nombre, materia.Costo);
                    if (query > 0 )
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
        }//Add

        public static ML.Result Delete(int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DRosasControlEscolarEntities context = new DRosasControlEscolarEntities())
                {
                    int query = context.MateriasDelete(idMateria);

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
        }//Delete

        public static ML.Result Update(ML.Materias materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DRosasControlEscolarEntities context = new DRosasControlEscolarEntities())
                {
                    int query = context.MateriasUpdate(materia.IdMateria, materia.Nombre, materia.Costo);
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DRosasControlEscolarEntities context = new DRosasControlEscolarEntities())
                {
                    var query = context.MateriasGetAll().ToList();

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
        }//Getall

        public static ML.Result GetById(int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DRosasControlEscolarEntities context = new DRosasControlEscolarEntities())
                {
                    var query = context.MateriasGetById(idMateria).FirstOrDefault();
                    if (query != null)
                    {
                        ML.Materias materia = new ML.Materias();
                        materia.IdMateria = query.IdMateria;
                        materia.Nombre = query.Nombre;
                        materia.Costo = query.Costo.Value;

                        result.Object = materia;
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
        }//GetById
    }
}
