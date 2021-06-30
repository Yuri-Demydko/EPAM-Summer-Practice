using System.Collections.Generic;

namespace DTO.Entities
{
    public class EFUserProfile
    {
        public int Id { get; set; }
        public EFUser User { get; set; }
        public string Name { get; set; }
        public string AdditionalInfo { get; set; }
        public IList<EFBook> FavoriteBooks { get; set; }
        public IList<EFBook> UploadedBooks { get; set; }
    }
}