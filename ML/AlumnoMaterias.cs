using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class AlumnoMaterias
    {
        public int IdAlumnoMateria { get; set; }
        public ML.Alumnos Alumno { get; set; }
        public ML.Materias Materia { get; set; }
        public decimal SubTotal { get; set; }
    }
}
