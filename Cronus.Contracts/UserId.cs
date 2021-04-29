using Elders.Cronus;
using System.Runtime.Serialization;

namespace Cronus.Contracts
{
    [DataContract(Name = "d4889cbb-aa8d-4b6b-b10d-93cc88d51cc4")]
    public class UserId : AggregateRootId<UserId>
    {
        private UserId() { }

        private UserId(string id, string tenant) : base(id, "user", tenant)
        {
            User = new Urn(tenant, id);
        }

        protected override UserId Construct(string id, string tenant) => new UserId(id, tenant);

        [DataMember(Order = 1)]
        public IUrn User { get; private set; }
    }
}
