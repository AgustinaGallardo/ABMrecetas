using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetaBack.dominio
{
    public class DetalleReceta
    {
        public Ingrediente Ingrediente { get; set; }
        public int Cantidad { get; set; }

        public DetalleReceta (Ingrediente ingrediente, int cantidad)
        {
            this.Ingrediente = ingrediente;
            this.Cantidad = cantidad;
        }
        public DetalleReceta()
        {
            this.Ingrediente = null;
            this.Cantidad = 0;
        }
        public override string ToString()
        {
            return "Cantidad:" + Cantidad;
        }
    }
}
