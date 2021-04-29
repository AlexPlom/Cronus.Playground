using Elders.Cronus;
using System;
using System.Runtime.Serialization;

namespace Cronus.Contracts
{
    [DataContract(Name = "6eaca9e7-be24-4a9a-941e-6fae94e63e69")]
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
