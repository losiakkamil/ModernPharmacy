using ModernPharmacy.Shared.Models.ArticleDtos;

namespace ModernPharmacy.Server.Services.ArticleService
{
    public interface IArticleService
    {
        Task<ServiceResponse<Article>> GetArticleByIdAsync(int articleId);
        Task<ServiceResponse<ArticleDto>> GetArticleByTitleAsync(string title);
        Task<ServiceResponse<List<Article>>> GetAllArticlesAsync();
        Task<ServiceResponse<List<Tuple<string, string>>>> GetOnlyArticleTitlesAsync();
    }
}
