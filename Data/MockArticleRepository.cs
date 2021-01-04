using ArticleManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleManager.Data
{
    public class MockArticleRepository : IArticleRepository
    {
        public void CreateArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public void DeleteArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetAllArticles()
        {
            var articles = new List<Article>
            {
                new Article{ Id = 0, Title = "Title1", Content = "Test Article 1", Description = "Test Description 1" },
                new Article{ Id = 1, Title = "Title2", Content = "Test Article 2", Description = "Test Description 2" },
                new Article{ Id = 2, Title = "Title3", Content = "Test Article 3", Description = "Test Description 3" }
            };

            return articles;
        }

        public Article GetArticleById(int id)
        {
            return new Article
            {
                Id = 0,
                Content = "Test Article",
                Description = "Test Description"
            };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateArticle(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
