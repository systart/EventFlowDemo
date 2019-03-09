using EventFlow;
using EventFlow.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace EventFlowDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamplesController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryProcessor _queryProcessor;

        public ExamplesController(ICommandBus commandBus, IQueryProcessor queryProcessor)
        {
            _commandBus = commandBus;
            _queryProcessor = queryProcessor;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExampleReadModel>> GetExample(string id)
        {
            var readModel = await _queryProcessor.ProcessAsync(new ReadModelByIdQuery<ExampleReadModel>(id), CancellationToken.None);
            return Ok(readModel);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] int value)
        {
            var exampleCommand = new ExampleCommand(ExampleId.New, value);
            await _commandBus.PublishAsync(exampleCommand, CancellationToken.None);
            return CreatedAtAction(nameof(GetExample), new { id = exampleCommand.AggregateId.Value }, exampleCommand);
        }
    }
}