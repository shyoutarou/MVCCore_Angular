using MVCFornecedores.Data.Entities;
using MVCFornecedores.Enumerador;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCFornecedores.ViewModels
{
    public class ContatoViewModel
    {
        public int? Id { get; set; }
        public int? FornecedorId { get; set; }

        [Required]
        public TipoContato Tipo_Contato { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Limite de 500 Caracteres")]
        public string Desc_Contato { get; set; }
    }
}
