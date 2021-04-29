using Elders.Cronus;
using System;
using System.Runtime.Serialization;

namespace Cronus.Contracts
{
    [DataContract(Name = "050a0d2b-7d01-41e6-bb48-0b8f9ef1aba7")]
    public class UserCreated : IEvent
    {
        public UserCreated(UserId id, string username, DateTimeOffset timestamp)
        {
            Id = id;
            Username = username;
            Timestamp = timestamp;
        }

        [DataMember(Order = 1)]
        public UserId Id { get; private set; }

        [DataMember(Order = 2)]
        public string Username { get; private set; }

        [DataMember(Order = 3)]
        public DateTimeOffset Timestamp { get; private set; }
    }
}
