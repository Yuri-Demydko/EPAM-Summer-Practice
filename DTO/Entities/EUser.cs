using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DTO.Entities
{
    public class EUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string DateOfBirth { get; set; }
        public byte[] Avatar { get; set; }
        public string AdditionalInfo { get; set; } 
        //public List<EBook> FavoriteBooks { get; set; }
        public List<EBook> OwnBooks { get; set; }
    }
}