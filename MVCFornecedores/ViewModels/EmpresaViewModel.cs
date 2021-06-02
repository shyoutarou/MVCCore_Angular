using MVCFornecedores.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCFornecedores.ViewModels
{
    public class EmpresaViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string UF { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Limite de 500 Caracteres")]
        public string NomeFantasia { get; set; }

        [Required]
        public string CNPJ { get; set; }

        public DateTime? DataCadastro { get; set; }

        public IEnumerable<Fornecedor> Fornecedores { get; set; }
    }
}
