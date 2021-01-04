using ArticleManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleManager.Data
{
    public class SqlArticleRepository : IArticleRepository
    {
        private readonly DataContext _context;

        public SqlArticleRepository(DataContext context)
        {
            _context = context;
        }

        public void CreateArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article)); 
            }

            _context.Articles.Add(article); 
        }

        public void DeleteArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            _context.Articles.Remove(article);
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _context.Articles.ToList();
        }

        public Article GetArticleById(int id)
        {
            return _context.Articles.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateArticle(Article article)
        {
            // Nothing
        }

    }
}
