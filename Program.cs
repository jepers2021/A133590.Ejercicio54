using System;
using System.Collections.Generic;

namespace A133590.Ejercicio54
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 54");
            Dictionary<string, Alumno> alumnos = new Dictionary<string, Alumno>();
            Dictionary<string, Curso> cursos = new Dictionary<string, Curso>();
            while (true)
            {
                Console.WriteLine("1) Dar de alta un alumno.");
                Console.WriteLine("2) Dar de alta un curso.");
                Console.WriteLine("3) Asignar un alumno a un curso.");
                Console.WriteLine("4) Desasignar a un alumno de un curso.");
                Console.WriteLine("5) Ver lista de alumnos asignados a un curso.");
                Console.WriteLine("6) Ver lista de cursos de un alumno.");
                Console.WriteLine("7) Ver la cantidad de alumnos en cada curso.");
                Console.WriteLine("8) Ver la cantidad de cursos de cada alumno.");
                Console.WriteLine("9) Salir.");
                Console.Write("Ingrese una opción: ");
                int opcion;
                bool exito = Int32.TryParse(Console.ReadLine(), out opcion);
                while (!exito || opcion < 1 || opcion > 9)
                {
                    Console.Write("Opción inválida, ingrese una opción: ");
                    exito = Int32.TryParse(Console.ReadLine(), out opcion);
                }
                Console.Clear();
                switch(opcion)
                {
                    case 1:
                        {
                            Console.Write("Ingrese el número de registro del alumno: ");
                            string registro = Console.ReadLine();
                            bool registroValido = true;
                            foreach (char c in registro) registroValido &= Char.IsDigit(c);
                            if(!registroValido)
                            {
                                Console.WriteLine("Registro inválido, debe ser numérico");
                                continue;
                            }
                            if(alumnos.ContainsKey(registro))
                            {
                                Console.WriteLine("Número de registro existente en el sistema.");
                                continue;
                            }

                            Console.Write("Por favor, ingrese el nombre completo del alumno: ");
                            string nombre = Console.ReadLine();
                            bool nombreValido = true;
                            foreach(char c in nombre) nombreValido &= Char.IsLetter(c) || Char.IsWhiteSpace(c);
                            if(!nombreValido)
                            {
                                Console.WriteLine("Nombre inválido, debe ser alfabético.");
                                continue;
                            }

                            alumnos.Add(registro, new Alumno(nombre, registro));
                            Console.WriteLine("Alumno dado de alta exitosamente.");
                        }
                        
                        
                        break;

                    case 2:
                        {
                            Console.Write("Ingrese el código del curso: ");
                            string codigoCurso = Console.ReadLine();
                            bool codigoValido = true;
                            foreach (char c in codigoCurso) codigoValido &= Char.IsLetterOrDigit(c);
                            if(!codigoValido)
                            {
                                Console.WriteLine("Código de curso inválido, debe ser alfanumérico.");
                                continue;
                            }
                            cursos.Add(codigoCurso, new Curso(codigoCurso));
                            Console.WriteLine("Curso dado de alta exitosamente.");
                        }
                        break;
                    
                    case 3:
                        {
                            string registro;
                            string codigoCurso;

                            Console.Write("Ingrese el número de registro del alumno: ");
                            registro = Console.ReadLine();
                            Console.Write("Ingrese el código del curso que le quiere asignar al alumno: ");
                            codigoCurso = Console.ReadLine();

                            if(!alumnos.ContainsKey(registro))
                            {
                                Console.WriteLine("No existe un alumno con ese registro");
                                continue;
                            }
                            if(!cursos.ContainsKey(codigoCurso))
                            {
                                Console.WriteLine("No existe un curso con ese código.");
                                continue;
                            }

                            cursos[codigoCurso].AgregarAlumno(alumnos[registro]);
                            
                        }
                        break;

                    case 4:
                        {
                            string registro;
                            string codigoCurso;

                            Console.Write("Ingrese el número de registro del alumno: ");
                            registro = Console.ReadLine();
                            Console.Write("Ingrese el código del curso del cual quiere desasignar al alumno: ");
                            codigoCurso = Console.ReadLine();

                            if (!alumnos.ContainsKey(registro))
                            {
                                Console.WriteLine("No existe un alumno con ese registro");
                                continue;
                            }
                            if (!cursos.ContainsKey(codigoCurso))
                            {
                                Console.WriteLine("No existe un curso con ese código.");
                                continue;
                            }

                            cursos[codigoCurso].RemoverAlumno(alumnos[registro]);
                            
                        }
                        break;

                    case 5:
                        {
                            Console.Write("Ingrese código de curso: ");
                            string codigoCurso = Console.ReadLine();
                            if(!cursos.ContainsKey(codigoCurso))
                            {
                                Console.WriteLine("No existe un curso con ese código");
                                continue;
                            }
                            cursos[codigoCurso].VerAlumnos();
                        }
                        break;

                    case 6:
                        {
                            Console.Write("Ingrese número de registro de alumno: ");
                            string registro = Console.ReadLine();
                            if (!alumnos.ContainsKey(registro))
                            {
                                Console.WriteLine("No existe un curso con ese código");
                                continue;
                            }
                            alumnos[registro].VerCursos();
                        }
                        break;

                    case 7:
                        {
                            foreach(string codigoCurso in cursos.Keys)
                            {
                                Console.WriteLine($"Curso: {codigoCurso}, alumnos asignados: {cursos[codigoCurso].CantidadAlumnos()}");
                            }
                        }
                        break;

                    case 8:
                        {
                            foreach (string registro in alumnos.Keys)
                            {
                                Console.WriteLine($"Alumno: {{{registro},{alumnos[registro].Nombre}}}, cursos: {alumnos[registro].VerCantidadCursos()}");
                            }
                        }
                        break;

                    case 9:
                        Console.WriteLine("Presione cualquier tecla para continuar..");
                        Console.ReadKey();
                        return;
                }
            }
        }
    }
}
