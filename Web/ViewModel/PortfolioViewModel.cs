using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModel
{
    public class PortfolioViewModel
    {
        public string ProjectName { get; set; }
        public string ImageUrl { get; set; }

        public string Description { get; set; }
        public Guid Id { get; set; }

        public IFormFile File { get; set; }
    }
}
