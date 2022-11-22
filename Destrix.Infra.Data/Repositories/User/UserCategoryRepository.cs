using Destrix.Domain.Entities.User;
using Destrix.Domain.Interfaces.Repositories.User;
using Destrix.Infra.Data.Contexts;
using Destrix.Infra.Data.Repositories.Base;

namespace Destrix.Infra.Data.Repositories.User
{
    public class UserCategoryRepository : BaseRepository<UserCategory>, IUserCategoryRepository
    {
        public UserCategoryRepository(DestrixPostgreContext context) : base(context)
        {
        }
    }
}
