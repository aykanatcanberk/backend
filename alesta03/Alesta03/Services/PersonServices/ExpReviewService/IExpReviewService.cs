using Alesta03.Model.Request;
using Alesta03.Model.Response;
using Alesta03.Request;
using Alesta03.Response;
﻿using Alesta03.Request.AddRequest;
using Alesta03.Request.UpdateRequest;
using Alesta03.Response.AddResponse;
using Alesta03.Response.DeleteResponse;
using Alesta03.Response.GetResponse;
using Alesta03.Response.UpdateResponse;
using Microsoft.AspNetCore.Mvc;

namespace Alesta03.Services.PersonServices.ExpReviewService
{
    public interface IExpReviewService
    {
        //GetReviewResponse GetAllReviews();
        List<ExpReviews> GetAllReviews();
        GetReviewResponse? GetSingleReviews(int id);
        AddReviewResponse AddReview(AddReviewRequest request);
        UpdateReviewResponse? UpdateReview(int id, UpdateReviewRequest request);
        DeleteReviewResponse? DeleteReview(int id);
    }
}

