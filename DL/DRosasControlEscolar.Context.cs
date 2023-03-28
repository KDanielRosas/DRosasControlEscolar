﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DRosasControlEscolarEntities : DbContext
    {
        public DRosasControlEscolarEntities()
            : base("name=DRosasControlEscolarEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
        public virtual DbSet<AlumnoMateria> AlumnoMaterias { get; set; }
    
        public virtual int AlumnosAdd(string nombre, string apellidoPaterno, string apellidoMaterno)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AlumnosAdd", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter);
        }
    
        public virtual int AlumnosDelete(Nullable<int> idAlumno)
        {
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AlumnosDelete", idAlumnoParameter);
        }
    
        public virtual ObjectResult<AlumnosGetAll_Result> AlumnosGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AlumnosGetAll_Result>("AlumnosGetAll");
        }
    
        public virtual ObjectResult<AlumnosGetById_Result> AlumnosGetById(Nullable<int> idAlumno)
        {
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AlumnosGetById_Result>("AlumnosGetById", idAlumnoParameter);
        }
    
        public virtual int AlumnosUpdate(Nullable<int> idAlumno, string nombre, string apellidoPaterno, string apellidoMaterno)
        {
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AlumnosUpdate", idAlumnoParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter);
        }
    
        public virtual int MateriasDelete(Nullable<int> idMateria)
        {
            var idMateriaParameter = idMateria.HasValue ?
                new ObjectParameter("IdMateria", idMateria) :
                new ObjectParameter("IdMateria", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MateriasDelete", idMateriaParameter);
        }
    
        public virtual ObjectResult<MateriasGetAll_Result> MateriasGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MateriasGetAll_Result>("MateriasGetAll");
        }
    
        public virtual ObjectResult<MateriasGetById_Result> MateriasGetById(Nullable<int> idMateria)
        {
            var idMateriaParameter = idMateria.HasValue ?
                new ObjectParameter("IdMateria", idMateria) :
                new ObjectParameter("IdMateria", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MateriasGetById_Result>("MateriasGetById", idMateriaParameter);
        }
    
        public virtual int MateriasAdd(string nombre, Nullable<decimal> costo)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var costoParameter = costo.HasValue ?
                new ObjectParameter("Costo", costo) :
                new ObjectParameter("Costo", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MateriasAdd", nombreParameter, costoParameter);
        }
    
        public virtual int MateriasUpdate(Nullable<int> idMateria, string nombre, Nullable<decimal> costo)
        {
            var idMateriaParameter = idMateria.HasValue ?
                new ObjectParameter("IdMateria", idMateria) :
                new ObjectParameter("IdMateria", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var costoParameter = costo.HasValue ?
                new ObjectParameter("Costo", costo) :
                new ObjectParameter("Costo", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MateriasUpdate", idMateriaParameter, nombreParameter, costoParameter);
        }
    
        public virtual int AlumnoMateriasAdd(Nullable<int> idAlumno, Nullable<int> idMateria)
        {
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            var idMateriaParameter = idMateria.HasValue ?
                new ObjectParameter("IdMateria", idMateria) :
                new ObjectParameter("IdMateria", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AlumnoMateriasAdd", idAlumnoParameter, idMateriaParameter);
        }
    
        public virtual int AlumnoMateriasDelete(Nullable<int> idAlumnoMateria)
        {
            var idAlumnoMateriaParameter = idAlumnoMateria.HasValue ?
                new ObjectParameter("IdAlumnoMateria", idAlumnoMateria) :
                new ObjectParameter("IdAlumnoMateria", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AlumnoMateriasDelete", idAlumnoMateriaParameter);
        }
    
        public virtual int AlumnoMateriasUpdate(Nullable<int> idAlumnoMateria, Nullable<int> idAlumno, Nullable<int> idMateria)
        {
            var idAlumnoMateriaParameter = idAlumnoMateria.HasValue ?
                new ObjectParameter("IdAlumnoMateria", idAlumnoMateria) :
                new ObjectParameter("IdAlumnoMateria", typeof(int));
    
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            var idMateriaParameter = idMateria.HasValue ?
                new ObjectParameter("IdMateria", idMateria) :
                new ObjectParameter("IdMateria", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AlumnoMateriasUpdate", idAlumnoMateriaParameter, idAlumnoParameter, idMateriaParameter);
        }
    
        public virtual ObjectResult<AlumnoMateriasGetByIdAlumno_Result> AlumnoMateriasGetByIdAlumno(Nullable<int> idAlumno)
        {
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AlumnoMateriasGetByIdAlumno_Result>("AlumnoMateriasGetByIdAlumno", idAlumnoParameter);
        }
    
        public virtual ObjectResult<AlumnoMateriasGetMateriasDisponibles_Result> AlumnoMateriasGetMateriasDisponibles(Nullable<int> idAlumno)
        {
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AlumnoMateriasGetMateriasDisponibles_Result>("AlumnoMateriasGetMateriasDisponibles", idAlumnoParameter);
        }
    
        public virtual ObjectResult<AlumnoMateriasNODisponibles_Result> AlumnoMateriasNODisponibles(Nullable<int> idAlumno)
        {
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AlumnoMateriasNODisponibles_Result>("AlumnoMateriasNODisponibles", idAlumnoParameter);
        }
    }
}
