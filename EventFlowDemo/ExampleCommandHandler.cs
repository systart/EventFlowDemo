using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace EventFlowDemo
{
    public class ExampleCommandHandler : CommandHandler<ExampleAggregate, ExampleId, IExecutionResult, ExampleCommand>
    {
        public override Task<IExecutionResult> ExecuteCommandAsync(
            ExampleAggregate aggregate,
            ExampleCommand command,
            CancellationToken cancellationToken)
        {
            var executionResult = aggregate.SetMagicNumber(command.MagicNumber);
            return Task.FromResult(executionResult);
        }
    }
}
