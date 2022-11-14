using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea.Forms;
using System.IO;

namespace Tarea.Clases
{
    public class Doctores
    {
        private readonly string path = "C:\\Users\\martin.ponce\\Documents\\prueba\\tarea.csv";
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string cedula { get; set; }
        public string telefono { get; set; }
        public Doctores()
        {
        }
        public Doctores(string nombre, string apellido, string cedula, string telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            this.cedula = cedula;
            this.telefono = telefono;
        }
        public override string ToString()
        {
            return $"{Nombre},{Apellido},{cedula},{telefono}";
        }
        public void Agregar_Doctor()
        {

            Doctores doctor = new Doctores()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                cedula = cedula,
                telefono=telefono
            };

            Agregar_Doctor(doctor);

        }
        public void Agregar_Doctor(Doctores doctor)
        {
            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Apellido))
            {
                throw new ArgumentException("Los valores no deben estar vacios");
            }
            using (StreamWriter strWriter = new StreamWriter(path, true))
            {

                strWriter.WriteLine(doctor.ToString());
                strWriter.Close();
            }
        }
        public List<Doctores> Cargar_Doctores()
        {
            List<Doctores> ListaDoctores = new();

            if (System.IO.File.Exists(path))
            {
                /*Leer archivo*/
                using (StreamReader strReader = new StreamReader(path))
                {
                    string ln = string.Empty;

                    while ((ln = strReader.ReadLine()) != null)
                    {
                        string[] campos = ln.Split(",");

                        Doctores doctor = new()
                        {
                            Nombre = campos[0],
                            Apellido = campos[1],
                            cedula = campos[2],
                            telefono = campos[3]
                        };
                        ListaDoctores.Add(doctor);
                    }
                }
            }
            return ListaDoctores;
        }
        public void GuardarListaDoctores(List<Doctores> ListaDoctores)
        {
            foreach (Doctores doctor in ListaDoctores)
            {
                using (StreamWriter strWriter = new StreamWriter(path, true))
                {
                    strWriter.WriteLine(doctor.ToString());
                    strWriter.Close();
                }

            }
        }

    }
}
