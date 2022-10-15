using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;

namespace Library.Controllers
{
    public class LivroesController : Controller
    {
        private readonly LibraryContext _context;

        public LivroesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Livroes
        public async Task<IActionResult> Index()
        {
            var livros = await _context.Livros
                .Include(c => c.Aluno)
                .Include(c => c.Autor)
                        .AsNoTracking()
                        .ToListAsync();

            return View( livros );
        }
        // GET: Livroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros
                .Include(l => l.Autor)
                .FirstOrDefaultAsync(m => m.LivroID == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livroes/Create
        public IActionResult Create()
        {
            ViewData["AutorID"] = new SelectList(_context.Autores, "AuthorID", "AuthorName");
            ViewData["UsrID"] = new SelectList(_context.Alunos, "UsrID", "Usuario");
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LivroID,Nome,IsBorrowed,InicioEmprestimo,FimEmprestimo,UsrID,AutorID")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                if (livro.UsrID > 0) {
                    livro.Aluno = _context.Alunos.Find(livro.UsrID);
                }
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsrID"] = new SelectList(_context.Autores, "UsrID", "Usuario", livro.UsrID);
            ViewData["AutorID"] = new SelectList(_context.Autores, "AuthorID", "AuthorName", livro.AutorID);
            return View(livro);
        }

        // GET: Livroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            ViewData["AutorID"] = new SelectList(_context.Autores, "AuthorID", "AuthorName", livro.AutorID);
            ViewData["UsrID"] = new SelectList(_context.Alunos, "UsrID", "Usuario");
            return View(livro);
        }

        // POST: Livroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LivroID,Nome,IsBorrowed,InicioEmprestimo,FimEmprestimo,UsrID,AutorID")] Livro livro)
        {
            if (id != livro.LivroID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (livro.UsrID > 0)
                    {
                        livro.Aluno = _context.Alunos.Find(livro.UsrID);
                    }
                    if (!livro.IsBorrowed) {
                        livro.UsrID = 0;
                    }
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.LivroID))
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
            ViewData["AutorID"] = new SelectList(_context.Autores, "AuthorID", "AuthorName", livro.AutorID);
            ViewData["UsrID"] = new SelectList(_context.Alunos, "UsrID", "Usuario", livro.UsrID);
            return View(livro);
        }

        // GET: Livroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros
                .Include(l => l.Autor)
                .FirstOrDefaultAsync(m => m.LivroID == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
            return _context.Livros.Any(e => e.LivroID == id);
        }
    }
}
