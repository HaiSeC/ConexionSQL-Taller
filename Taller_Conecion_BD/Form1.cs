using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taller_Conecion_BD.Datos;
using Taller_Conecion_BD.Modelo;

namespace Taller_Conecion_BD
{
    public partial class Form1 : Form
    {
        bool consultado;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor..");
            }
            else
            {
                if (textBox2.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar un valor..");
                }
                else
                {
                    if (textBox3.Text.Trim() == "")
                    {
                        MessageBox.Show("Debe ingresar un valor..");
                    }
                    else
                    {
                        if (textBox4.Text.Trim() == "")
                        {
                            MessageBox.Show("Debe ingresar un valor..");
                        }
                        else
                        {
                            if (textBox5.Text.Trim() == "")
                            {
                                MessageBox.Show("Debe ingresar un valor..");
                            }
                            else
                            {
                                if (textBox6.Text.Trim() == "")
                                {
                                    MessageBox.Show("Debe ingresar un valor..");
                                }
                                else
                                {
                                    try
                                    {
                                        Empleados emp = new Empleados();
                                        emp.Cedula = textBox1.Text.Trim().ToUpper();
                                        emp.Nombre = textBox2.Text.Trim().ToUpper();
                                        emp.Apellido1 = textBox3.Text.Trim().ToUpper();
                                        emp.Apellido2 = textBox4.Text.Trim().ToUpper();
                                        emp.Edad = Convert.ToInt32(textBox5.Text);
                                        emp.Direccion = textBox6.Text.Trim().ToUpper();
                                        if (DatosEmpleado.Guardar(emp))
                                        {
                                            LlenarGrid();
                                            MessageBox.Show("Los datos han sido guardados");
                                            limpiar();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Cédula existe, consulte su información");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }



        private void LlenarGrid()
        {
            DataTable informacion = DatosEmpleado.Listar();
            if (informacion == null)
            {
                MessageBox.Show("No se puede acceder a la información");
            }
            else
            {
                dataGridView1.DataSource = informacion.DefaultView;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarGrid();

        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor..");
            }
            else
            {
                Empleados emp =
               DatosEmpleado.Consultar(textBox1.Text.Trim());
                if (emp == null)
                {
                    MessageBox.Show("La cédula no existe en el sistema.");
                    consultado = false;
                }
                else
                {
                    textBox1.Text = emp.Cedula;
                    textBox2.Text = emp.Nombre;
                    textBox3.Text = emp.Apellido1;
                    textBox4.Text = emp.Apellido2;
                    textBox5.Text = emp.Edad.ToString();
                    textBox6.Text = emp.Direccion;
                    consultado = true;
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (consultado == false)
            {
                MessageBox.Show("Debe consultar primero...");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Ingrese un valor");
            }
            else
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Ingrese un valor");
                }
                else
                {
                    try
                    {
                        Empleados emp = new Empleados();
                        emp.Cedula = textBox1.Text.Trim().ToUpper();
                        emp.Nombre = textBox2.Text.Trim().ToUpper();
                        emp.Apellido1 = textBox3.Text.Trim().ToUpper();
                        emp.Apellido2 = textBox4.Text.Trim().ToUpper();
                        emp.Edad = Convert.ToInt32(textBox5.Text);
                        emp.Direccion = textBox6.Text.Trim().ToUpper();
                        if (DatosEmpleado.Actualizar(emp))
                        {
                            LlenarGrid();
                            MessageBox.Show("Los datos ha sido Actualizados");
                            consultado = false;
                        }
                        else
                        {
                            MessageBox.Show("Los datos NO se actualizaron");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (consultado == false)
            {
                MessageBox.Show("Debe consultar primero...");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Ingrese un valor");
            }
            else
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Ingrese un valor");
                }
                else
                {
                    try
                    {
                        if (DatosEmpleado.Eliminar(textBox1.Text.Trim()))
                        {
                            LlenarGrid();
                            MessageBox.Show("Los datos ha sido Eliminados");
                            consultado = false;
                        }
                        else
                        {
                            MessageBox.Show("Los datos NO se eliminaron");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }


}
