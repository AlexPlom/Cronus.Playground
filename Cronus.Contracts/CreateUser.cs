using Elders.Cronus;
using System;
using System.Runtime.Serialization;

namespace Cronus.Contracts
{
    [DataContract(Name = "bb194628-bee6-402e-8c12-e688b3675da1")]
    public class CreateUser : ICommand
    {
        public CreateUser(UserId id, string username, DateTimeOffset timestamp)
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
