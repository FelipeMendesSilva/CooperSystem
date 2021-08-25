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
            var carros = _carroRepositorio.Listar(nome, origem);
            var modelos = _mapper.Map<IEnumerable<CarroModelo>>(carros);

            return Ok(modelos);
        }
        
        [HttpGet("{id}")]
        public IActionResult Detalhar(int id)
        {
            if (!_carroRepositorio.Existe(id)) { return NotFound(); }

            var carro = _carroRepositorio.Detalhar(id);
            var carroMod = _mapper.Map<CarroDetalheModelo>(carro);
            return Ok(carroMod); 
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] CarroAddModelo carroModelo)
        {
            var carro = _mapper.Map<Carro>(carroModelo);
            _carroRepositorio.Adicionar(carro);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] CarroEditModelo carroMod)
        {
            if (!_carroRepositorio.Existe(carroMod.CarroId)) { return NotFound(); }
            var carro = _mapper.Map<Carro>(carroMod);
           
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
