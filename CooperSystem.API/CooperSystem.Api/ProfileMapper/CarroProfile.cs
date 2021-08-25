using AutoMapper;
using CooperSystem.Api.Modelos;
using CooperSystem.Dominio.Entidades;

namespace CooperSystem.Api.ProfileMapper
{
    public class CarroProfile : Profile
    {
        public CarroProfile()
        {
            CreateMap<Carro,CarroModelo>();
            CreateMap<CarroModelo, Carro>();

            //Perfil modelo 3 colunas
            CreateMap<Carro, Carro3ColModelo>();
            CreateMap<Carro3ColModelo, Carro>();

        }

        
    }
}
