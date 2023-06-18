using System.Net.Http.Json;

namespace ModernPharmacy.Client.Services.ArticleService
{
    public class ArticleService : IArticleService
    {
        private readonly HttpClient _http;
        public List<Article> Articles { get; set; }
        public ArticleDto Article { get; set; }
        public List<Tuple<string, string>>? ArticleTitlesAndPaths { get; set; }
        public ArticleService(HttpClient http)
        {
            _http = http;
        }
        
        public async Task GetArticleByIdAsync(int articleId)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<ArticleDto>>($"api/Article/{articleId}");
            if(response != null && response.Data != null)
            {
                Article = response.Data;
            }
        }
        
        public async Task GetAllArticlesAsync()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Article>>>($"api/Article");
            if(response != null && response.Data != null)
            {
                Articles = response.Data;
            }
        }

        public async Task GetOnlyArticleTitlesAsync()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Tuple<string, string>>>>($"api/Article/TitleAndPath");
            if (response != null && response.Data != null)
            {
                ArticleTitlesAndPaths = response.Data;
            }
        }

        public async Task GetArticleByTitleAsync(string title)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<ArticleDto>>($"api/Article/{title}");
            if (response != null && response.Data != null)
            {
                Article = response.Data;
            }
        }
    }
}
