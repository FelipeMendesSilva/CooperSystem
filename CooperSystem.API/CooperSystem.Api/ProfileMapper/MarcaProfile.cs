using AutoMapper;
using CooperSystem.Api.Modelos;
using CooperSystem.Dominio.Entidades;

namespace CooperSystem.Api.ProfileMapper
{
    public class MarcaProfile : Profile
    {
        public MarcaProfile()
        {
            CreateMap<Marca, MarcaDetalheModelo>();
            CreateMap<MarcaDetalheModelo, Marca>();

            CreateMap<Marca, MarcaModelo>();
            CreateMap<MarcaModelo, Marca>();

            CreateMap<Marca, MarcaAddModelo>();
            CreateMap<MarcaAddModelo, Marca>();

            CreateMap<Marca, MarcaEditModelo>();
            CreateMap<MarcaEditModelo, Marca>();
        }


    }
}

