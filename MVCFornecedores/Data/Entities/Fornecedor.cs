using MVCFornecedores.ViewModels;
using System;
using System.Collections.Generic;

namespace MVCFornecedores.Data.Entities
{
    public class Fornecedor
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string CPF_CNPJ { get; set; }

        public Empresa Empresa { get; set; }

        public string RG { get; set; }

        public DateTime? DataCadastro { get; set; }

        public DateTime? DataNascimento{ get; set; }

        public ICollection<Contato> Contatos { get; set; }
    }
}