using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebGallery.Data;
using WebGallery.Models;

namespace WebGallery.Controllers
{
    public class PiecesController : Controller
    {
        private readonly WebGalleryContext _context;

        public PiecesController(WebGalleryContext context)
        {
            _context = context;
        }

        // GET: Pieces
        public async Task<IActionResult> Index(string searchString)
        {

            if (_context.Piece == null)
            {
                return Problem("Entity set 'WebGalleryContext.Piece'  is null.");
            }

            var pieces = from p in _context.Piece
                         select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                pieces = pieces.Where(s => 
                    s.Title!.Contains(searchString) ||
                    s.Description!.Contains(searchString)
                );
            }

            return View(await pieces.ToListAsync());
        }

        // GET: Pieces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Piece == null)
            {
                return NotFound();
            }

            var piece = await _context.Piece
                .FirstOrDefaultAsync(m => m.Id == id);
            if (piece == null)
            {
                return NotFound();
            }

            return View(piece);
        }

        // GET: Pieces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pieces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Description,Price,Quantity")] Piece piece)
        {
            if (ModelState.IsValid)
            {
                _context.Add(piece);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(piece);
        }

        // GET: Pieces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Piece == null)
            {
                return NotFound();
            }

            var piece = await _context.Piece.FindAsync(id);
            if (piece == null)
            {
                return NotFound();
            }
            return View(piece);
        }

        // POST: Pieces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Description,Price,Quantity")] Piece piece)
        {
            if (id != piece.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(piece);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PieceExists(piece.Id))
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
            return View(piece);
        }

        // GET: Pieces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Piece == null)
            {
                return NotFound();
            }

            var piece = await _context.Piece
                .FirstOrDefaultAsync(m => m.Id == id);
            if (piece == null)
            {
                return NotFound();
            }

            return View(piece);
        }

        // POST: Pieces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Piece == null)
            {
                return Problem("Entity set 'WebGalleryContext.Piece'  is null.");
            }
            var piece = await _context.Piece.FindAsync(id);
            if (piece != null)
            {
                _context.Piece.Remove(piece);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PieceExists(int id)
        {
          return (_context.Piece?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
