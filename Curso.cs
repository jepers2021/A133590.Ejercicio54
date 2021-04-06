using System;
using System.Collections.Generic;
using System.Text;

namespace A133590.Ejercicio54
{
    class Curso
    {

        string codigo;
        Dictionary<string,Alumno> alumnos;

        public Curso(string codigo)
        {
            this.codigo = codigo;
            alumnos = new Dictionary<string, Alumno>();
        }

        public void VerAlumnos()
        {
            if(alumnos.Count == 0)
            {
                Console.WriteLine("No hay alumnos en este curso.");
                return;
            }
            foreach(string alumno in alumnos.Keys)
            {
                Console.WriteLine($"Nombre: {alumnos[alumno]}, Registro: {alumnos[alumno]}");
            }
        }

        public void AgregarAlumno(Alumno alumno)
        {
            if (!alumnos.ContainsKey(alumno.Registro))
            {
                alumnos.Add(alumno.Registro, alumno);
                alumno.AsignarCurso(this);
                Console.WriteLine($"El alumno {alumno.Nombre} ha sido exitosamente asignado a {this.codigo}.");
            }
            else
            {
                Console.WriteLine("Alumno ya registrado en este curso.");
            }    
        }

        public void RemoverAlumno(Alumno alumno)
        {
            if (alumnos.ContainsKey(alumno.Registro))
            {
                alumno.RemoverCurso(this.codigo);
                alumnos.Remove(alumno.Registro);
                Console.WriteLine($"El alumno {alumno.Nombre} ha sido exitosamente desasignado de {codigo}.");
            }
            else
            {
                Console.WriteLine($"El alumno {alumno.Nombre} no está asignado a este curso.");
            }
        }

        public int CantidadAlumnos()
        {
            return alumnos.Count;
        }

        public string Codigo { get => codigo; }
    }
}
