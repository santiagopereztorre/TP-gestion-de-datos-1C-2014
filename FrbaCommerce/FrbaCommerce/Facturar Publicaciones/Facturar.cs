﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Facturar_Publicaciones
{
    public partial class Facturar : Form
    {
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();
        private SqlCommand command;
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        int cantidadMin;
        int cantidadMax;

        public Facturar()
        {
            InitializeComponent();
        }

        private void Facturar_Load(object sender, EventArgs e)
        {
           CargarCostosPublicacionPorFacturar();
           CargarComisionesVentasPorFacturar();  
        }

        private void CargarCostosPublicacionPorFacturar()
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", UsuarioSesion.Usuario.id));

            String cantidadCostos = "select COUNT(p.id) from LOS_SUPER_AMIGOS.Publicacion p,"
            + " LOS_SUPER_AMIGOS.Visibilidad v, LOS_SUPER_AMIGOS.Usuario u"
            + " where p.usuario_id = u.id and u.id = @id and p.visibilidad_id = v.id"
            + " and p.costo_pagado = 0 and p.estado = 'Finalizada'";

            int cantidad  = (int)builderDeComandos.Crear(cantidadCostos, parametros).ExecuteScalar();

            labelCantidadCostos.Text = cantidad.ToString();
        }

        private void CargarComisionesVentasPorFacturar()
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", UsuarioSesion.Usuario.id));

            String cantidadMinimaComisiones = "select COUNT(c.id) from LOS_SUPER_AMIGOS.Usuario u,"
             + " LOS_SUPER_AMIGOS.Compra c, LOS_SUPER_AMIGOS.Publicacion p"
             + " where u.id = @id and p.usuario_id = u.id and c.publicacion_id = p.id"
             + " and c.facturada = 0 and p.estado = 'Finalizada'";

            cantidadMin = (int)builderDeComandos.Crear(cantidadMinimaComisiones, parametros).ExecuteScalar();

            parametros.Clear();
            parametros.Add(new SqlParameter("@id", UsuarioSesion.Usuario.id));

            String cantidadMaximaComisiones = "select COUNT(c.id) from LOS_SUPER_AMIGOS.Usuario u,"
             + " LOS_SUPER_AMIGOS.Compra c, LOS_SUPER_AMIGOS.Publicacion p"
             + " where u.id = @id and p.usuario_id = u.id and c.publicacion_id = p.id"
             + " and c.facturada = 0";

            cantidadMax = (int)builderDeComandos.Crear(cantidadMaximaComisiones, parametros).ExecuteScalar();

            dropDownFacturar.Text = cantidadMin.ToString();
            labelMinimo.Text = cantidadMin.ToString();
            labelMaximo.Text = cantidadMax.ToString();
            while (cantidadMax >= cantidadMin)
            {
                dropDownFacturar.Items.Add(cantidadMax);
                cantidadMax--;
            }
        }

        private void botonFacturar_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

    }
}
