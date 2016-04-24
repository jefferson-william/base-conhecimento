namespace bs.Controllers
{
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Boilerplate.Web.Mvc;
    using Boilerplate.Web.Mvc.Filters;
    using Microsoft.AspNet.Mvc;
    using Microsoft.Extensions.OptionsModel;
    using bs.Constants;
    using bs.Services;
    using bs.Settings;

    public class HomeController : Controller
    {
        #region Fields

        private readonly IOptions<AppSettings> appSettings;
        private readonly IRobotsService robotsService;

        #endregion

        #region Constructors

        public HomeController(
            IRobotsService robotsService,
            IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings;
            this.robotsService = robotsService;
        }

        #endregion

        [HttpGet("", Name = HomeControllerRoute.GetIndex)]
        public IActionResult Index()
        {
            return this.View(HomeControllerAction.Index);
        }

        /// <summary>
        /// Tells search engines (or robots) how to index your site. 
        /// The reason for dynamically generating this code is to enable generation of the full absolute sitemap URL
        /// and also to give you added flexibility in case you want to disallow search engines from certain paths. The 
        /// sitemap is cached for one day, adjust this time to whatever you require. See
        /// http://rehansaeed.com/dynamically-generating-robots-txt-using-asp-net-mvc/
        /// </summary>
        /// <returns>The robots text for the current site.</returns>
        [NoTrailingSlash]
        [ResponseCache(CacheProfileName = CacheProfileName.RobotsText)]
        [Route("robots.txt", Name = HomeControllerRoute.GetRobotsText)]
        public IActionResult RobotsText()
        {
            string content = this.robotsService.GetRobotsText();
            return this.Content(content, ContentType.Text, Encoding.UTF8);
        }
    }
}
