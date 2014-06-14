﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FrbaCommerce.Objetos
{
    interface Comunicable
    {
        String GetQueryCrear();
        String GetQueryModificar();
        
        IList<SqlParameter> GetParametros();
    }
}
