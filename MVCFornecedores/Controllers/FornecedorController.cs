using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCFornecedores.Data.Entities;
using MVCFornecedores.Data.Repository;
using MVCFornecedores.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFornecedores.Controllers
{
    [Route("api/empresa/{empresaid}/fornecedores")]
    [ApiController]
    [Produces("application/json")]
    public class FornecedorController : ControllerBase
    {
        private readonly IDataRepository _repository;
        private readonly ILogger<FornecedorController> _logger;
        private readonly IMapper _mapper;

        public FornecedorController(IDataRepository repository, ILogger<FornecedorController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<FornecedoresViewModel>> Get(int empresaid)
        {
            try
            {
                var empresa = await _repository.EmpresaByIdAsync(empresaid);
                if (empresa != null) return Ok(_mapper.Map<IEnumerable<FornecedoresViewModel>>(empresa.Fornecedores));
                else return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar Fornecedores: {ex}");
                return BadRequest($"Erro ao listar Fornecedores");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<FornecedoresViewModel>> Get(int empresaid, int id)
        {
            try
            {
                var empresa = await _repository.EmpresaByIdAsync(empresaid);
                if (empresa != null)
                {
                    var fornecedor = empresa.Fornecedores.FirstOrDefault(o => o.Id == id);
                    return Ok(_mapper.Map<FornecedoresViewModel>(fornecedor));
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar Fornecedores: {ex}");
                return BadRequest($"Erro ao listar Fornecedores");
            }
        }


        [HttpPost]
        public async Task<ActionResult<FornecedoresViewModel>> Post([FromBody] FornecedoresViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newFornecedor = _mapper.Map<Fornecedor>(model);

                    _repository.Adicionar(newFornecedor);
                    if (await _repository.SalvarAsync())
                    {
                        return Created($"/api/empresa/{newFornecedor.Empresa.Id}/fornecedores/{newFornecedor.Id}", _mapper.Map<FornecedoresViewModel>(newFornecedor));
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
                var fornecedor = _repository.FornecedorByIdAsync(id);
                if (fornecedor != null) return NotFound();

                _repository.Excluir(fornecedor);

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
