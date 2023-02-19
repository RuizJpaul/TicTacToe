using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    internal class Humano
    {
        public string nombre;
        public string apellido;
        public string ojosColor;
        public int edad;
        public Humano(string miApellido, string miNombre, string misOjosColor, int miEdad)
        {
            nombre = miNombre;
            apellido = miApellido;
            ojosColor = misOjosColor;
            edad = miEdad;
        }
        public void Presentarme()
        {
            Console.WriteLine("Hola soy {0} {1}", nombre, apellido);
            Console.WriteLine("Mis ojos son de color " + ojosColor);
            Console.WriteLine("Tengo " + edad);
        }
    }
}
