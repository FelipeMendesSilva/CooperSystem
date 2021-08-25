using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CooperSystem.Dominio.Entidades
{
    public class Marca
    {
        
        public int MarcaId { get; set; }
        public string Origem { get; set; }
        public string Nome { get; set; }
        
        public ICollection<Carro> Carros { get; set; }
    }
}
