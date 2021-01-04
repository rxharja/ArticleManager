using ArticleManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleManager.Data
{
    public interface IArticleRepository
    {
        bool SaveChanges();
        IEnumerable<Article> GetAllArticles();
        Article GetArticleById(int id);
        void CreateArticle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(Article article);
    }
}
