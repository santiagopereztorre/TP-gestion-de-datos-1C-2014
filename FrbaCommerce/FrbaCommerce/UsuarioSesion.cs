﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce
{
    class UsuarioSesion
    {
        public static UsuarioSesion usuario;
        public Decimal id { get; set; }
        public String rol { get; set; }
        public String nombre { get; set; }
        private UsuarioSesion() { }
        public static UsuarioSesion Usuario
        {
            get
            {
                if (usuario == null)
                {
                    usuario = new UsuarioSesion();
                }
                return usuario;
            }
        }

    }
}
