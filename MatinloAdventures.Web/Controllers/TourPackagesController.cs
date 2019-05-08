using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatinloAdventures.Data.Models;
using MatinloAdventures.Services.Contracts;
using MatinloAdventures.Web.Models.TourPackages;
using Microsoft.AspNetCore.Identity;

namespace MatinloAdventures.Web.Controllers
{
    public class TourPackagesController : Controller
    {
        private readonly IGenericDataService<TourPackage> _tourPackages;
        private readonly IGenericDataService<TourPackageComment> _tourPackageComments;
        private readonly UserManager<ApplicationUser> _users;

        public TourPackagesController(IGenericDataService<TourPackage> tourPackages, IGenericDataService<TourPackageComment> comments, UserManager<ApplicationUser> users)
        {
            _tourPackages = tourPackages;
            _tourPackageComments = comments;
            _users = users;
        }

        // GET: TourPackages
        public async Task<IActionResult> Index()
        {
            var allTourPackages = await _tourPackages.GetAllAsync();
            var grouped = allTourPackages.GroupBy(x => x.Destination).ToList();

            var loggedUser = User.Identity.IsAuthenticated ? await _users.FindByNameAsync(User.Identity.Name) : null;

            TourPackageIndexModel model = new TourPackageIndexModel();
            model.Comments = await _tourPackageComments.GetAllAsync();
            model.TourPackages = grouped;

            if (null != loggedUser)
            {
                model.Email = loggedUser.Email;
                model.Username = loggedUser.UserName;
            }

            return View(model);
        }

        // GET: TourPackages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourPackage = await _tourPackages.GetSingleOrDefaultAsync(m => m.Id == id);
            if (tourPackage == null)
            {
                return NotFound();
            }

            return View(tourPackage);
        }

        // GET: TourPackages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TourPackages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Destination,TransportationPrice,AccomodationPrice,AdventuresPrice")] TourPackage tourPackage)
        {
            if (ModelState.IsValid)
            {
                _tourPackages.Add(tourPackage);
                return RedirectToAction(nameof(Index));
            }
            return View(tourPackage);
        }

        // POST: TourPackages/CreateComment
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody]TourPackageComment tourPackageComment)
        {
            if (ModelState.IsValid)
            {
                tourPackageComment.DateCreated = DateTime.Now;

                //check for currently logged in user
                var existingUser = await _users.FindByNameAsync(tourPackageComment.Username.ToLower());

                //check if user is in database
                if (null != existingUser)
                {
                    tourPackageComment.Username = existingUser.UserName;
                    tourPackageComment.User = existingUser;
                }

                _tourPackageComments.Add(tourPackageComment);

                return Ok();
            }

            return NotFound();
        }

        // GET: TourPackages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourPackage = await _tourPackages.GetSingleOrDefaultAsync(x => x.Id == id);
            if (tourPackage == null)
            {
                return NotFound();
            }
            return View(tourPackage);
        }

        // POST: TourPackages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Destination,TransportationPrice,AccomodationPrice,AdventuresPrice")] TourPackage tourPackage)
        {
            if (id != tourPackage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _tourPackages.Update(tourPackage);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await TourPackageExists(tourPackage.Id))
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
            return View(tourPackage);
        }

        // GET: TourPackages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourPackage = await _tourPackages.GetSingleOrDefaultAsync(m => m.Id == id);
            if (tourPackage == null)
            {
                return NotFound();
            }

            return View(tourPackage);
        }

        // POST: TourPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var tourPackage = await _tourPackages.GetSingleOrDefaultAsync(x=> x.Id == id);
            _tourPackages.Remove(tourPackage);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TourPackageExists(int? id)
        {
            return await _tourPackages.AnyAsync(e => e.Id == id);
        }
    }
}
