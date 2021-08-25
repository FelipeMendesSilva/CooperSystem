using CooperSystem.Dominio.Interfaces;
using CooperSystem.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using CooperSystem.Api.Modelos;

namespace CooperSystem.Api.Controllers
{
    [ApiController]
    [Route("api/carros")]
    public class CarroController : ControllerBase
    {
        private readonly ICarroRepositorio _carroRepositorio;
        private readonly IMapper _mapper;

        public CarroController(ICarroRepositorio carroRepositorio, IMapper mapper)
        {
            _carroRepositorio = carroRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        //api/carros?nome=ABC&origem=ABC
        public IActionResult Listar(string nome, string origem)
        {
            var lista = _carroRepositorio.Listar(nome, origem);
            var lista2 = new List<Carro3ColModelo>();
            foreach (Carro carro in lista)
            {
                var carroMod = _mapper.Map<Carro3ColModelo>(carro);
                lista2.Add(carroMod);
            }

            return Ok(lista2);
        }
        
        [HttpGet("{id}")]
        public IActionResult Detalhar(int id)
        {
            if (!_carroRepositorio.Existe(id)) { return NotFound(); }

            var carro = _carroRepositorio.Detalhar(id);
            var carroMod = _mapper.Map<CarroModelo>(carro);
            return Ok(carroMod); 
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] CarroModelo carroModelo)
        {
            var carro = _mapper.Map<Carro>(carroModelo);
            _carroRepositorio.Adicionar(carro);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Carro carro)
        {
            if (!_carroRepositorio.Existe(carro.CarroId)) { return NotFound(); }

            _carroRepositorio.Editar(carro);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            if (!_carroRepositorio.Existe(id)) { return NotFound(); }

            var carro = _carroRepositorio.Detalhar(id);
            _carroRepositorio.Remover(carro);

            return NoContent();
        }
    }
}
