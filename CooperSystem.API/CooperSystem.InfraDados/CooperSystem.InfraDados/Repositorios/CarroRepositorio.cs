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
    public class CarroRepositorio: ICarroRepositorio
    {
        private readonly DbContexto _dbContexto;
        public CarroRepositorio(DbContexto db)
        {
            _dbContexto = db;
        }

        public void Adicionar(Carro carro)
        {
            
                _dbContexto.Carros.Add(carro);
                _dbContexto.SaveChanges();
            

        }

        public void Editar(Carro carro)
        {
            Carro carroMemoria = _dbContexto.Carros.Find(carro.CarroId);
            if (carroMemoria != null)
            _dbContexto.Entry(carroMemoria).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
           
            _dbContexto.Update(carro);
            _dbContexto.SaveChanges();

        }

        public void Remover(Carro carro)
        {
            _dbContexto.Carros.Remove(carro);
            _dbContexto.SaveChanges();
        }

        public List<Carro> Listar(string nome = null, string origem = null)
        {
            // List<CarroLista> carros = (from p in _dbContexto.Carros
            //                            select new CarroLista { Nome = p.Nome, MarcaOrigem = p.MarcaOrigem, Ano = p.Ano })
            //             .OrderBy(c => c.Nome)
            //             .ToList();
            IQueryable<Carro> carros = _dbContexto.Carros;

            if (!string.IsNullOrWhiteSpace(origem))
                carros = carros.Where(c => c.Origem == origem);

            if (!string.IsNullOrWhiteSpace(nome))
                carros = carros.Where(c => c.Nome.Contains(nome));

            return carros.ToList();
        }
        
        public Carro Detalhar(int id)
        {

            return _dbContexto.Carros.Include(c => c.Marca).FirstOrDefault(c => c.CarroId == id);
        }

        
        public bool Existe(int id)
        {
            if (_dbContexto.Carros.Find(id) != null) { return true; }
            else return false;
        }
    }
}

