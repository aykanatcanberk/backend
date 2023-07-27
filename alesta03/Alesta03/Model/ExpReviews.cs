using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System;

namespace Alesta03.Model
{
    public class ExpReviews
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public Person Person { get; set; }
        public string PersonId { get; set; }

        public Company Company { get; set; }
        public string CompanyId { get; set; }
    }
}
