using CooperSystem.Dominio.Interfaces;
using CooperSystem.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using CooperSystem.Api.Modelos;

namespace CooperSystem.Api.Controllers
{
    [ApiController]
    [Route("api/marcas")]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaRepositorio _marcaRepositorio;
        private readonly IMapper _mapper;

        public MarcaController(IMarcaRepositorio marcaRepositorio, IMapper mapper)
        {
            _marcaRepositorio = marcaRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        //api/carros?nome=ABC&origem=ABC
        public IActionResult Listar(string nome, string origem)
        {
            var lista = _marcaRepositorio.Listar(nome, origem);
            var lista2  = new List<MarcaModelo>();
            foreach(Marca marca in lista)
            {
                var marcaMod = _mapper.Map<MarcaModelo>(marca);
                lista2.Add(marcaMod);
            }

            return Ok(lista2);
        }

        [HttpGet("{id}")]
        public IActionResult Detalhar(int id)
        {
            if (!_marcaRepositorio.Existe(id)) { return NotFound(); }

            var marca = _marcaRepositorio.Detalhar(id);
            var marcaModelo = _mapper.Map<MarcaModelo>(marca);
            return Ok(marcaModelo);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] MarcaModelo marcaModelo)
        {
            var marca = _mapper.Map<Marca>(marcaModelo);
            _marcaRepositorio.Adicionar(marca);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Marca marca)
        {
            if (!_marcaRepositorio.Existe(marca.MarcaId)) { return NotFound(); }

            _marcaRepositorio.Editar(marca);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            if (!_marcaRepositorio.Existe(id)) { return NotFound(); }

            var marca = _marcaRepositorio.Detalhar(id);
            _marcaRepositorio.Remover(marca);

            return NoContent();
        }
    }
}
