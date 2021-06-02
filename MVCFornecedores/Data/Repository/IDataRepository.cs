using MVCFornecedores.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCFornecedores.Data.Repository
{
    public interface IDataRepository
    {
        void Adicionar<T>(T entity) where T : class;
        void Excluir<T>(T entity) where T : class;
        Task<bool> SalvarAsync();

        Task<Empresa> EmpresaByIdAsync(int id);
        Task<IEnumerable<Empresa>> EmpresasAsync(bool includeItems);
        Task<Fornecedor> FornecedorByIdAsync(int id);
        Task<IEnumerable<Fornecedor>> FornecedoresAsync(Fornecedor fornecedor);

    }
}