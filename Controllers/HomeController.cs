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
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public string Message { get; private set; }

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> Options(string optionValues, string searchString)
        {
            IQueryable<string> optionValue = from o in _context.Options
                                             orderby o.OptionValue
                                             select o.OptionValue;

            var options = from o in _context.Options select o;

            if (!String.IsNullOrEmpty(searchString))
            {
                options = options.Where(s => s.OptionName.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(optionValues))
            {
                options = options.Where(x => x.OptionValue == optionValues);
            }

            var optionsValueVM = new OptionsValueViewModel();
            optionsValueVM.optionValues = new SelectList(await optionValue.Distinct().ToListAsync());
            optionsValueVM.options = await options.ToListAsync();

            return View(optionsValueVM);

            //return View(await options.ToListAsync());
            //var optionsList = _context.Options.ToList();
            //return View(optionsList);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.Options.SingleOrDefaultAsync(m => m.Id == id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateChanged,OptionName,OptionValue")] Options options)
        {
            var record = (from c in _context.Options
                          where c.OptionName.ToLower().Trim() == options.OptionName.ToLower().Trim()
                          select c).FirstOrDefaultAsync();


            if (ModelState.IsValid)
            {
                if (await record == null)
                {
                    _context.Add(options);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(options));
                }
                ModelState.AddModelError("OptionName", "Option Name already exists");
                return View(options);
            }
            return View(options);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,DateChanged,OptionName,OptionValue")] Options options)
        {
            var record = (from c in _context.Options
                          where c.OptionName.ToLower().Trim() == options.OptionName.ToLower().Trim()
                          select c).FirstOrDefault();

            if (record != null)
            {
                ModelState.AddModelError("OptionName", "Option Name already exists");
                return View(options);
            }

            if (id != options.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(options);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionExists(options.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Options));
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var option = await _context.Options
                .SingleOrDefaultAsync(m => m.Id == id);
            if (option == null)
            {
                return NotFound();
            }

            return View(option);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var option = await _context.Options.SingleOrDefaultAsync(m => m.Id == id);
            _context.Options.Remove(option);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Options));
        }



        private bool OptionExists(int id)
        {
            return _context.Options.Any(e => e.Id == id);
        }
    }
}
