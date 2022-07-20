using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_Conecion_BD.Modelo
{
    internal class Empleados
    {
        private string cedula;
        private string nombre;
        private string apellido1;
        private string apellido2;
        private int edad;
        private string direccion;

        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido1 { get => apellido1; set => apellido1 = value; }
        public string Apellido2 { get => apellido2; set => apellido2 = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Direccion { get => direccion; set => direccion = value; }

        public Empleados()
        {
            this.Cedula = "";
            this.Nombre = "";
            this.Apellido1 = "";
            this.Apellido2 = "";
            this.Edad = 0;
            this.Direccion = "";
        }
        public Empleados(string cedula, string nombre, string apellido, int
        edad, string direccion)
        {
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Apellido1 = apellido;
            this.Apellido2 = apellido;
            this.Edad = edad;
            this.Direccion = direccion;
        }


    }
}
