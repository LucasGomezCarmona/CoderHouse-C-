﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    internal class Producto
    {
        public long Id { get; set; }
        public string Descripciones { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public long IdUsuario { get; set; }


    }
}
