using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_Conecion_BD.Datos
{
    internal class Conexion
    {
        SqlConnection con;


        //Constructor
        public Conexion()
        {
            con = new SqlConnection("Data Source=DESKTOP-UTLBP94;Initial Catalog = Empleados; Integrated Security = True");
        }
        //Método para abrir la conexion
        public SqlConnection Conectar()
        {
            try
            {
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de conexion");
                return null;
            }
        }
        //Metodo para cerrar la conexion
        public bool Desconectar()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
