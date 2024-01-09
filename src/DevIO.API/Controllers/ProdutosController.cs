using DevIO.API.DTOs;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace DevIO.API.Controllers
{
    [Route("api/produtos")]
    public class ProdutosController : MainController
    {
        private readonly IProdutoRepository _repository;
        private readonly IProdutoService _service;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository repository,
            IProdutoService service,
            IMapper mapper,
            INotificador notificador) : base (notificador)
        {
            _repository = repository;
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<ProdutoDTO>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoDTO>>(await _repository.ObterProdutosFornecedores());
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoDTO>> ObterPorId(Guid id)
        {
            ProdutoDTO dto = await ObterProduto(id);

            return dto == null ? NotFound() : dto;
        }
        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Adicionar(ProdutoDTO produto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _service.Adicionar(_mapper.Map<Produto>(produto));

            return CustomResponse(HttpStatusCode.Created);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProdutoDTO>> Atualizar(Guid id, ProdutoDTO produto)
        {
            if (id != produto.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }
             
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var produtoAtualizacao = await ObterProduto(id);

            produtoAtualizacao.FornecedorId = produto.Id;
            produtoAtualizacao.Nome = produto.Nome;
            produtoAtualizacao.Descricao = produto.Descricao;
            produtoAtualizacao.Valor = produto.Valor;
            produtoAtualizacao.Ativo = produto.Ativo;

            await _service.Atualizar(_mapper.Map<Produto>(produtoAtualizacao));

            return CustomResponse(HttpStatusCode.NoContent);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoDTO>> Excluir(Guid id)
        {
            var produto = await ObterProduto(id);

            if (produto == null) return NotFound();

            await _service.Remover(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }

        private async Task<ProdutoDTO> ObterProduto(Guid id)
        {
            return _mapper.Map<ProdutoDTO>(_repository.ObterPorId(id));
        }
    }
}
