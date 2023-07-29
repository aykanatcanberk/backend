using Alesta03.Request.AddRequest;
using Alesta03.Request.UpdateRequest;
using Alesta03.Services.PersonServices.ExpReviewService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Alesta03.Controllers.PersonController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IExpReviewService _expReviewSercive;

        public PersonController(IExpReviewService expReviewService)
        {
            _expReviewSercive = expReviewService;
        }


        [HttpGet/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<List<ExpReview>>> GetAllReviews()
        {
            return await _expReviewSercive.GetAllReviews();
        }

            [HttpGet("{id}")/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<ExpReview>> GetSingleReviews(int id)
        {
            var result = await _expReviewSercive.GetSingleReviews(id);
            if (result == null)
                return NotFound("Yorum Bulunumadı!");

            return Ok(result);
        }

        [HttpPost/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<List<ExpReview>>> AddReview(AddReviewRequest request)
        {
            var result = await _expReviewSercive.AddReview(request);
            return Ok(result);
        }

        [HttpPut("{id}")/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<List<ExpReview>>> UpdateReview(int id, UpdateReviewRequest request)
        {
            var result = await _expReviewSercive.UpdateReview(id, request);
            if (result == null)
                return NotFound("Yorum Bulunumadı!");

            return Ok(result);
        }

        [HttpDelete("{id}")/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<List<ExpReview>>> DeleteReview(int id)
        {
            var result = await _expReviewSercive.DeleteReview(id);
            if (result == null)
                return NotFound("Yorum Bulunumadı!");
            
            return Ok(result);
        }

    }
}
