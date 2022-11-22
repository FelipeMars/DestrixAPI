using Destrix.Domain.Interfaces.Repositories.User;
using Destrix.Infra.Data.Contexts;
using Destrix.Infra.Data.Repositories.Base;

namespace Destrix.Infra.Data.Repositories.User
{
    public class UserRepository : BaseRepository<Domain.Entities.User.User>, IUserRepository
    {
        public UserRepository(DestrixPostgreContext context) 
            : base(context)
        { }
    }
}
