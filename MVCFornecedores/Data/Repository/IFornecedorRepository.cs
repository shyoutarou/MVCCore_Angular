using MVCFornecedores.Data.Entities;
using System.Collections.Generic;

namespace MVCFornecedores.Data.Repository
{
    public interface IFornecedorRepository
    {
        IEnumerable<Fornecedor> ListaFornecedores(Fornecedor fornecedor);

        void AdicionarFornecedores(object entity);
        bool Salvar();
    }
}