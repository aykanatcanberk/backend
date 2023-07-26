using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System;

namespace Alesta03.Model
{
    public class ExpReviews
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public Person person { get; set; }
        public string personId { get; set; }

        public Company company { get; set; }
        public string companyId { get; set; }
    }
}
