using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVCFornecedores.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFornecedores.Data.Repository
{
    public class DataRepository : IDataRepository
    {
        private readonly FornecedorContext _ctx;
        private readonly ILogger<DataRepository> _logger;

        public DataRepository(FornecedorContext ctx, ILogger<DataRepository> logger)
        {
            try
            {
                _ctx = ctx;
                _logger = logger;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro no Construtor: {ex}");
            }
        }

      
        public void Excluir<T>(T entity) where T : class
        {
            _logger.LogInformation($"Excluindo um objeto do tipo {entity.GetType()} do context.");
            _ctx.Remove(entity);
        }

        public void Adicionar<T>(T entity) where T : class
        {
            try
            {
                _logger.LogInformation($"Adicionando um objeto do tipo {entity.GetType()} do context.");
                _ctx.Add(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao Gravar: {ex}");
            }
        }


        public async Task<bool> SalvarAsync()
        {
            try
            {
                //SaveChanges Retorna o número de linhas alteradas
                return (await _ctx.SaveChangesAsync()) > 0; 
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao Salvar: {ex}");
                return false;
            }
        }

        public async Task<Empresa> EmpresaByIdAsync(int id)
        {
            return await _ctx.Empresas.Include(x=>x.Fornecedores).ThenInclude(x=>x.Contatos).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Empresa>> EmpresasAsync(bool includeItems)
        {
            return includeItems ? await _ctx.Empresas.Include("Fornecedores").OrderBy(p => p.NomeFantasia).ToListAsync() :
                 await _ctx.Empresas.OrderBy(p => p.NomeFantasia).ToListAsync();
        }

        public async Task<IEnumerable<Fornecedor>> FornecedoresAsync(Fornecedor fornecedor)
        {
            try
            {
                return await _ctx.Fornecedores
                            .Where(x => (fornecedor.Nome == null || x.Nome == fornecedor.Nome)
                            && (fornecedor.CPF_CNPJ == null || x.CPF_CNPJ == fornecedor.CPF_CNPJ)
                            && (fornecedor.DataCadastro == null || x.DataCadastro == fornecedor.DataCadastro))
                           .OrderBy(p => p.Nome)
                           .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar Fornecedores: {ex}");
                return null;
            }
        }


        public async Task<Fornecedor> FornecedorByIdAsync(int id)
        {
            return await _ctx.Fornecedores.Include(x => x.Contatos).FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
