using Elders.Cronus;
using Elders.Cronus.Projections;
using System;
using System.Runtime.Serialization;

namespace Cronus.Contracts
{
    [DataContract(Name = "398f646b-a8c0-4dad-a648-d936a70e43fe")]
    public class UserProjection : ProjectionDefinition<UserProjectionState, UserId>, IProjection,
        IEventHandler<UserCreated>
    {
        public void Handle(UserCreated @event)
        {
            State.Username = @event.Username;
            State.LastModificationDate = @event.Timestamp;
        }
    }

    public class UserProjectionState
    {
        public string Username { get; set; }
        public DateTimeOffset LastModificationDate { get; set; }
    }
}
