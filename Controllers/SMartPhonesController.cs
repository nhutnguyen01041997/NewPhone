using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using NewPhone.Models;
using Microsoft.AspNetCore.Hosting;
using NewPhone.Models.ViewModels;
using System.IO;

namespace NewPhone.Controllers
{
    public class SMartPhonesController : Controller
    {
        private readonly NewPhoneDbContext _context;
        private readonly NewPhoneDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;        
        public SMartPhonesController(NewPhoneDbContext context, INewPhoneRepository repo, IWebHostEnvironment hostEnvironment)
        {
            
            dbContext = context;
            webHostEnvironment = hostEnvironment;
            _context = context;

        }

        // GET: SMartPhones
        public async Task<IActionResult> Index(string SmartphoneGenre, string searchString, int p = 1)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.SMartPhones
                                            orderby b.Genre
                                            select b.Genre;
            var Smartphones = from b in _context.SMartPhones
                        select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                Smartphones = Smartphones.Where(s => s.Title!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(SmartphoneGenre))
            {
                Smartphones = Smartphones.Where(x => x.Genre == SmartphoneGenre);
            }
            var SMartPhoneGenreVM = new SMartPhoneGenreViewModel
            {
                Genres = new SelectList(await
           genreQuery.Distinct().ToListAsync()),
                SMartPhones = await Smartphones.ToListAsync()
            };
            return View(SMartPhoneGenreVM);

        }
        

        // GET: SMartPhones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sMartPhone = await _context.SMartPhones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sMartPhone == null)
            {
                return NotFound();
            }

            return View(sMartPhone);
        }
        

        // GET: SMartPhones/Create
        
            public async Task<IActionResult> Create(NewPhoneViewModels model)
            {
                if (ModelState.IsValid)
                {
                    string uniqueFileName = UploadedFile(model);

                    SMartPhone sMartPhone = new SMartPhone
                    {

                        Title = model.Title,
                        ReleaseDate = model.ReleaseDate,
                        Genre = model.Genre,
                        Price = model.Price,
                        ProfilePicture = uniqueFileName,
                    };
                    dbContext.Add(sMartPhone);
                    await dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            // GET: SMartPhones/Edit/5
            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sMartPhone = await _context.SMartPhones.FindAsync(id);
            if (sMartPhone == null)
            {
                return NotFound();
            }
            return View(sMartPhone);
        }

        // POST: SMartPhones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] SMartPhone sMartPhone)
        {
            if (id != sMartPhone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sMartPhone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SMartPhoneExists(sMartPhone.Id))
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
            return View(sMartPhone);
        }

        // GET: SMartPhones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sMartPhone = await _context.SMartPhones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sMartPhone == null)
            {
                return NotFound();
            }

            return View(sMartPhone);
        }

        // POST: SMartPhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sMartPhone = await _context.SMartPhones.FindAsync(id);
            _context.SMartPhones.Remove(sMartPhone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SMartPhoneExists(int id)
        {
            return _context.SMartPhones.Any(e => e.Id == id);
        }
        private string UploadedFile(NewPhoneViewModels model)
        {
            string uniqueFileName = null;

            if (model.ImagePhone != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagePhone.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImagePhone.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
