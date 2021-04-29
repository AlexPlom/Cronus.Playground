using Elders.Cronus;
using System;
using System.Runtime.Serialization;

namespace Cronus.Contracts
{
    public class Class1
    {
    }

    public class FooAggregateAppService : ApplicationService<FooAggregate>,
       ICommandHandler<FooCommand>
    {
        public FooAggregateAppService(IAggregateRepository repository) : base(repository) { }

        public void Handle(FooCommand command)
        {
            var arResult = repository.Load<FooAggregate>(command.Id);

            if (arResult.IsSuccess)
            {
                return;
            }
            else
            {
                var notFound = new FooAggregate(command.Id, command.Bar);
                repository.Save(notFound);
            }
        }
    }

    [DataContract(Name = "bb194628-bee6-402e-8c12-e688b3675da1")]
    public class FooCommand : ICommand
    {
        public FooCommand(FooId id, string bar)
        {
            Id = id;
            Bar = bar;
        }

        [DataMember(Order = 1)]
        public FooId Id { get; set; }

        [DataMember(Order = 2)]
        public string Bar { get; set; }
    }

    [DataContract(Name = "050a0d2b-7d01-41e6-bb48-0b8f9ef1aba7")]
    public class FooEvent : IEvent
    {
        public FooEvent(FooId id, string bar)
        {
            Id = id;
            Bar = bar;
        }

        [DataMember(Order = 1)]
        public FooId Id { get; set; }

        [DataMember(Order = 2)]
        public string Bar { get; set; }
    }


    public class FooAggregate : AggregateRoot<FooAggregateState>
    {
        public FooAggregate(FooId fooId, string Bar)
        {
            var evnt = new FooEvent(fooId, Bar);
            Apply(evnt);
        }
    }

    public class FooAggregateState : AggregateRootState<FooAggregate, FooId>
    {
        public override FooId Id { get; set; }
    }

    [DataContract(Name = "d4889cbb-aa8d-4b6b-b10d-93cc88d51cc4")]
    public class FooId : AggregateRootId<FooId>
    {
        private FooId() { }

        private FooId(string id, string tenant) : base(id, "food", tenant)
        {
            User = new Urn(tenant, id);
        }

        protected override FooId Construct(string id, string tenant) => new FooId(id, tenant);

        [DataMember(Order = 1)]
        public IUrn User { get; private set; }
    }
}
