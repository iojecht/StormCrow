using System.Security.Principal;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StormCrow.Web.Data;

namespace StormCrow.Web.Infrastructure
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IIdentity _identity;
        private readonly ApplicationDbContext _context;

        private IdentityUser _user;

        public CurrentUser(IIdentity identity, ApplicationDbContext context)
        {
            _identity = identity;
            _context = context;
        }

        public IdentityUser User
        {
            get { return _user ?? (_user = _context.Users.Find(_identity.GetUserId())); }
        }
    }
}