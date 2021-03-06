﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class VerPublicacion : Form
    {
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        public Object SelectedItem { get; set; }        
        private String tipoPublicacion;
        private int publicacionId;
        private Decimal vendedorId;

        public VerPublicacion(int idPublicacion)
        {
            InitializeComponent();            
            publicacionId = idPublicacion;
            pedirTipoEstadoDescripcion();
        }

        private void ComprarOfertar_Load(object sender, EventArgs e)
        {
            pedirVendedor();
            pedirRubro();
            pedirVencimientoPreguntas();
            pedirStock();                        
            pedirPrecio();
            pedirAccion();            
        }

        private void pedirTipoEstadoDescripcion()
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", publicacionId));

            String query = "SELECT * FROM LOS_SUPER_AMIGOS.Publicacion WHERE id = @id";            
            
            SqlDataReader reader = builderDeComandos.Crear(query, parametros).ExecuteReader();
            reader.Read();
            Decimal idEstado = (Decimal)reader["estado_id"];
            String estado = (String) comunicador.SelectFromWhere("descripcion", "Estado", "id", idEstado);
            if (estado == "Pausada")
            {
                botonComprarOfertar.Enabled = false;
                MessageBox.Show("La publicación se encuentra pausada y no se pueden realizar compras/ofertas");
            }
            labelProductoDatos.Text = (String)reader["descripcion"];
            Decimal idTipoPublicacion = (Decimal)reader["tipo_id"];
            tipoPublicacion = (String)comunicador.SelectFromWhere("descripcion", "TipoDePublicacion", "id", idTipoPublicacion);
        }

        private void pedirVendedor()
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", publicacionId));            

            String query = "SELECT * FROM LOS_SUPER_AMIGOS.Usuario WHERE id = (SELECT usuario_id FROM LOS_SUPER_AMIGOS.Publicacion WHERE id = @id)";

            SqlDataReader reader = builderDeComandos.Crear(query, parametros).ExecuteReader();
            reader.Read();
            vendedorId = (Decimal)reader["id"];
            labelVendedorDatos.Text = (String)reader["username"];            
        }

        private void pedirRubro()
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", publicacionId));

            String query = "SELECT * FROM LOS_SUPER_AMIGOS.Rubro WHERE id = (SELECT rubro_id FROM LOS_SUPER_AMIGOS.Publicacion WHERE id = @id)";

            SqlDataReader reader = builderDeComandos.Crear(query, parametros).ExecuteReader();
            reader.Read();
            labelRubroDatos.Text = (String)reader["descripcion"];
        }

        private void pedirVencimientoPreguntas()
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", publicacionId));

            String query = "SELECT * FROM LOS_SUPER_AMIGOS.Publicacion WHERE id = @id";

            SqlDataReader reader = builderDeComandos.Crear(query, parametros).ExecuteReader();
            reader.Read();
            labelVencimientoDatos.Text = ( (DateTime)reader["fecha_vencimiento"] ).ToString();
            
            if ((bool)reader["se_realizan_preguntas"] == false)
            {
                botonPreguntar.Enabled = false;
            }            
        }

        private void pedirStock()
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", publicacionId));

            if (tipoPublicacion == "Subasta")
            {
                String querySubasta = "SELECT * FROM LOS_SUPER_AMIGOS.Publicacion WHERE id = @id";
                SqlDataReader readerSubasta = builderDeComandos.Crear(querySubasta, parametros).ExecuteReader();
                readerSubasta.Read();
                labelStockDatos.Text = ((Decimal)readerSubasta["stock"]).ToString();
            }
            else
            {
                String queryCompra = "SELECT * FROM LOS_SUPER_AMIGOS.Publicacion WHERE id = @id";
                SqlDataReader readerCompra = builderDeComandos.Crear(queryCompra, parametros).ExecuteReader();
                readerCompra.Read();
                Decimal stockInicial = (Decimal)readerCompra["stock"];

                parametros.Clear();
                parametros.Add(new SqlParameter("@id", publicacionId));
                String queryVista = "SELECT * FROM LOS_SUPER_AMIGOS.VistaCantidadVendida WHERE publicacion_id = @id";
                SqlDataReader readerVista = builderDeComandos.Crear(queryVista, parametros).ExecuteReader();
                
                if (readerVista.Read())
                {
                    labelStockDatos.Text = (stockInicial - (Decimal)readerVista["cant_vendida"]).ToString();
                }
                else
                {                    
                    labelStockDatos.Text = stockInicial.ToString();
                }
            }
        }

        private void pedirPrecio()
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", publicacionId));

            if (tipoPublicacion == "Compra Inmediata")
            {
                String queryCompra = "SELECT * FROM LOS_SUPER_AMIGOS.Publicacion WHERE id = @id";
                SqlDataReader readerCompra = builderDeComandos.Crear(queryCompra, parametros).ExecuteReader();
                readerCompra.Read();
                labelPrecioDatos.Text = ( (Decimal)readerCompra["precio"] ).ToString();
            }
            else
            {                
                String queryVista = "SELECT * FROM LOS_SUPER_AMIGOS.VistaOfertaMax WHERE publicacion_id = @id";
                SqlDataReader readerVista = builderDeComandos.Crear(queryVista, parametros).ExecuteReader();
                if (readerVista.Read())
                {
                    labelPrecioDatos.Text = ((Decimal)readerVista["precioMax"]).ToString();
                }
                else
                {
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@id", publicacionId));
                    String queryOferta = "SELECT * FROM LOS_SUPER_AMIGOS.Publicacion WHERE id = @id";
                    SqlDataReader readerOferta = builderDeComandos.Crear(queryOferta, parametros).ExecuteReader();
                    readerOferta.Read();
                    labelPrecioDatos.Text = ((Decimal)readerOferta["precio"]).ToString();
                }
            }
        }

        private void pedirAccion()
        {
            if (tipoPublicacion == "Compra Inmediata")
            {
                botonComprarOfertar.Text = "Comprar";
            }
            else
            {
                botonComprarOfertar.Text = "Ofertar";
            }
        }               

        private void botonComprarOfertar_Click(object sender, EventArgs e)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@user", UsuarioSesion.Usuario.id));
            String query = "select COUNT(*) from LOS_SUPER_AMIGOS.Compra c "
                + "where isnull(c.calificacion_id,0)=0 and c.usuario_id = @user";
            Decimal cantidad = Convert.ToDecimal(builderDeComandos.Crear(query, parametros).ExecuteScalar());

            if (cantidad >= 5)
            {
                MessageBox.Show("Tiene 5 compras sin haber calificado al vendedor. No puede realizar más compras hasta que no califique.");
                return;
            }

            if (tipoPublicacion == "Compra Inmediata")
            {                
                this.Hide();
                new Comprar(vendedorId, publicacionId, Convert.ToInt32(labelStockDatos.Text)).ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                new Ofertar(Convert.ToInt32(labelPrecioDatos.Text),publicacionId).ShowDialog();
                this.Close();
            }
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new BuscadorPublicaciones().ShowDialog();
            this.Close();
        }

        private void botonPreguntar_Click(object sender, EventArgs e)
        {
            new Preguntar(publicacionId).ShowDialog();
        }
    }
}
