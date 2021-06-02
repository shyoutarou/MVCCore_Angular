using MVCFornecedores.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCFornecedores.ViewModels
{
    public class FornecedoresViewModel
    {
        public int Id_Fornecedor { get; set; }
        public int Id_Empresa { get; set; }

        public string Nome { get; set; }
        public string CPF_CNPJ { get; set; }

        public string RG { get; set; }

        public DateTime? DataCadastro { get; set; }

        public DateTime? DataNascimento { get; set; }

        public IEnumerable<Fornecedor> Fornecedores { get; set; }
        public IEnumerable<Contato> Contatos { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Limite de 250 Caracteres")]
        public string Message { get; set; }
    }
}
