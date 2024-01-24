using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcSql.Domain
{
    public class ArticlesRepository
    {
        private readonly AppDbContext context;

        public ArticlesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Article> GetArticles()
        {
            return context.Articles.OrderBy(x => x.Title);
        }

        public Article GetArticleById(Guid id)
        {
            return context.Articles.Single(x => x.Id == id);
        }

        public Guid SaveArticle(Article entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity.Id;
        }

        public void DeleteArticle(Article entity)
        {
            context.Articles.Remove(entity);
            context.SaveChanges();
        }
    }
}
