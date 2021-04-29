using Elders.Cronus;
using System;
using System.Runtime.Serialization;

namespace Cronus.Contracts
{
    [DataContract(Name = "050a0d2b-7d01-41e6-bb48-0b8f9ef1aba7")]
    public class UserAggregate : AggregateRoot<UserAggregateState>
    {
        public UserAggregate() { }

        public UserAggregate(UserId userId, string username, DateTimeOffset timestamp)
        {
            var evnt = new UserCreated(userId, username, timestamp);
            Apply(evnt);
        }
    }
}
