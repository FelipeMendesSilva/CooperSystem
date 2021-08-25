using CooperSystem.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooperSystem.Dominio.Interfaces
{
    public interface IMarcaRepositorio
    {

        public void Adicionar(Marca marca);

        public void Editar(Marca marca);

        public void Remover(Marca marca);
        public List<Marca> Listar(string nome = null, string origem = null);

        public Marca Detalhar(int id);
        public bool Existe(int id);
    }
}
