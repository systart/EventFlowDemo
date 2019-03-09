using EventFlow.Aggregates;
using EventFlow.Aggregates.ExecutionResults;

namespace EventFlowDemo
{
    public class ExampleAggregate : AggregateRoot<ExampleAggregate, ExampleId>, IEmit<ExampleEvent>
    {
        private int? _magicNumber;

        public ExampleAggregate(ExampleId id) : base(id)
        {

        }

        public IExecutionResult SetMagicNumber(int magicNumber)
        {
            if (_magicNumber.HasValue)
                return ExecutionResult.Failed("Magic number already set.");
            Emit(new ExampleEvent(magicNumber));
            return ExecutionResult.Success();
        }

        public void Apply(ExampleEvent aggregateEvent)
        {
            _magicNumber = aggregateEvent.MagicNumber;
        }
    }
}
