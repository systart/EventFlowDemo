using EventFlow.Aggregates;
using EventFlow.EventStores;

namespace EventFlowDemo
{
    [EventVersion("example", 1)]
    public class ExampleEvent : AggregateEvent<ExampleAggregate, ExampleId>
    {
        public ExampleEvent(int magicNumber)
        {
            MagicNumber = magicNumber;
        }
        public int MagicNumber { get; set; }
    }
}
