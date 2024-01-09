using DevIO.API.DTOs;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.API.Controllers
{
    public class FornecedoresController : MainController
    {
        private readonly IFornecedorRepository _repository;
        private readonly IFornecedorService _service;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepository repository,
            IFornecedorService service,
            IMapper mapper)
        {
            _repository = repository;
            _service = service;
            _mapper = mapper;
        }
        [Route("api/fornecedores")]

        [HttpGet]
        public async Task<ActionResult<FornecedorDTO>> ObterTodos()
        {
            return _mapper.Map<FornecedorDTO>(await _repository.ObterTodos());
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FornecedorDTO>> ObterPorId(Guid id)
        {
            var fornecedor = await ObterFornecedorProdutosEndereco(id);

            return fornecedor == null ? NotFound() : fornecedor;
        }
        [HttpPost]
        public async Task<ActionResult<FornecedorDTO>> Adicionar(FornecedorDTO fornecedor)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _service.Adicionar(_mapper.Map<Fornecedor>(fornecedor));

            return CustomResponse();
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FornecedorDTO>> Atualizar(Guid id, FornecedorDTO fornecedor)
        {
            if (id != fornecedor.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _service.Atualizar(_mapper.Map<Fornecedor>(fornecedor));

            return CustomResponse(ModelState);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FornecedorDTO>> Excluir(Guid id)
        {
            await _service.Remover(id);

            return CustomResponse();
        }

        private async Task<FornecedorDTO> ObterFornecedorProdutosEndereco(Guid id)
        {
            return _mapper.Map<FornecedorDTO>(await _repository.ObterFornecedorProdutosEndereco(id));
        }
    }
}

