using AutoMapper;
using CooperSystem.Api.Modelos;
using CooperSystem.Dominio.Entidades;

namespace CooperSystem.Api.ProfileMapper
{
    public class CarroProfile : Profile
    {
        public CarroProfile()
        {
            CreateMap<Carro,CarroDetalheModelo>();
            CreateMap<CarroDetalheModelo, Carro>();

            //Perfil modelo 3 colunas
            CreateMap<Carro, CarroModelo>();
            CreateMap<CarroModelo, Carro>();

            CreateMap<Carro, CarroAddModelo>();
            CreateMap<CarroAddModelo, Carro>();

            CreateMap<Carro, CarroEditModelo>();
            CreateMap<CarroEditModelo, Carro>();
        }

        
    }
}
