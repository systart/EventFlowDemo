using EventFlow.Configuration;
using EventFlow.ReadStores;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace EventFlowDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataModelController : ControllerBase
    {
        private readonly IReadModelPopulator _readModelPopulator;

        public DataModelController(IResolver resolver)
        {
            _readModelPopulator = resolver.Resolve<IReadModelPopulator>();
        }

        [HttpPost]
        public async Task<ActionResult> ReplayEvents()
        {
            await _readModelPopulator.PopulateAsync<ExampleReadModel>(CancellationToken.None);

            return Accepted("Read models are replayed");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEvents()
        {
            await _readModelPopulator.PurgeAsync<ExampleReadModel>(CancellationToken.None);

            return Ok("Read models deleted");
        }
    }
}