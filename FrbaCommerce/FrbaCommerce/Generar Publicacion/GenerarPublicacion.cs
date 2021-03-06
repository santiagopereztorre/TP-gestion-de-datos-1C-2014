﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaCommerce.Exceptions;
using FrbaCommerce.Objetos;

namespace FrbaCommerce.Generar_Publicacion
{
    public partial class GenerarPublicacion : Form
    {
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();

        public GenerarPublicacion()
        {
            InitializeComponent();
        }

        private void GenerarPublicacion_Load(object sender, EventArgs e)
        {
            CargarTiposDePublicacion();
            CargarEstados();
            CargarRubros();
            CargarVisibilidades();
        }

        private void CargarTiposDePublicacion()
        {
            comboBox_TiposDePublicacion.DataSource = comunicador.SelectDataTable("descripcion", "LOS_SUPER_AMIGOS.TipoDePublicacion");
            comboBox_TiposDePublicacion.ValueMember = "descripcion";
        }

        private void CargarEstados()
        {
            DataTable estados = new DataTable();
            estados.Columns.Add("estados");
            estados.Rows.Add("Borrador");
            estados.Rows.Add("Publicada");
            comboBox_Estado.DataSource = estados;
            comboBox_Estado.ValueMember = "estados";
        }

        private void CargarRubros()
        {
            comboBox_Rubro.DataSource = comunicador.SelectDataTable("descripcion", "LOS_SUPER_AMIGOS.Rubro");
            comboBox_Rubro.ValueMember = "descripcion";
        }

        private void CargarVisibilidades()
        {
            comboBox_Visibilidad.DataSource = comunicador.SelectDataTable("descripcion", "LOS_SUPER_AMIGOS.Visibilidad");
            comboBox_Visibilidad.ValueMember = "descripcion";
        }

        private void button_generar_Click(object sender, EventArgs e)
        {
            String tipo = comboBox_TiposDePublicacion.Text;
            String estado = comboBox_Estado.Text;
            String descripcion = textBox_Descripcion.Text;
            DateTime fechaDeInicio = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["DateKey"]);
            String rubro = comboBox_Rubro.Text;
            String visibilidadDescripcion = comboBox_Visibilidad.Text;
            Boolean pregunta = radioButton_Pregunta.Checked;
            String stock = textBox_Stock.Text;
            String precio = textBox_Precio.Text;

            Decimal idRubro = (Decimal)comunicador.SelectFromWhere("id", "Rubro", "descripcion", rubro);
            Decimal idEstado = (Decimal)comunicador.SelectFromWhere("id", "Estado", "descripcion", estado);
            Decimal idTipoDePublicacion = (Decimal)comunicador.SelectFromWhere("id", "TipoDePublicacion", "descripcion", tipo);
            Decimal idVisibilidad = Convert.ToDecimal(comunicador.SelectFromWhere("id", "Visibilidad", "descripcion", visibilidadDescripcion));
            Double duracion = Convert.ToDouble(comunicador.SelectFromWhere("duracion", "Visibilidad", "descripcion", visibilidadDescripcion));
            DateTime fechaDeVencimiento = Convert.ToDateTime(Convert.ToString(Convert.ToDateTime(fechaDeInicio).AddDays(duracion)));

            // Insert Publicacion
            try
            {
                Publicacion publicacion = new Publicacion();
                publicacion.SetTipo(idTipoDePublicacion);
                publicacion.SetEstado(idEstado);
                publicacion.SetDescripcion(descripcion);
                publicacion.SetFechaDeInicio(fechaDeInicio);
                publicacion.SetFechaDeVencimiento(fechaDeVencimiento);
                publicacion.SetStock(stock);
                publicacion.SetPrecio(precio);
                publicacion.SetIdRubro(idRubro);
                publicacion.SetIdVisibilidad(idVisibilidad);
                publicacion.SetIdUsuario(UsuarioSesion.Usuario.id);
                publicacion.SetPregunta(pregunta);
                publicacion.SetHabilitado(true);
                Decimal idPublicacion = comunicador.CrearPublicacion(publicacion);
                if (idPublicacion > 0) MessageBox.Show("Se agrego la publicacion correctamente");
            }
            catch (CampoVacioException exception)
            {
                MessageBox.Show("Falta completar campo: " + exception.Message);
                return;
            }
            catch (FormatoInvalidoException exception)
            {
                MessageBox.Show("Datos mal ingresados en: " + exception.Message);
                return;
            }
            catch (FechaPasadaException exception)
            {
                MessageBox.Show("Fecha no valida");
                return;
            }
            
            VolverAlMenuPrincipal();
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            textBox_Descripcion.Text = "";
            textBox_Precio.Text = "";
            textBox_Stock.Text = "";
            comboBox_Rubro.SelectedIndex = 0;
            comboBox_TiposDePublicacion.SelectedIndex = 0;
            comboBox_Estado.SelectedIndex = 0;
            comboBox_Visibilidad.SelectedIndex = 0;
            radioButton_Pregunta.Checked = true;
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            VolverAlMenuPrincipal();
        }

        private void VolverAlMenuPrincipal()
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void comboBox_tiposDePublicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            String tipoSeleccionado = comboBox_TiposDePublicacion.Text;
            if (tipoSeleccionado == "Compra Inmediata")
            {
                label_stock.Text = "Stock";
                label_precio.Text = "Precio por unidad";
            }
            else
            {
                label_stock.Text = "Cantidad";
                label_precio.Text = "Precio inicial";
            }
        }
    }
}
