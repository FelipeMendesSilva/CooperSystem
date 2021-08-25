using AutoMapper;
using CooperSystem.Api.Modelos;
using CooperSystem.Dominio.Entidades;

namespace CooperSystem.Api.ProfileMapper
{
    public class MarcaProfile : Profile
    {
        public MarcaProfile()
        {
            CreateMap<Marca, MarcaModelo>();
            CreateMap<MarcaModelo, Marca>();

        }


    }
}

