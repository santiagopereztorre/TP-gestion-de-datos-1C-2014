﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.ABM_Visibilidad
{
    public partial class EditarVisibilidad : Form
    {
        private String idVisibilidad;
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();
        private String query;
        private SqlCommand command;
        private IList<SqlParameter> parametros = new List<SqlParameter>();

        public EditarVisibilidad(String idVisibilidad)
        {
            InitializeComponent();
            this.idVisibilidad = idVisibilidad;
        }

        private void EditarVisibilidad_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            query = "SELECT * FROM LOS_SUPER_AMIGOS.Visibilidad WHERE id = @idVisibilidad";

            parametros.Clear();
            parametros.Add(new SqlParameter("@idVisibilidad", idVisibilidad));
            SqlDataReader reader = builderDeComandos.Crear(query, parametros).ExecuteReader();

            // Si no se pudo leer, tira excepcion
            if (!reader.Read()) throw new Exception("No se puede leer visibilidad");

            // Si se puede leer, lo muestra en pantalla
            textBox_Descripcion.Text = Convert.ToString(reader["descripcion"]);
            textBox_PrecioPorPublicar.Text = Convert.ToString(reader["precio"]);
            textBox_PorcentajePorVenta.Text = Convert.ToString(reader["porcentaje"]);
            if (Convert.ToBoolean(reader["habilitado"])) checkBox_Habilitado.Checked = true;
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            String descripcion = textBox_Descripcion.Text;
            String precioPorPublicar = textBox_PrecioPorPublicar.Text;
            String porcentajePorVenta = textBox_PorcentajePorVenta.Text;

            // Controla que esten los campos numeroDeDocumento y telefono
            if (!this.pasoControlDeNoVacio(descripcion)) return;
            if (!this.pasoControlDeNoVacio(precioPorPublicar)) return;
            if (!this.pasoControlDeNoVacio(porcentajePorVenta)) return;

            // Controla que descripcion no se encuentren registrado en el sistema
            if (!this.pasoControlDeRegistro(descripcion)) return;

            query = "UPDATE LOS_SUPER_AMIGOS.Visibilidad SET descripcion = @descripcion, precio = @precioporPublicar, porcentaje = @porcentajeDeVenta WHERE id = idVisibilidad";
            
            parametros.Clear();
            parametros.Add(new SqlParameter("@descripcion", descripcion));
            parametros.Add(new SqlParameter("@precioPorPublicar", Convert.ToDouble(precioPorPublicar)));
            parametros.Add(new SqlParameter("@porcentajePorVenta", Convert.ToDecimal(porcentajePorVenta)));
            parametros.Add(new SqlParameter("@idVisibilidad", idVisibilidad));

            int filasAfectadas = builderDeComandos.Crear(query, parametros).ExecuteNonQuery();

            if (filasAfectadas == 1) MessageBox.Show("Se modifico la visiblidad correctamente");

            this.Close();
        }

        private bool pasoControlDeNoVacio(string valor)
        {
            if (valor == "")
            {
                MessageBox.Show("Faltan datos");
                return false;
            }
            return true;
        }

        private bool pasoControlDeRegistro(String descripcion)
        {
            query = "SELECT COUNT(*) FROM LOS_SUPER_AMIGOS.Visibilidad WHERE descripcion = @descripcion";
            parametros.Clear();
            parametros.Add(new SqlParameter("@descripcion", descripcion));
            int cantidad = (int)builderDeComandos.Crear(query, parametros).ExecuteScalar();
            if (cantidad > 0)
            {
                MessageBox.Show("Ya existe es descripcion");
                return false;
            }
            return true;
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
