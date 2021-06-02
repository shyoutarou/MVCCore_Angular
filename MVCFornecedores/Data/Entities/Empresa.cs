using System.Collections.Generic;

namespace MVCFornecedores.Data.Entities
{
    public class Empresa
    {
        public int Id { get; set; }
        public string UF { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }

        public ICollection<Fornecedor> Fornecedores { get; set; }
    }
}