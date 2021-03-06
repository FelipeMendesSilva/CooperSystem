using CooperSystem.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperSystem.Api.Modelos
{
    public class CarroDetalheModelo
    {
        public int CarroId { get; set; }
        public string Nome { get; set; }
        public int KmPorGalao { get; set; }
        public int Cilindros { get; set; }
        public int CavaloDeForca { get; set; }
        public int Peso { get; set; }
        public int Aceleracao { get; set; }
        public int Ano { get; set; }
        public string Origem { get; set; }

        public int MarcaId { get; set; }
        public MarcaModelo Marca { get; set; }

    }
}
