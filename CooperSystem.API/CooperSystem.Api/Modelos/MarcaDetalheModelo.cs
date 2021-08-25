using CooperSystem.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperSystem.Api.Modelos
{
    public class MarcaDetalheModelo
    {
        public int MarcaId { get; set; }
        public string Origem { get; set; }
        public string Nome { get; set; }

        public ICollection<CarroModelo> Carros { get; set; }
    }
}
