using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DTO.Entities
{
    public class EUser:IdentityUser
    {
        public IList<EBook> OwnBooks { get; set; }
    }
}