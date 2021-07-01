using System.Collections.Generic;

namespace DTO.Entities
{
    public class EUserProfile
    {
        public int Id { get; set; }
        public EUser User { get; set; }
        public string Name { get; set; }
        public string AdditionalInfo { get; set; }
        public IList<EBook> FavoriteBooks { get; set; }
        public IList<EBook> UploadedBooks { get; set; }
    }
}