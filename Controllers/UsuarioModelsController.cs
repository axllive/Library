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
    public class UsuarioModelsController : Controller
    {
        private readonly LibraryContext _context;
        public bool IsLoggedIn { get; set; }
        public bool IsAdmin { get; set; }

        public UsuarioModelsController(LibraryContext context)
        {
            _context = context;
            IsLoggedIn = false;
            IsAdmin = false;
        }

        public async Task<IActionResult> Index(UsuarioModel usr)
        {
            if (_context.Alunos.Any())
            {
                //if (usr.IsAdmin)
                //{
                //    return View(await _context.Alunos.ToListAsync());
                //}
                //else {
                //    return View(await _context.Alunos.FindAsync(usr.UsrID) );
                //}
                return View(await _context.Alunos.ToListAsync());
            }
            else {
                return View();
            }
            
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.Alunos
                .FirstOrDefaultAsync(m => m.UsrID == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }
            foreach (Livro n in _context.Livros)
            {
                //se o livro n foi emprestado ao UsrID
                if (n.UsrID == usuarioModel.UsrID)
                {
                    //Consulta a table dos autores e add no obj autor
                    n.Autor = _context.Autores.Find(n.AutorID);
                    //Verifica se o livro emprestado ao UsrID atual já está na lista
                    if (!usuarioModel.Livros.Contains(n))
                    {
                        //Add o livro na lista do UsrID
                        usuarioModel.Livros.Add(n);
                    }
                }
            }
            return View(usuarioModel);
        }

        // GET: UsuarioModels/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("UsrID,Usuario,Senha,Aluno,IsAdmin")] UsuarioModel usuarioModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(usuarioModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(usuarioModel);
        }


            // GET: UsuarioModels/Edit/5
            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.Alunos.FindAsync(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }
            return View(usuarioModel);
        }


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.Alunos.FirstOrDefaultAsync(s => s.UsrID == id);
            if (await TryUpdateModelAsync<UsuarioModel>(
                usuarioModel,
                "",
                s => s.Usuario, s => s.Senha, s => s.Aluno))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(usuarioModel);

        }

        // GET: UsuarioModels/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.Alunos
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.UsrID == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                TempData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }
            return View(usuarioModel);
        }

        // POST: UsuarioModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioModel = await _context.Alunos.FindAsync(id);
            if (usuarioModel == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                TempData["Sucesso"] = "Usuário apagado com sucesso!";
                _context.Alunos.Remove(usuarioModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                TempData["Sucesso"] = "Houve um erro na exclusão do usuário!";
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool UsuarioModelExists(int id)
        {
            return _context.Alunos.Any(e => e.UsrID == id);
        }
    }
}
