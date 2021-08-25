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
            var marcas = _marcaRepositorio.Listar(nome, origem);
            var modelos  =  _mapper.Map<IEnumerable<MarcaModelo>>(marcas);
            
            return Ok(modelos);
        }

        [HttpGet("{id}")]
        public IActionResult Detalhar(int id)
        {
            if (!_marcaRepositorio.Existe(id)) { return NotFound(); }

            var marca = _marcaRepositorio.Detalhar(id);
            var marcaDetalheModelo = _mapper.Map<MarcaDetalheModelo>(marca);
            return Ok(marcaDetalheModelo);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] MarcaAddModelo marcaModelo)
        {
            var marca = _mapper.Map<Marca>(marcaModelo);
            _marcaRepositorio.Adicionar(marca);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] MarcaEditModelo marcaMod)
        {
            if (!_marcaRepositorio.Existe(marcaMod.MarcaId)) { return NotFound(); }
            var marca = _mapper.Map<Marca>(marcaMod);
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
