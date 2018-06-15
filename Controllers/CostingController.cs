using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostEstimate.Data;
using CostEstimate.Models;
using CostEstimate.Models.ViewModels;
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

        public IActionResult ClearingAndGrading(int? id)
        {
            var record = (from p in _context.Projects
                          join c in _context.ClearingAndGrading
                          on p.Id equals c.ProjectId into ps
                          from c in ps.DefaultIfEmpty()
                          where p.Id == id
                          select new ClearingAndGradingProjectViewModel
                          {
                              Projects = p,
                              ClearingAndGrading = c
                          }).FirstOrDefault();

            if (record == null)
            {
                return RedirectToAction("Index", "Project");
            }

            return View(record);
        }

        [HttpPost]
        public IActionResult CreateClearingAndGrading(ClearingAndGrading clearingAndGrading, int? id, Projects projects)
        {
            clearingAndGrading.ProjectId = projects.Id;
            _context.Update(clearingAndGrading);
            _context.SaveChanges();

            return RedirectToAction("ClearingAndGrading", "Costing", new { id });
        }

        public IActionResult Foundation(int? id)
        {

            var record = (from p in _context.Projects
                          join c in _context.Foundation
                          on p.Id equals c.ProjectId into ps
                          from c in ps.DefaultIfEmpty()
                          where p.Id == id
                          select new FoundationProjectViewModel
                          {
                              Projects = p,
                              Foundation = c
                          }).FirstOrDefault();

            if (record == null)
            {
                return RedirectToAction("Index", "Project");
            }
            return View(record);
        }

        [HttpPost]
        public IActionResult CreateFoundation(Foundation foundation, int? id, Projects projects)
        {
            foundation.ProjectId = projects.Id;
            _context.Update(foundation);
            _context.SaveChanges();

            return RedirectToAction("Foundation", "Costing", new { id });
        }

        public IActionResult FramingAndDryIn(int? id)
        {

            var record = (from p in _context.Projects
                          join c in _context.FramingAndDryIn
                          on p.Id equals c.ProjectId into ps
                          from c in ps.DefaultIfEmpty()
                          where p.Id == id
                          select new FramingAndDryInProjectViewModel
                          {
                              Projects = p,
                              FramingAndDryIn = c
                          }).FirstOrDefault();

            if (record == null)
            {
                return RedirectToAction("Index", "Project");
            }
            return View(record);
        }

        [HttpPost]
        public IActionResult CreateFramingAndDryIn(FramingAndDryIn framingAndDryIn, int? id, Projects projects)
        {
            framingAndDryIn.ProjectId = projects.Id;
            _context.Update(framingAndDryIn);
            _context.SaveChanges();

            return RedirectToAction("FramingAndDryIn", "Costing", new { id });
        }

        public IActionResult InsulationAndSheetrock(int? id)
        {

            var record = (from p in _context.Projects
                          join c in _context.InsulationAndSheetrock
                          on p.Id equals c.ProjectId into ps
                          from c in ps.DefaultIfEmpty()
                          where p.Id == id
                          select new InsulationAndSheetrockProjectViewModel
                          {
                              Projects = p,
                              InsulationAndSheetrock = c
                          }).FirstOrDefault();

            if (record == null)
            {
                return RedirectToAction("Index", "Project");
            }
            return View(record);
        }

        [HttpPost]
        public IActionResult CreateInsulationAndSheetrock(InsulationAndSheetrock insulationAndSheetrock, int? id, Projects projects)
        {
            insulationAndSheetrock.ProjectId = projects.Id;
            _context.Update(insulationAndSheetrock);
            _context.SaveChanges();

            return RedirectToAction("InsulationAndSheetrock", "Costing", new { id });
        }

    }
}
