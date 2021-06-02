using Microsoft.Extensions.Logging;
using MVCFornecedores.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCFornecedores.Data.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly FornecedorContext _ctx;
        private readonly ILogger<FornecedorRepository> _logger;

        public FornecedorRepository(FornecedorContext ctx, ILogger<FornecedorRepository> logger)
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

        public IEnumerable<Fornecedor> ListaFornecedores(Fornecedor fornecedor)
        {
            try
            {
                _logger.LogInformation("ListaFornecedores was called...");

                return _ctx.Fornecedores
                            .Where(x => (fornecedor.Nome == null || x.Nome == fornecedor.Nome)
                            && (fornecedor.CPF_CNPJ == null || x.CPF_CNPJ == fornecedor.CPF_CNPJ)
                            && (fornecedor.DataCadastro == null || x.DataCadastro == fornecedor.DataCadastro))
                           .OrderBy(p => p.Nome)
                           .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar Fornecedores: {ex}");
                return null;
            }
        }

        public void AdicionarFornecedores(object entity)
        {
            try
            {
                _ctx.Add(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao Gravar: {ex}");
            }
        }

        public bool Salvar()
        {
            try
            {
                //SaveChanges Retorna o número de linhas alteradas
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao Salvar: {ex}");
                return false;
            }
        }
    }
}
