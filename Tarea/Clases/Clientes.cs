using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea.Clases
{
    public class Clientes
    {
        private readonly string path = "C:\\Users\\martin.ponce\\Documents\\prueba\\clientes.csv";
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Edad { get; set; }
        public string Direccion { get; set; }
        public Clientes()
        {
        }
        public Clientes(string nombre, string apellido, string edad, string direccion)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Direccion = direccion;
        }
        public override string ToString()
        {
            return $"{Nombre},{Apellido},{Edad},{Direccion}";
        }
        public void Agregar_Cliente()
        {

            Clientes cliente = new Clientes()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                Direccion = Direccion
            };

            Agregar_Cliente(cliente);

        }
        public void Agregar_Cliente(Clientes cliente)
        {
            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Apellido))
            {
                throw new ArgumentException("Los valores no deben estar vacios");
            }
            using (StreamWriter strWriter = new StreamWriter(path, true))
            {

                strWriter.WriteLine(cliente.ToString());
                strWriter.Close();
            }
        }
        public List<Clientes> Cargar_Clientes()
        {
            List<Clientes> ListaClientes = new();

            if (System.IO.File.Exists(path))
            {
                /*Leer archivo*/
                using (StreamReader strReader = new StreamReader(path))
                {
                    string ln = string.Empty;

                    while ((ln = strReader.ReadLine()) != null)
                    {
                        string[] campos = ln.Split(",");

                        Clientes cliente = new()
                        {
                            Nombre = campos[0],
                            Apellido = campos[1],
                            Edad = campos[2],
                            Direccion = campos[3]
                        };
                        ListaClientes.Add(cliente);
                    }
                }
            }
            return ListaClientes;
        }
        public void GuardarListaClientes(List<Clientes> ListaClientes)
        {
            foreach (Clientes cliente in ListaClientes)
            {
                using (StreamWriter strWriter = new StreamWriter(path, true))
                {
                    strWriter.WriteLine(cliente.ToString());
                    strWriter.Close();
                }

            }
        }
    }
}
