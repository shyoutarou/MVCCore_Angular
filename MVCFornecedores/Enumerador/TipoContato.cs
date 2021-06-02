using System.ComponentModel;

namespace MVCFornecedores.Enumerador
{
    public enum TipoContato
    {
        [Description("E-mail")]
        Email = 1,
        [Description("Telefone")]
        Telefone = 2,
        [Description("Celular")]
        Celular = 3,
        [Description("Chat")]
        Chat = 4,
        [Description("Rede Social")]
        RedeSocial = 5,
        [Description("Site")]
        Site = 6
    }
}