using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModel;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> _owner;
        private readonly IUnitOfWork<PotfolioItem> _potfolio;

        public HomeController(IUnitOfWork<Owner> owner , IUnitOfWork<PotfolioItem> potfolio)
        {
            _owner = owner;
            _potfolio = potfolio;
        }
        public IActionResult Index()
        {
            var home = new HomeViewModel()
            {
                Owner = _owner.Entity.GetAll().First(),
                PotfolioItems = _potfolio.Entity.GetAll().ToList()
            };
            return View(home);
        }
    }
}