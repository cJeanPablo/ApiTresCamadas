using DevIO.API.DTOs;
using DevIO.Business.Models;
using Mapster;

namespace DevIO.API.Configurations
{
    public class MapperConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Fornecedor, FornecedorDTO>().TwoWays();
            config.NewConfig<Endereco, EnderecoDTO>().TwoWays();
            config.NewConfig<ProdutoDTO, Produto>();
            config.NewConfig<Produto, ProdutoDTO>()
                .Map(dest => dest.NomeFornecedor, src => src.Fornecedor.Nome);
           
        }


    }
}
