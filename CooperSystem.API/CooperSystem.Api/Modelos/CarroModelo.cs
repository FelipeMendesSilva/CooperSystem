using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperSystem.Api.Modelos
{
    public class CarroModelo
    {
        public string Nome { get; set; }
        public int KmPorGalao { get; set; }
        public int Cilindros { get; set; }
        public int CavaloDeForca { get; set; }
        public int Peso { get; set; }
        public int Aceleracao { get; set; }
        public DateTime Ano { get; set; }
        public string Origem { get; set; }

        public int MarcaId { get; set; }


    }
}
