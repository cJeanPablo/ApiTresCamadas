using DevIO.API.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace DevIO.API.Controllers
{
    [Route("api/produtos")]
    public class ProdutosController
    {
        [HttpGet]
        public async Task<ActionResult<ProdutoDTO>> ObterTodos()
        {

        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoDTO>> ObterPorId(Guid id)
        {

        }
        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Adicionar(ProdutoDTO produto)
        {

        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProdutoDTO>> Atualizar(Guid id, ProdutoDTO produto)
        {

        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoDTO>> Excluir(Guid id)
        {

        }
    }
}
