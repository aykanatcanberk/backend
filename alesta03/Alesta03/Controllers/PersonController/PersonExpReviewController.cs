﻿using Alesta03.Model.Request;
using Alesta03.Request;
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
        public async Task<ActionResult<List<ExpReviews>>> GetAllReviews()
        {
            return _expReviewSercive.GetAllReviews();
        }

        [HttpGet("{id}")/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<ExpReviews>> GetSingleReviews(int id)
        {
            var result = _expReviewSercive.GetSingleReviews(id);
            if (result == null)
                return NotFound("Yorum Bulunumadı!");

            return Ok(result);
        }

        [HttpPost/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<List<ExpReviews>>> AddReview(AddReviewRequest request)
        {
            var result = _expReviewSercive.AddReview(request);
            return Ok(result);
        }

        [HttpPut("{id}")/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<List<ExpReviews>>> UpdateReview(int id, ExpReviews request)
        {
            var result = _expReviewSercive.UpdateReview(id, request);
            if (result == null)
                return NotFound("Yorum Bulunumadı!");

            return Ok(result);
        }

        [HttpDelete("{id}")/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<List<ExpReviews>>> DeleteReview(int id)
        {
            var result = _expReviewSercive.DeleteReview(id);
            if (result == null)
                return NotFound("Yorum Bulunumadı!");

            return Ok(result);
        }

    }
}
