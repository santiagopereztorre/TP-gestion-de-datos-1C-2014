﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Exceptions;
using System.Data.SqlClient;

namespace FrbaCommerce.Objetos
{
    class Publicacion : Comunicable
    {
        private Decimal id;
        private String tipo;
        private String estado;
        private String descripcion;
        private String fechaDeInicio;
        private String fechaDeVencimiento;
        private Decimal idRubro;
        private Decimal idVisibilidad;
        private Decimal idUsuario;
        private String stock;
        private String precio;

        public void SetId(Decimal id)
        {
            this.id = id;
        }

        public Decimal GetId()
        {
            return this.id;
        }

        public void SetTipo(String tipo)
        {
            if (tipo == "")
                throw new CampoVacioException();
            this.tipo = tipo;
        }

        public String GetTipo()
        {
            return this.tipo;
        }

        public void SetEstado(String estado)
        {
            if (estado == "")
                throw new CampoVacioException();
            this.estado = estado;
        }

        public String GetEstado()
        {
            return this.estado;
        }

        public void SetDescripcion(String descripcion)
        {
            if (descripcion == "")
                throw new CampoVacioException();
            this.descripcion = descripcion;
        }

        public String GetDescripcion()
        {
            return this.descripcion;
        }

        public void SetFechaDeInicio(String fechaDeInicio)
        {
            if (fechaDeInicio == "")
                throw new CampoVacioException();
            this.fechaDeInicio = fechaDeInicio;
        }

        public String GetFechaDeInicio()
        {
            return this.fechaDeInicio;
        }

        public void SetFechaDeVencimiento(String fechaDeVencimiento)
        {
            if (fechaDeVencimiento == "")
                throw new CampoVacioException();
            this.fechaDeVencimiento = fechaDeVencimiento;
        }

        public String GetFechaDeVencimiento()
        {
            return this.fechaDeVencimiento;
        }

        public void SetIdRubro(Decimal idRubro)
        {
            this.idRubro = idRubro;
        }

        public Decimal GetIdRubro()
        {
            return this.idRubro;
        }

        public void SetIdUsuario(Decimal idUsuario)
        {
            this.idUsuario = idUsuario;
        }

        public Decimal GetIdUsuario()
        {
            return this.idUsuario;
        }

        public void SetIdVisibilidad(Decimal idVisibilidad)
        {
            this.idVisibilidad = idVisibilidad;
        }

        public Decimal GetIdVisibilidad()
        {
            return this.idVisibilidad;
        }

        public void SetStock(String stock)
        {
            if (stock == "")
                throw new CampoVacioException();
            this.stock = stock;
        }

        public String GetStock()
        {
            return this.stock;
        }

        public void SetPrecio(String precio)
        {
            if (precio == "")
                throw new CampoVacioException();
            this.precio = precio;
        }

        public String GetPrecio()
        {
            return this.precio;
        }


        #region Miembros de Comunicable

        string Comunicable.GetQueryCrear()
        {
            return "LOS_SUPER_AMIGOS.crear_publicacion";
        }

        IList<System.Data.SqlClient.SqlParameter> Comunicable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tipo", this.tipo));
            parametros.Add(new SqlParameter("@estado", this.estado));
            parametros.Add(new SqlParameter("@descripcion", this.descripcion));
            parametros.Add(new SqlParameter("@fecha_inicio", this.fechaDeInicio));
            parametros.Add(new SqlParameter("@fecha_vencimiento", this.fechaDeVencimiento));
            parametros.Add(new SqlParameter("@stock", this.stock));
            parametros.Add(new SqlParameter("@precio", this.precio));
            parametros.Add(new SqlParameter("@rubro_id", this.idRubro));
            parametros.Add(new SqlParameter("@visibilidad_id", this.idVisibilidad));
            parametros.Add(new SqlParameter("@usuario_id", this.idUsuario));
            return parametros;
        }

        string Comunicable.GetQueryModificar()
        {
            return "UPDATE LOS_SUPER_AMIGOS.Publicacion SET estado = @estado, descripcion = @descripcion, fecha_inicio = @fecha_inicio, fecha_vencimiento = @fecha_vencimiento, rubro_id = @rubro_id, visibilidad_id = @visibilidad_id, stock = @stock, precio = @precio WHERE id = @idPublicacion";
        }

        #endregion
    }
}
