using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCFornecedores.Data.Entities;
using MVCFornecedores.Data.Repository;
using MVCFornecedores.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCFornecedores.Controllers
{
    [Route("api/[Controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IDataRepository _repository;
        private readonly ILogger<EmpresaController> _logger;
        private readonly IMapper _mapper;

        public EmpresaController(IDataRepository repository, ILogger<EmpresaController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaViewModel>>> Get(bool includeItems = true)
        {
            try
            {
                var results = await _repository.EmpresasAsync(includeItems);

                var mapresults = _mapper.Map<IEnumerable<EmpresaViewModel>>(results);

                return Ok(mapresults);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar Empresas: {ex}");
                return BadRequest($"Erro ao listar Empresas");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmpresaViewModel>> Get(int id)
        {
            try
            {
                var empresa = await _repository.EmpresaByIdAsync(id);
                if (empresa != null) return Ok(_mapper.Map<EmpresaViewModel>(empresa));
                else return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao recuperar : {ex}");
                return BadRequest($"Erro ao listar ");
            }
        }

        [HttpPost]
        public async Task<ActionResult<EmpresaViewModel>> Post([FromBody] EmpresaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newEmpresa = _mapper.Map<Empresa>(model);

                    _repository.Adicionar(newEmpresa);
                    if (await _repository.SalvarAsync())
                    {
                        return Created($"/api/empresa/{newEmpresa.Id}", _mapper.Map<EmpresaViewModel>(newEmpresa));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao salvar: {ex}");
            }

            return BadRequest("Erro ao salvar.");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var empresa = _repository.EmpresaByIdAsync(id);
                if (empresa != null) return NotFound();

                _repository.Excluir(empresa);

                if (await _repository.SalvarAsync())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao Excluir : {ex}");
            }

            return BadRequest($"Erro ao Excluir");
        }
    }
}
