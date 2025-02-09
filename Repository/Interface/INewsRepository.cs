using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXE_PROJECT.Models;

namespace Free_Course_For_Student.Repository.Interface
{
    public interface INewsRepository
    {
        public News GetNewsById(int id);
        public void AddNews(News news);
        public void UpdateNews(News news);
        public void DeleteNews(News news);
        public List<News> GetAllNews();
    }
}