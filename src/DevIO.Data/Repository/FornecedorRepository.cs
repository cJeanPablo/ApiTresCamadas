using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(SqlDbContext db) : base(db)
        {
        }
        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(x => x.Endereco)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(x => x.Produtos)
                .Include(x => x.Endereco)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid id)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(x => x.FornecedorId == id);
        }

        public async Task RemoverEnderecoFornecedor(Endereco endereco)
        {
            Db.Enderecos.Remove(endereco);
            await SaveChanges();
        }
    }
}
