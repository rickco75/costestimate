using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostEstimate.Data;
using CostEstimate.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CostEstimate.Controllers
{
    public class CostingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CostingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NonConstructionItems(int? id)
        {
            //var vm = new ProjectNonConstructionItemsViewModel();

            var record = (from p in _context.Projects
                          join c in _context.NonConstructionItems
                          on p.Id equals c.ProjectId into ps
                          from c in ps.DefaultIfEmpty()
                          where p.Id == id
                          select new ProjectNonConstructionItemsViewModel
                          {
                              project = p,
                              nonconstructionitems = c
                          }).FirstOrDefault();

            if (record == null)
            {
                return RedirectToAction("Index", "Project");
            }
            return View(record);
        }

        [HttpPost]
        public IActionResult CreateNonConstructionItems(NonConstructionItems nonConstructionItems, int? id, Projects projects)
        {
            nonConstructionItems.ProjectId = projects.Id;
            _context.Update(nonConstructionItems);
            _context.SaveChanges();

            return RedirectToAction("NonConstructionItems", "Costing",new {id});
        }
    }
}
