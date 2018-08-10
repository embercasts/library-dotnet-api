using System.Collections.Generic;
using JsonApiDotNetCore.Models;
using LibraryApi.Models;

namespace LibraryApi.Domain.Users
{
    public class UserResource : ResourceDefinition<User>
    {
        protected override List<AttrAttribute> OutputAttrs() => Remove(u => new { u.Password, u.PasswordConfirmation });
    }
}
