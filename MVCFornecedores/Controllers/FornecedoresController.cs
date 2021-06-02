using MVCFornecedores.Services;
using MVCFornecedores.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using MVCFornecedores.Data;
using System.Linq;
using MVCFornecedores.Data.Repository;
using MVCFornecedores.Data.Entities;

namespace MVCFornecedores.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IFornecedorRepository _repository;

        public FornecedoresController(IMailService mailService, IFornecedorRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            //throw new InvalidProgramException("Bad call");
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(FornecedoresViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send the Email
                _mailService.SendMessage("shawn@wildermuth.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent...";
                ModelState.Clear();
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Lista()
        {
            var model = new FornecedoresViewModel();

            var fornecedor = new Fornecedor()
            {
                Nome = model.Nome,
                CPF_CNPJ = model.CPF_CNPJ,
                DataCadastro = model.DataCadastro 
            };

            model.Fornecedores = _repository.ListaFornecedores(fornecedor);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
