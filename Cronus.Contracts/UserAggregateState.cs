using Elders.Cronus;
using System;

namespace Cronus.Contracts
{
    public class UserAggregateState : AggregateRootState<UserAggregate, UserId>
    {
        public override UserId Id { get; set; }
        public string Username { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        public void When(UserCreated @event)
        {
            this.Id = @event.Id;
            this.Username = @event.Username;
            this.Timestamp = @event.Timestamp;
        }
    }
}
