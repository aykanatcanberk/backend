﻿namespace Alesta03.Model.Response
{
        public class AddReviewResponse
        {
            public int ID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int companyId { get; set; }
            public DateTime CreatedDate { get; set; }
        }
}
