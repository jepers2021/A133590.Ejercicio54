using System;
using System.Collections.Generic;
using System.Text;

namespace A133590.Ejercicio54
{
    [Serializable]
    class Alumno
    {
        string nombre;
        string registro;
        Dictionary<string, Curso> cursos;


        public Alumno(string nombre, string registro)
        {
            this.nombre = nombre;
            this.registro = registro;
            cursos = new Dictionary<string, Curso>();
        }

        public void AsignarCurso(Curso curso)
        {
            cursos.Add(curso.Codigo, curso);
        }

        public void RemoverCurso(string codigoCurso)
        {
            cursos.Remove(codigoCurso);
        }

        public void VerCursos()
        {
            if(cursos.Count == 0)
            {
                Console.WriteLine("El alumno no esta asignado a algún curso.");
                return;
            }
            foreach (string curso in cursos.Keys)
            {
                Console.WriteLine($"Codigo curso: {curso}");
            }
        }

        public int VerCantidadCursos()
        {
            return cursos.Count;
        }

        public string Nombre { get => nombre; }
        public string Registro { get => registro; }
    }
}
