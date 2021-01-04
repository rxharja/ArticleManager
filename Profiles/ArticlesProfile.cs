using ArticleManager.Dtos;
using ArticleManager.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleManager.Profiles
{
    public class ArticlesProfile : Profile
    {
        public ArticlesProfile()
        {
            // Source -> Target
            CreateMap<Article, ArticleReadDto>();

            CreateMap<ArticleCreateDto, Article>();

            CreateMap<ArticleUpdateDto, Article>();

            CreateMap<Article, ArticleUpdateDto>();
        }
    }
}
