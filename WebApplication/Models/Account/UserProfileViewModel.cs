using System.Collections;
using System.Collections.Generic;
using DTO.Entities;

namespace WebApplication.Models.Account
{
    public class UserProfileViewModel
    {
        public EUser User { get; set; }
        public bool EditingMode { get; set; }
        public IList<EBook> FavoriteBooks { get; set; }
        
    }
}