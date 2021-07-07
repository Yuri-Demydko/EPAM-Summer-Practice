using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using Entities.Entities;

namespace BLL.Logic
{
    public class BooksBLO : IBooksBLO
    {
        private readonly DAL.Interfaces.IBooksDAO _booksDao;
        public BooksBLO(DAL.Interfaces.IBooksDAO booksDao)
        {
            _booksDao = booksDao;
        }
        public async Task UploadBook(EBook book, string ownerUserName) => await _booksDao.UploadBook(book, ownerUserName);
        public async Task<IList<EBook>> GetBooksGallery() => await _booksDao.GetBooksGallery();
        public async Task<EBook> GetBookById(string id,bool includeData=true) => await _booksDao.GetBookById(id,includeData);
        public async Task UpdateBookInFavorites(int bookId, string userName,bool removingMode=false) =>
            await _booksDao.UpdateBookInFavorites(bookId, userName,removingMode);
        public async Task EditBookData(EBook updatedBook) => await _booksDao.EditBookData(updatedBook);
        public async Task DeleteBook(string bookId) => await _booksDao.DeleteBook(bookId);
        public async Task<IList<EBook>> GetFilteredBooksGallery(Tuple<string,byte> searchParameters) =>
            await _booksDao.GetFilteredBooksGallery(searchParameters);
    }
}