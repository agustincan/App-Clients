using Client.Persistence.Database;
using Client.Service.EventHandler.Command;
using Client.Service.Queries;
using Client.Service.Queries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;

namespace Client.Api.Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IClientQueries queryService;
        private readonly IMediator mediator;
        private readonly ILogger<ClientController> logger;

        public ClientController(AppDbContext context, IClientQueries queryService, IMediator mediator, ILogger<ClientController> logger)
        {
            this.context = context;
            this.queryService = queryService;
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<DataCollection<ClientDto>> GetAll(int page = 1, int take = 10)
        {
            return await queryService.GetAllAsync(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ClientDto> GetById(int id)
        {
            // executing queries using mediator pattern design CQRS command query segregation
            return await queryService.GetByIdAsync(id);
        }

        [HttpGet("name/{name}")]
        public async Task<DataCollection<ClientDto>> GetByName(string name)
        {
            // executing queries using mediator pattern design CQRS command query segregation
            return await queryService.GetByNameAsync(name);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientCreateCommand command)
        {
            try
            {
                // executing commands using mediator pattern design CQRS command query segregation
                var res = await mediator.Send(command);
                return Ok(res);
            }
            catch (Exception ex)
            {
                
                return BadRequest(new { Errors = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ClientUpdateCommand command)
        {
            try
            {
                logger.LogInformation($"trying to Update {command.Id} client id");
                var res = await mediator.Send(command);
                logger.LogInformation($"Updated {command.Id} client id");
                return Ok(res);
            }
            catch (Exception ex)
            {
                logger.LogError($"Error at Update client id {command.Id} : {ex.Message}");
                return BadRequest(new { Errors = ex.Message });
            }
        }
    }
}
