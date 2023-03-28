using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlumnoService" in both code and config file together.
    [ServiceContract]
    public interface IAlumnoService
    {
        [OperationContract]
        bool Add(Alumno obj);

        [OperationContract]
        bool Update(Alumno obj);

        [OperationContract]
        bool Delete(int idAlumno);

        [OperationContract]
        List<Alumno> GetAll();

        [OperationContract]
        Alumno GetById(int idAlumno);
    }

    [DataContract]
    public class Alumno
    {
        [DataMember] public int IdAlumno;
        [DataMember] public string Nombre;
        [DataMember] public string ApellidoPaterno;
        [DataMember] public string ApellidoMaterno;
    }
}
