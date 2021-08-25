using CooperSystem.Dominio.Entidades;
using CooperSystem.Dominio.Interfaces;
using CooperSystem.InfraDados.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperSystem.InfraDados.Repositorios
{
    public class MarcaRepositorio : IMarcaRepositorio
    {
        private readonly DbContexto _dbContexto;
        public MarcaRepositorio(DbContexto db)
        {
            _dbContexto = db;
        }
        public void Adicionar(Marca marca)
        {           
                _dbContexto.Marcas.Add(marca);
                _dbContexto.SaveChanges();
            
        }

        public void Editar(Marca marca)
        {
            Marca marcaMemoria = _dbContexto.Marcas.Find(marca.MarcaId);
            if(marcaMemoria != null)
            _dbContexto.Entry(marcaMemoria).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            _dbContexto.Update(marca);
            _dbContexto.SaveChanges();

        }

        public List<Marca> Listar(string nome = null, string origem = null)
        {
            IQueryable<Marca> marcas = _dbContexto.Marcas;

            if (!string.IsNullOrWhiteSpace(origem))
                marcas = marcas.Where(c => c.Origem == origem);

            if (!string.IsNullOrWhiteSpace(nome))
                marcas = marcas.Where(c => c.Nome.Contains(nome));

            return marcas.ToList();
        }


        public Marca Detalhar(int id)
        {
            return _dbContexto.Marcas.Include(m => m.Carros).FirstOrDefault(c => c.MarcaId == id);
        }
        public void Remover(Marca marca)
        {
            _dbContexto.Marcas.Remove(marca);
            _dbContexto.SaveChanges();
        }
        
        public bool Existe(int id)
        {
            if (_dbContexto.Marcas.Find(id) != null) { return true; }
            else return false;
        }

    }
}
