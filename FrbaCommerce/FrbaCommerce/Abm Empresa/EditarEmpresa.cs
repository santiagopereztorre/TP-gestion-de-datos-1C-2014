﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaCommerce.Objetos;
using FrbaCommerce.Exceptions;

namespace FrbaCommerce.ABM_Empresa
{
    public partial class EditarEmpresa : Form
    {
        private Decimal idEmpresa;
        private Decimal idDireccion;
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();

        public EditarEmpresa(String idEmpresa)
        {
            InitializeComponent();
            this.idEmpresa = Convert.ToDecimal(idEmpresa);
        }

        private void EditarEmpresa_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            Empresa empresa = comunicador.ObtenerEmpresa(idEmpresa);

            this.idDireccion = empresa.GetIdDireccion();
            textBox_RazonSocial.Text = empresa.GetRazonSocial();
            textBox_NombreDeContacto.Text = empresa.GetNombreDeContacto();
            textBox_CUIT.Text = empresa.GetCuit();
            textBox_FechaDeCreacion.Text = Convert.ToString(empresa.GetFechaDeCreacion());
            textBox_Mail.Text = empresa.GetMail();
            textBox_Telefono.Text = empresa.GetTelefono();
            textBox_Ciudad.Text = empresa.GetCiudad();
            CargarDireccion(idDireccion);
            checkBox_Habilitado.Checked = Convert.ToBoolean(comunicador.SelectFromWhere("habilitado", "Empresa", "id", idEmpresa));
        }

        private void CargarDireccion(Decimal idDireccion)
        {
            Direccion direccion = comunicador.ObtenerDireccion(idDireccion);

            textBox_Calle.Text = direccion.GetCalle();
            textBox_Numero.Text = direccion.GetNumero();
            textBox_Piso.Text = direccion.GetPiso();
            textBox_Departamento.Text = direccion.GetDepartamento();
            textBox_CodigoPostal.Text = direccion.GetCodigoPostal();
            textBox_Localidad.Text = direccion.GetLocalidad();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
            String razonSocial = textBox_RazonSocial.Text;
            String nombreDeContacto = textBox_NombreDeContacto.Text;
            String cuit = textBox_CUIT.Text;
            DateTime fechaDeCreacion;
            DateTime.TryParse(textBox_FechaDeCreacion.Text, out fechaDeCreacion);
            String mail = textBox_Mail.Text;
            String telefono = textBox_Telefono.Text;
            String ciudad = textBox_Ciudad.Text;
            String calle = textBox_Calle.Text;
            String numero = textBox_Numero.Text;
            String piso = textBox_Piso.Text;
            String departamento = textBox_Departamento.Text;
            String codigoPostal = textBox_CodigoPostal.Text;
            String localidad = textBox_Localidad.Text;
            Boolean habilitado = checkBox_Habilitado.Checked;

            Boolean pudoModificar;

            // Update direccion
            Direccion direccion = new Direccion();
            try
            {
                direccion.SetCalle(calle);
                direccion.SetNumero(numero);
                direccion.SetPiso(piso);
                direccion.SetDepartamento(departamento);
                direccion.SetCodigoPostal(codigoPostal);
                direccion.SetLocalidad(localidad);
                comunicador.Modificar(idDireccion, direccion);
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

            // Update empresa
            try
            {
                Empresa empresa = new Empresa();
                empresa.SetRazonSocial(razonSocial);
                empresa.SetNombreDeContacto(nombreDeContacto);
                empresa.SetCuit(cuit);
                empresa.SetFechaDeCreacion(fechaDeCreacion);
                empresa.SetMail(mail);
                empresa.SetTelefono(telefono);
                empresa.SetCiudad(ciudad);
                empresa.SetHabilitado(habilitado);
                pudoModificar = comunicador.Modificar(idEmpresa, empresa);
                if (pudoModificar) MessageBox.Show("La empresa se modifico correctamente");
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
            catch (TelefonoYaExisteException exception)
            {
                MessageBox.Show("Telefono ya existe");
                return;
            }
            catch (CuitYaExisteException exception)
            {
                MessageBox.Show("Cuit ya existe");
                return;
            }
            catch (RazonSocialYaExisteException exception)
            {
                MessageBox.Show("RazonSocial ya existe");
                return;
            }
            catch (FechaPasadaException exception)
            {
                MessageBox.Show("Fecha no valida");
                return;
            }

            this.Close();
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_FechaDeCreacion_Click(object sender, EventArgs e)
        {
            monthCalendar_FechaDeCreacion.Visible = true;
        }

        private void monthCalendar_FechaDeCreacion_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            textBox_FechaDeCreacion.Text = e.Start.ToShortDateString();
            monthCalendar_FechaDeCreacion.Visible = false;
        }
    }
}
