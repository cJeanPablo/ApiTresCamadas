using DevIO.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.API.Controllers
{
    public class FornecedorController
    {
        [Route("api/fornecedores")]
        public class ProdutosController
        {
            [HttpGet]
            public async Task<ActionResult<FornecedorDTO>> ObterTodos()
            {

            }
            [HttpGet("{id:guid}")]
            public async Task<ActionResult<FornecedorDTO>> ObterPorId(Guid id)
            {

            }
            [HttpPost]
            public async Task<ActionResult<FornecedorDTO>> Adicionar(FornecedorDTO produto)
            {

            }
            [HttpPut("{id:guid}")]
            public async Task<ActionResult<FornecedorDTO>> Atualizar(Guid id, FornecedorDTO produto)
            {

            }
            [HttpDelete("{id:guid}")]
            public async Task<ActionResult<FornecedorDTO>> Excluir(Guid id)
            {

            }
        }
}
