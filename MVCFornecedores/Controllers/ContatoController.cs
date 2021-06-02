using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCFornecedores.Data.Repository;

namespace MVCFornecedores.Controllers
{
    [Route("api/orders/{orderId}/items")]
    public class ContatoController : ControllerBase
    {
        private readonly IDataRepository _repository;
        private readonly ILogger<ContatoController> _logger;
        private readonly IMapper _mapper;

        public  ContatoController(IDataRepository repository, ILogger<ContatoController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
    }
}
