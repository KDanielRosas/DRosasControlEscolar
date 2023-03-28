using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace BL
{
    public class Alumnos
    {
        public static ML.Result Add(ML.Alumnos alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "AlumnosAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] parameters = new SqlParameter[3];
                        parameters[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        parameters[0].Value = alumno.Nombre;

                        parameters[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        parameters[1].Value = alumno.ApellidoPaterno;

                        parameters[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        parameters[2].Value = alumno.ApellidoMaterno;

                        cmd.Parameters.AddRange(parameters);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }//sqlCommand
                }//sqlContext
            }//try
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                throw;
            }//catch
            return result;
        }//Add

        public static ML.Result Delete(int idAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "AlumnosDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] parameters = new SqlParameter[1];
                        parameters[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        parameters[0].Value = idAlumno;

                        cmd.Parameters.AddRange(parameters);

                        cmd.Connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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

        public static ML.Result Update(ML.Alumnos alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "AlumnosUpdate";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] parameters = new SqlParameter[4];

                        parameters[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        parameters[0].Value = alumno.IdAlumno;

                        parameters[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        parameters[1].Value = alumno.Nombre;

                        parameters[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        parameters[2].Value = alumno.ApellidoPaterno;

                        parameters[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        parameters[3].Value = alumno.ApellidoMaterno;

                        cmd.Parameters.AddRange(parameters);

                        cmd.Connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "AlumnosGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable dt = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        result.Objects = new List<object>();

                        foreach (DataRow row in dt.Rows)
                        {
                            ML.Alumnos alumno = new ML.Alumnos();
                            alumno.IdAlumno = (int)row[0];
                            alumno.Nombre = (string)row[1];
                            alumno.ApellidoPaterno = (string)row[2];
                            alumno.ApellidoMaterno = (string)row[3];

                            result.Objects.Add(alumno);
                        }//foreach
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
        }//GetAll

        public static ML.Result GetById(int idAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "AlumnosGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] parameters = new SqlParameter[1];

                        parameters[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        parameters[0].Value = idAlumno;

                        cmd.Parameters.AddRange(parameters);

                        DataTable dt = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        result.Objects = new List<object>();

                        ML.Alumnos alumno = new ML.Alumnos();
                        foreach (DataRow row in dt.Rows)
                        {
                            alumno.IdAlumno = (int)row[0];
                            alumno.Nombre = (string)row[1];
                            alumno.ApellidoPaterno = (string)row[2];
                            alumno.ApellidoMaterno = (string)row[3];
                        }
                        result.Object = alumno;
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
        }//GetById
    }//Class
}//NS
