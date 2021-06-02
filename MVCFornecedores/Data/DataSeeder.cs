using Microsoft.AspNetCore.Hosting;
using MVCFornecedores.Data.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace MVCFornecedores.Data
{
    public class DataSeeder
    {
        private readonly FornecedorContext _ctx;
        private readonly IWebHostEnvironment _hosting;

        public DataSeeder(FornecedorContext ctx, IWebHostEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Fornecedores.Any())
            {
                // Need to create the Sample Data
                var file = Path.Combine(_hosting.ContentRootPath, "Data/dados.json");
                var json = File.ReadAllText(file);
                var fornecedores = JsonSerializer.Deserialize<IEnumerable<Fornecedor>>(json);

                var fornecedor = _ctx.Fornecedores.FirstOrDefault();
                if (fornecedor != null)
                {
                    fornecedor.Contatos = new List<Contato>()
                                          {
                                            new Contato()
                                            {
                                                 Tipo_Contato = Enumerador.TipoContato.Telefone,
                                                 Desc_Contato = "(68) 3774-0468"
                                            },
                                            new Contato()
                                            {
                                                 Tipo_Contato = Enumerador.TipoContato.Celular,
                                                 Desc_Contato = "(68) 99877-7620"
                                            }
                                          };

                }

                var empresa = new Empresa()
                {
                    NomeFantasia = "Bludata",
                    CNPJ = "77854081000111",
                    UF = "SP",
                    Fornecedores = fornecedores.ToList()
                };

                _ctx.Empresas.Add(empresa);

                _ctx.SaveChanges();
            }
        }
    }
}
