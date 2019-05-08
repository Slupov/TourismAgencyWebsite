using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatinloAdventures.Data;
using MatinloAdventures.Data.Models;
using MatinloAdventures.Services.Contracts;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MatinloAdventures.Web.Areas.Faq.Controllers
{
    [Area("Faq")]
    public class HomeController : Controller
    {
        private readonly IGenericDataService<Data.Models.Faq> _faqs;

        public HomeController(IGenericDataService<Data.Models.Faq> faqs)
        {
            _faqs = faqs;
        }

        // GET: Faq/Faqs
        public async Task<IActionResult> Index()
        {
            return View(await _faqs.GetAllAsync());
        }

        // GET: Faq/Faqs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = await _faqs.GetSingleOrDefaultAsync(m => m.Id == id);
            if (faq == null)
            {
                return NotFound();
            }

            return View(faq);
        }

        // GET: Faq/Faqs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Faq/Faqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Data.Models.Faq faq)
        {
            if (ModelState.IsValid)
            {
                _faqs.Add(faq);
                return RedirectToAction(nameof(Index));
            }

            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();

            return View(faq);
        }

        // GET: Faq/Faqs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = await _faqs.GetSingleOrDefaultAsync(x=> x.Id == id);

            if (faq == null)
            {
                return NotFound();
            }
            return View(faq);
        }

        // POST: Faq/Faqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Data.Models.Faq faq)
        {
            if (id != faq.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _faqs.Update(faq);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await FaqExists(faq.Id))
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
            return View(faq);
        }

        // GET: Faq/Faqs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = await _faqs.GetSingleOrDefaultAsync(m => m.Id == id);
            if (faq == null)
            {
                return NotFound();
            }

            return View(faq);
        }

        // POST: Faq/Faqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faq = await _faqs.GetSingleOrDefaultAsync(x=> x.Id == id);
            _faqs.Remove(faq);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> FaqExists(int id)
        {
            return await _faqs.AnyAsync(e => e.Id == id);
        }
    }
}
