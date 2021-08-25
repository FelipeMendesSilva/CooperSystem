using CooperSystem.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooperSystem.Dominio.Interfaces
{
    public interface ICarroRepositorio
    {
        public void Adicionar(Carro carro);

        public void Editar(Carro carro);

        public void Remover(Carro carro);
        public List<Carro> Listar(string nome = null, string origem = null);

        public Carro Detalhar(int id);

        public bool Existe(int id);

    }
}
