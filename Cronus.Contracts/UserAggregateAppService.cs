using Elders.Cronus;

namespace Cronus.Contracts
{
    public class UserAggregateAppService : ApplicationService<UserAggregate>,
       ICommandHandler<CreateUser>
    {
        public UserAggregateAppService(IAggregateRepository repository) : base(repository) { }

        public void Handle(CreateUser command)
        {
            var arResult = repository.Load<UserAggregate>(command.Id);

            if (arResult.IsSuccess)
            {
                return;
            }
            else
            {
                var notFound = new UserAggregate(command.Id, command.Username, command.Timestamp);
                repository.Save(notFound);
            }
        }
    }
}
