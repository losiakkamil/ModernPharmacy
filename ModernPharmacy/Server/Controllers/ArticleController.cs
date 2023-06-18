using Microsoft.AspNetCore.Mvc;

namespace ModernPharmacy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("{articleId:int}")]
        public async Task<ActionResult<ServiceResponse<Article>>> GetArticleById(int articleId)
        {
            var result = await _articleService.GetArticleByIdAsync(articleId);
            return Ok(result);
        }

        [HttpGet("{title}")]
        public async Task<ActionResult<ServiceResponse<Article>>> GetArticleByTitleAsync(string title)
        {
            var result = await _articleService.GetArticleByTitleAsync(title);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Article>>>> GetAllArticlesAsync()
        {
            var result = await _articleService.GetAllArticlesAsync();
            return Ok(result);
        }

        [HttpGet("TitleAndPath")] //api/Article/TitleAndPath"
        public async Task<ActionResult<ServiceResponse<List<Tuple<string, string>>>>> GetOnlyArticleTitlesAsync()
        {
            var result = await _articleService.GetOnlyArticleTitlesAsync();
            return Ok(result);
        }

    }

    
}
