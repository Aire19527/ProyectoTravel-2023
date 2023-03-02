using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Infraestructure.Core.Data;
using Infraestructure.Entity.Model;

namespace Travel.Web.Controllers
{
    public class EditorialController : Controller
    {
        private readonly DataContext _context;

        public EditorialController(DataContext context)
        {
            _context = context;
        }

        // GET: Editorial
        public async Task<IActionResult> Index()
        {
            return View(await _context.EditorialEntity.ToListAsync());
        }

        // GET: Editorial/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editorialEntity = await _context.EditorialEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (editorialEntity == null)
            {
                return NotFound();
            }

            return View(editorialEntity);
        }

        // GET: Editorial/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editorial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Sede")] EditorialEntity editorialEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editorialEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(editorialEntity);
        }

        // GET: Editorial/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editorialEntity = await _context.EditorialEntity.FindAsync(id);
            if (editorialEntity == null)
            {
                return NotFound();
            }
            return View(editorialEntity);
        }

        // POST: Editorial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Sede")] EditorialEntity editorialEntity)
        {
            if (id != editorialEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editorialEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditorialEntityExists(editorialEntity.Id))
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
            return View(editorialEntity);
        }

        // GET: Editorial/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editorialEntity = await _context.EditorialEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (editorialEntity == null)
            {
                return NotFound();
            }

            return View(editorialEntity);
        }

        // POST: Editorial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var editorialEntity = await _context.EditorialEntity.FindAsync(id);
            _context.EditorialEntity.Remove(editorialEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditorialEntityExists(int id)
        {
            return _context.EditorialEntity.Any(e => e.Id == id);
        }
    }
}
