using System;
using System.Collections.Generic;
using Entities.Entities;

namespace PL.ASP.MVC.Models.Books
{
    public class BooksGalleryViewModel
    {
        private const int  MAX_CARDS_ON_PAGE=30;
        private const int PAGE_DIAPASON = 10;
        public IList<EBook> Books { get; set; } = new List<EBook>();
        public int PageNum { get; set; }
        // ReSharper disable once PossibleLossOfFraction
        public double TotalPagesCount => Math.Ceiling(Books.Count / (double)MAX_CARDS_ON_PAGE);
        public Tuple<int, int> PageStartEndIndexes { get; private set; }

        public Tuple<int,int> MinMaxPages { get; private set; }
        
        public void CalculatePagination()
        {
            var startInd = PageNum * MAX_CARDS_ON_PAGE;
            var endInd = (PageNum + 1) * MAX_CARDS_ON_PAGE;
            if (endInd > Books.Count)
                endInd = Books.Count;
            PageStartEndIndexes = new Tuple<int, int>(startInd, endInd);

            var minPage = 0;
            var maxPage = (int)TotalPagesCount;
            if (TotalPagesCount > PAGE_DIAPASON)
            {
                for (var i = 0; i < TotalPagesCount; i += PAGE_DIAPASON)
                {
                    if (i > PageNum)
                        break;
                    minPage = i;
                }
                maxPage = minPage + PAGE_DIAPASON;
                if (maxPage > TotalPagesCount)
                    maxPage = (int)TotalPagesCount;
            }

            MinMaxPages = new Tuple<int, int>(minPage, maxPage);
        }
        
        // For search 
        public string SearchString { get; set; } = "";
       // public bool ByAuthor { get; set; }
        //public bool ByGenre { get; set; }
       // public bool ByDescription { get; set; }
       public byte SearchMode { get; set; } = 0;//0=NO, 1=T, 2=A, 3=G

    }
}