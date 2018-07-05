//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using WebApp.Models;

//namespace WebApp.Controllers
//{
//    public class AnouncesController : Controller
//    {
//        private readonly AnnouncesWebsiteContext _context;

//        public AnouncesController(AnnouncesWebsiteContext context)
//        {
//            _context = context;
//        }

//        // GET: Anounces
//        public async Task<IActionResult> Index(string searchString)
//        {
//            var announcesWebsiteContext = _context.Announce.Include(a => a.Category).Include(a => a.User);

//            var announce = from Anounces in anunturiContext select Anounces;
//            if (!String.IsNullOrEmpty(searchString))
//            {
//                anounce = anounce.Where(s => s.Title.Contains(searchString) && (s.ExpiringDate < DateTime.Now));
//            }

//            return View(await anounce.ToListAsync());
//        }

//        // GET: Anounces/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var anounces = await _context.Announce
//                .Include(a => a.Category)
//                .Include(a => a.User)
//                .Include(a => a.Comment)
//                .FirstOrDefaultAsync(m => m.AnnounceId == id);
//            if (anounces == null)
//            {
//                return NotFound();
//            }

//            return View(anounces);
//        }

//        public IActionResult Create()
//        {
//            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
//            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email");
//            return View();
//        }

//        // GET: Anounces/Create
//        public IActionResult CreateComment()
//        {
//            ViewData["AnounceId"] = new SelectList(_context.Announce, "AnounceId", "Description");
//            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email");
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> CreateComment([Bind("CommentId,CommentDesc,UserId,AnounceId")] Comment comments)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(comments);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["AnounceId"] = new SelectList(_context.Announce, "AnounceId", "Denumire", comments.AnnounceId);
//            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email", comments.UserId);
//            return View(comments);
//        }
//        // POST: Anounces/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("AnounceId,Title,Description,ReleaseDate,ExpirationDate,UserId,CategoryId")] Announce anounces)
//        {
//            if (ModelState.IsValid)
//            {
//                anounces.AddingDate = DateTime.Now;
//                anounces.ExpiringDate = DateTime.Now.AddDays(5);
//                _context.Add(anounces);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Denumire", anounces.CategoryId);
//            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email", anounces.UserId);
//            return View(anounces);
//        }

//        // GET: Anounces/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var anounces = await _context.Announce.FindAsync(id);
//            if (anounces == null)
//            {
//                return NotFound();
//            }
//            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Denumire", anounces.CategoryId);
//            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email", anounces.UserId);
//            return View(anounces);
//        }

//        // POST: Anounces/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("AnounceId,Title,Description,ReleaseDate,ExpirationDate,UserId,CategoryId")] Announce anounces)
//        {
//            if (id != anounces.AnnounceId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(anounces);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!AnouncesExists(anounces.AnnounceId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Denumire", anounces.CategoryId);
//            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email", anounces.UserId);
//            return View(anounces);
//        }

//        // GET: Anounces/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var anounces = await _context.Announce
//                .Include(a => a.Category)
//                .Include(a => a.User)
//                .FirstOrDefaultAsync(m => m.AnnounceId == id);
//            if (anounces == null)
//            {
//                return NotFound();
//            }

//            return View(anounces);
//        }

//        // POST: Anounces/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var anounces = await _context.Announce.FindAsync(id);
//            _context.Announce.Remove(anounces);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool AnouncesExists(int id)
//        {
//            return _context.Announce.Any(e => e.AnnounceId == id);
//        }

//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AnnouncesController : Controller
    {
        private readonly AnnouncesWebsiteContext _context;

        public AnnouncesController(AnnouncesWebsiteContext context)
        {
            _context = context;
        }

        // GET: Announces
        public async Task<IActionResult> Index(string searchString)
        {

            var announcesWebsiteContext = _context.Announce.Include(a => a.Category).Include(a => a.User).Include(a =>a.Comment);
            var announce = from Announces in announcesWebsiteContext select Announces;
            if (!String.IsNullOrEmpty(searchString))
            {
                announce = announcesWebsiteContext.Where(s => s.Title.Contains(searchString) && (s.ExpiringDate > DateTime.Now));
            }
            return View(await announce.ToListAsync());
        }
       //[Route("/Announces/SortbyCategory")]
        public async Task<IActionResult> SortbyCategory(string myInput)
        {

            var announcesWebsiteContext = _context.Announce.Include(a => a.Category).Include(a => a.User).Include(a => a.Comment);
            var announce = from Announces in announcesWebsiteContext select Announces;
            if (!String.IsNullOrEmpty(myInput))
            {
                announce = announcesWebsiteContext.Where(s => s.NumeleCategoriei.Contains(myInput) && (s.ExpiringDate > DateTime.Now));
            }
            return View(await announce.ToListAsync());
        }

        // GET: Announces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announce = await _context.Announce
                .Include(a => a.Category)
                .Include(a => a.User)
                .Include(a => a.Comment)
                .FirstOrDefaultAsync(m => m.AnnounceId == id);
            if (announce == null)
            {
                return NotFound();
            }

            return View(announce);
        }

        // GET: Announces/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnnounceId,Title,Description,AddingDate,ExpiringDate,CategoryId,UserId,Poza,NumeleCategoriei,to64")] Announce announce)
        {
            if (ModelState.IsValid)
            {
                announce.AddingDate = DateTime.Now;
                announce.ExpiringDate = DateTime.Now.AddDays(10);
                _context.Add(announce);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", announce.CategoryId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email", announce.UserId);
            return View(announce);
        }
        public IActionResult CreateComment()
        {
           ViewData["AnnounceId"] = new SelectList(_context.Announce, "AnnounceId", "Description");
           ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email");
         return View();
        }
       //  POST: Announces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
       // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>CreateComment([Bind("CommentId,Description,UserId,AnnounceId")] Comment comment)
        {
            if (ModelState.IsValid)
            {

              _context.Add(comment);
               await _context.SaveChangesAsync();
              return RedirectToAction(nameof(Index));
            }
            ViewData["AnnounceId"] = new SelectList(_context.Announce, "AnnounceId", "CategoryName", comment.AnnounceId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email", comment.UserId);
           return View(comment);
        }


        // GET: Announces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announce = await _context.Announce.FindAsync(id);
            if (announce == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", announce.CategoryId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email", announce.UserId);
            return View(announce);
        }

        // POST: Announces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnnounceId,Title,Description,AddingDate,ExpiringDate,CategoryId,UserId")] Announce announce)
        {
            if (id != announce.AnnounceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(announce);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnounceExists(announce.AnnounceId))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", announce.CategoryId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email", announce.UserId);
            return View(announce);
        }

        // GET: Announces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announce = await _context.Announce
                .Include(a => a.Category)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AnnounceId == id);
            if (announce == null)
            {
                return NotFound();
            }

            return View(announce);
        }

        // POST: Announces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var announce = await _context.Announce.FindAsync(id);
            _context.Announce.Remove(announce);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnounceExists(int id)
        {
            return _context.Announce.Any(e => e.AnnounceId == id);
        }

    }
}
