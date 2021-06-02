using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCFornecedores.Data.Entities;
using MVCFornecedores.Data.Repository;
using MVCFornecedores.Services;
using MVCFornecedores.ViewModels;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MVCFornecedores.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IDataRepository _repository;
        private readonly ILogger<AppController> _logger;
        private readonly IMapper _mapper;
        public AppController(IMailService mailService, IDataRepository repository, ILogger<AppController> logger, IMapper mapper)
        {
            _mailService = mailService;
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao entrar em Index: {ex}");
                throw new ApplicationException("Erro ao entrar em Index");
            }
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            try
            {
                //throw new InvalidProgramException("Bad call");
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao entrar em Contact: {ex}");
                throw new ApplicationException("Erro ao entrar em Contact");
            }
        }

        [HttpPost("contact")]
        public IActionResult Contact(FornecedoresViewModel model)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao entrar em Contact: {ex}");
                throw new ApplicationException("Erro ao entrar em Contact");
            }
        }

        public IActionResult About()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao entrar em About: {ex}");
                throw new ApplicationException("Erro ao entrar em About");
            }
        }

        public async Task<ActionResult<EmpresaViewModel>> Lista()
        {
            try
            {
                var results = await _repository.FornecedoresAsync(new Fornecedor());

                var model = new EmpresaViewModel();

                model.Fornecedores = await _repository.FornecedoresAsync(new Fornecedor());
                return View(model);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar Fornecedores: {ex}");
                throw new ApplicationException("Erro ao listar Fornecedores");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
