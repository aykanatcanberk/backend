using Alesta03.Services.PersonServices.ExpReviewService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alesta03.Services.PostServices;
using Alesta03.Model.Request;
using Alesta03.Request.PostRequest;

namespace Alesta03.Controllers.GeneralController
{

    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly DataContext _dataContext;

        public PostsController(IPostService postService, DataContext dataContext)
        {
            _postService = postService;
            _dataContext = dataContext;
        }

        

    }
}
