using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Taller_Conecion_BD.Modelo;
using System.Data;

namespace Taller_Conecion_BD.Datos
{

    internal class DatosEmpleado
    {
        public static bool Guardar(Empleados e)
        {
            try
            {
                Conexion conex = new Conexion();
                string sql = "Insert into tb_empleados values('"+e.Cedula+"', '"+e.Nombre+"', '"+e.Apellido1+ "', '" + e.Apellido2 + "', " + e.Edad+", '"+ e.Direccion + "')";
                SqlCommand comando = new
               SqlCommand(sql, conex.Conectar());
                int cantidad = comando.ExecuteNonQuery();
            if (cantidad == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                conex.Desconectar();

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DataTable Listar()
        {
            try
            {
                Conexion conex = new Conexion();
                string sql = "SELECT *FROM tb_empleados";
                SqlCommand comando = new SqlCommand(sql, conex.Conectar());
                SqlDataReader dr =
               comando.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable tabla = new DataTable();
                tabla.Load(dr);
                conex.Desconectar();
                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Empleados Consultar(string cedula)
        {
            try
            {
                Conexion conex = new Conexion();
                string sql = "SELECT *FROM tb_empleados WHERE cedula ='"+cedula+"'";
            SqlCommand comando = new SqlCommand(sql, conex.Conectar());
                SqlDataReader dr = comando.ExecuteReader();

                Empleados emp = new Empleados();
                if (dr.Read())
                {
                    emp.Cedula = dr["cedula"].ToString();
                    emp.Nombre = dr["nombre"].ToString();
                    emp.Apellido1 = dr["apellido1"].ToString();
                    emp.Apellido2 = dr["apellido2"].ToString();
                    emp.Edad = Convert.ToInt32(dr["edad"].ToString());
                    emp.Direccion = dr["direccion"].ToString();
                    conex.Desconectar();//se desconecta
                    return emp;
                }
                else
                {
                    conex.Desconectar();//se desconecta
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool Actualizar(Empleados e)
        {
            try
            {
                Conexion conex = new Conexion();
                string sql = "UPDATE tb_empleados SET nombre ='"+e.Nombre+"',apellido1 = '"+e.Apellido1+ "',apellido2 = '" + e.Apellido2 + "',edad =" + e.Edad+",direccion = '"+e.Direccion+"' WHERE cedula = '"+e.Cedula+"'";
            SqlCommand comando = new SqlCommand(sql, conex.Conectar());
                int cantidad = comando.ExecuteNonQuery();
            if (cantidad == 1)
                {
                    conex.Desconectar();
                    return true;
                }
                else
                {
                    conex.Desconectar();
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool Eliminar(string cedula)
        {
            try
            {
                Conexion conex = new Conexion();
                string sql = "DELETE FROM tb_empleados WHERE cedula ='" + cedula + "'";
                SqlCommand comando = new SqlCommand(sql, conex.Conectar());
                int cantidad = comando.ExecuteNonQuery();
            if (cantidad == 1)
                {
                    conex.Desconectar();
                    return true;
                }
                else
                {
                    conex.Desconectar();
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }



    }
}
