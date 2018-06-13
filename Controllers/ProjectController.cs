using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CostEstimate.Models;
using Microsoft.AspNetCore.Authorization;
using CostEstimate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CostEstimate.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            var projectList = _context.Projects.ToList();
            return View(projectList);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            var projects = from p
                           in _context.Projects
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                projects = projects.Where(s => s.JobName.Contains(searchString));
            }

            return View(await projects.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.Projects.SingleOrDefaultAsync(m => m.Id == id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[Authorize]
        //public IActionResult Costing(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //var record = (from p in _context.Projects
        //              join c in _context.CostModel
        //              on p.Id equals c.ProjectId into ps
        //              from c in ps.DefaultIfEmpty()
        //              where p.Id == id
        //              select new ProjectCostViewModel
        //              {
        //                  Projects = p,
        //                  CostModel = c
        //              }).FirstOrDefault();
        //    if (record == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(record);
        //}


        public IActionResult Create()
        {
            return View();
        }

        //public async Task<IActionResult> CreateCostModel()
        //{
        //    IQueryable<string> projectValue = from p in _context.Projects
        //                                      orderby p.JobName
        //                                      select (p.Id.ToString() + p.JobName);

        //    var projectsValueVM = new ProjectsValueViewModel();
        //    projectsValueVM.projectValues = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(await projectValue.Distinct().ToListAsync());

        //    return View(projectsValueVM);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCostModel([Bind("Id,AveragePerSqFootFinished,AvgCostGarage,AvgCostMainLevel,projectValues, AvgCostUnfinsihedBasement,AvgCostUpperLoft,AvgPerSqFtFinBasement,BasementUnfinishedSqFeet,FinishedBasement,Garage,MainLevelSquareFeet,TotalSquareFtHouse,TotalSquareFtUnderRoof,UpperLevelLoft")] CostModel costModel)
        {
            //var record = (from p in _context.Projects where p.JobName =)
            if (ModelState.IsValid)
            {
                costModel.ProjectId = 1;
                _context.Add(costModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(costModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cell,City,Fax,Home,JobName,LegalDescription,LotNumber,Name,State,StreetName,StreetNumber,SubdivisionName,ZipCode,DateCreated")] Projects projects)
        {
            var record = (from c in _context.Projects
                          where c.JobName.ToLower().Trim() == projects.JobName.ToLower().Trim()
                          select c).FirstOrDefaultAsync();

            if (ModelState.IsValid)
            {
                if (await record == null)
                {
                    _context.Add(projects);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("JobName", "Job Name Name already exists");
            }
            return View(projects);
        }

        [Authorize]
        public async Task<IActionResult> ViewCost(int? id)
        {
            var cm = from cost in _context.CostModel
                     join proj in _context.Projects
                     on cost.ProjectId equals proj.Id
                     where cost.ProjectId == id
                     select new CostProjectViewModel
                     {
                         Projects = proj , CostModel = cost 
                     };            
            
            if (id == null)
            {
                cm = from cost in _context.CostModel
                     join proj in _context.Projects
                     on cost.ProjectId equals proj.Id
                     select new CostProjectViewModel
                     {
                         Projects = proj,
                         CostModel = cost
                     };

            }
            await cm.ToListAsync();

            return View(cm);
        }

        [Authorize]
        public IActionResult Costing(int? id, int projectId)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var record = (from c in _context.CostModel
            //              where c.Id == id
            //              select c).FirstOrDefault();

            var record = from cost in _context.CostModel
                     join proj in _context.Projects
                     on cost.ProjectId equals proj.Id
                     where cost.ProjectId == projectId
                     select new CostProjectViewModel
                     {
                         Projects = proj,
                         CostModel = cost
                     };

            if (record == null)
            {
                CostModel cm = new CostModel();
                return View(cm);
            }

            return View(record.FirstOrDefault());
        }

        public IActionResult CreateCosting()
        {

            var vm = new ProjectsValueViewModel();
            vm.Projects = _context.Projects
                            .Select(a => new SelectListItem()
                            {
                                Value = a.Id.ToString(),
                                Text = a.JobName.ToString()
                            })
                            .ToList();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCostModel([Bind("Id,ProjectId,AveragePerSqFootFinsihed,AvgCostGarage,AvgCostMainLevel, AvgCostUnfinsihedBasement,AvgCostUpperLoft,AvgPerSqFtFinBasement,BasementUnfinishedSqFeet,FinishedBasement,Garage,MainLevelSquareFeet,TotalSquareFtHouse,TotalSquareFtUnderRoof,UpperLevelLoft")] CostModel costModel)
        {
            if (ModelState.IsValid)
            {

                _context.Add(costModel);
                _context.SaveChanges();

                return RedirectToAction(nameof(ViewCost), new { });
            }
            return View(costModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCosting([Bind("Id,ProjectId,AveragePerSqFootFinsihed,AvgCostGarage,AvgCostMainLevel, AvgCostUnfinsihedBasement,AvgCostUpperLoft,AvgPerSqFtFinBasement,BasementUnfinishedSqFeet,FinishedBasement,Garage,MainLevelSquareFeet,TotalSquareFtHouse,TotalSquareFtUnderRoof,UpperLevelLoft")] CostModel costModel, int id)
        {
            if (ModelState.IsValid)
            {

                //costModel.ProjectId = id;
                _context.Update(costModel);
                _context.SaveChanges();

                return RedirectToAction(nameof(ViewCost));
            }
            return View(costModel);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult CreateCosting([Bind("Id,AveragePerSqFootFinished,AvgCostGarage,AvgCostMainLevel, AvgCostUnfinsihedBasement,AvgCostUpperLoft,AvgeragePerSqFtFinBasement,BasementUnfinishedSqFeet,FinishedBasement,Garage,MainLevelSquareFeet,TotalSquareFtHouse,TotalSquareFtUnderRoof,UpperLevelLoft")] CostModel costModel, int Id)
        //{
        //    var record = (from c in _context.CostModel
        //                  where c.ProjectId == Id
        //                  select c).FirstOrDefault();

        //    bool create = record == null ? true : false;

        //    if (ModelState.IsValid)
        //    {

        //        if (create)
        //        {
        //            costModel.ProjectId = Id;
        //            _context.Add(costModel);
        //        } else
        //        {
        //            _context.Update(costModel);
        //        }
        //        _context.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(costModel);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Cell,City,Fax,Home,JobName,LegalDescription,LotNumber,Name,State,StreetName,StreetNumber,SubdivisionName,ZipCode,DateCreated")] Projects projects)
        {
            if (id != projects.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(projects);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionExists(projects.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }


        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .SingleOrDefaultAsync(m => m.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }
        // GET: Movies/Delete/5
        public async Task<IActionResult> DeleteCostModel(int? id, int projectid)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var costmodel = await _context.CostModel
            //    .SingleOrDefaultAsync(m => m.Id == id);
            var costmodel = await (from cost in _context.CostModel
                         join proj in _context.Projects
                         on cost.ProjectId equals proj.Id
                         where cost.Id == id
                         select new CostProjectViewModel
                         {
                             Projects = proj,
                             CostModel = cost
                         }).SingleOrDefaultAsync();

            if (costmodel == null)
            {
                return NotFound();
            }

            return View(costmodel);
        }

        // POST: Movies/DeleteCostModelConfirmed/5
        [HttpPost, ActionName("DeleteCostModelConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCostModel(int id)
        {
            var costmodel = await _context.CostModel.SingleOrDefaultAsync(m => m.Id == id);
            _context.CostModel.Remove(costmodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ViewCost));
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(m => m.Id == id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool OptionExists(int id)
        {
            return _context.Options.Any(e => e.Id == id);
        }
    }
}
