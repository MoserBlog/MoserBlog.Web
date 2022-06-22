using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoserBlog.Application.Features.BlogEntries.Queries.GetBlogEntryOverview;
using MoserBlog.Web.Models;
using System.Diagnostics;

namespace MoserBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public HomeController(
            ILogger<HomeController> logger,
            IMediator mediator,
            IConfiguration configuration)
        {
            _logger = logger;
            _mediator = mediator;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var overviewViewModel = await _mediator.Send(new GetBlogEntryOverviewQuery()
            {
                AmountOfElements = Convert.ToInt32(_configuration["AmountOfOverviewItems"])
            });

            return View(overviewViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
