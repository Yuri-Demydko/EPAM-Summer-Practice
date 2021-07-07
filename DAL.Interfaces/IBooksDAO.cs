using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;

namespace DAL.Interfaces
{
    public interface IBooksDAO
    {
        public Task UploadBook(EBook book, string ownerUserName);
        public Task<IList<EBook>> GetBooksGallery();
        public Task<EBook> GetBookById(string id,bool includeHeavyData=true);
        public Task UpdateBookInFavorites(int bookId, string userName, bool removingMode = false);
        public Task EditBookData(EBook updatedBook);
        public Task DeleteBook(string bookId);
        public Task<IList<EBook>> GetFilteredBooksGallery(Tuple<string,byte> searchParameters);
    }
}