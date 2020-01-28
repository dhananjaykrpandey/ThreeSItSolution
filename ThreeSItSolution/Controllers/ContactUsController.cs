using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThreeSItSolution.Models;

namespace ThreeSItSolution.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly Db3SItSoultion _context;

        public ContactUsController(Db3SItSoultion context)
        {
            _context = context;
        }

        // GET: MContactUs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MContactUs.ToListAsync().ConfigureAwait(true));
        }

        // GET: MContactUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mContactUs = await _context.MContactUs
                .FirstOrDefaultAsync(m => m.IID == id).ConfigureAwait(true);
            if (mContactUs == null)
            {
                return NotFound();
            }

            return View(mContactUs);
        }

        // GET: MContactUs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MContactUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IID,CName,CEmailId,CSubject,CMessage,DCreateDate")] MContactUs mContactUs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mContactUs);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return RedirectToAction(nameof(Index));
            }
            return View(mContactUs);
        }

        // GET: MContactUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mContactUs = await _context.MContactUs.FindAsync(id);
            if (mContactUs == null)
            {
                return NotFound();
            }
            return View(mContactUs);
        }

        // POST: MContactUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IID,CName,CEmailId,CSubject,CMessage,DCreateDate")] MContactUs mContactUs)
        {
            if (id != mContactUs.IID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mContactUs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MContactUsExists(mContactUs.IID))
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
            return View(mContactUs);
        }

        // GET: MContactUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mContactUs = await _context.MContactUs
                .FirstOrDefaultAsync(m => m.IID == id);
            if (mContactUs == null)
            {
                return NotFound();
            }

            return View(mContactUs);
        }

        // POST: MContactUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mContactUs = await _context.MContactUs.FindAsync(id);
            _context.MContactUs.Remove(mContactUs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MContactUsExists(int id)
        {
            return _context.MContactUs.Any(e => e.IID == id);
        }
    }
}
