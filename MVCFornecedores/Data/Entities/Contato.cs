using MVCFornecedores.Enumerador;

namespace MVCFornecedores.Data.Entities
{
    public class Contato
    {
        public int Id { get; set; }
        public TipoContato Tipo_Contato { get; set; }
        public string Desc_Contato { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }
}