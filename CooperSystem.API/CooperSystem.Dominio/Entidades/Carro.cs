using System;

namespace CooperSystem.Dominio.Entidades
{
    public class Carro
    {
       
        public int CarroId { get; set; }
        public string Nome { get; set; }
        public int KmPorGalao { get; set; }
        public int Cilindros { get; set; }
        public int CavaloDeForca { get; set; }
        public int Peso { get; set; }
        public int Aceleracao { get; set; }
        public DateTime Ano { get; set; }
        public string Origem { get; set; }

        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        
    }
}
