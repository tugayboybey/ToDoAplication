using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoAplication.Database;
using ToDoAplication.Models;

namespace ToDoAplication.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoDbContext _context;
        public ToDoController(ToDoDbContext context)
        {
            _context = context;
        }
        // GET: ToDoController
        public IActionResult TamamlananGorev() 
        {

            var result = _context.toDos.Where(x => x.status == true).OrderBy(x=>x.Date).ToList();
            return View(result);

        }
        [HttpGet]
        public IActionResult TamamlananGorevEdit(int id) 
        {

            var result = _context.toDos.Find(id);



            return View(result);

        }
        [HttpPost]
        public IActionResult TamamlananGorevEdit(ToDo p)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    _context.toDos.Update(p);


                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Index()
        {
            
            var result = _context.toDos.Where(x => x.status == false).OrderBy(x => x.Date).ToList();

            ViewBag.sorgu = _context.toDos.Where(x => x.Date < DateTime.Now).FirstOrDefault();//günü geçmemiş olanları listeledi.



            return View(result);
        }

        // GET: ToDoController/Details/5
        public ActionResult Details(int id)
        {
            var result= _context.toDos.Find(id);

            return View(result);
        }

        // GET: ToDoController/Create
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: ToDoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDo p)
        {
            _context.toDos.Add(p);
            _context.SaveChanges();

            return RedirectToAction("Index", "ToDo");
        }

        // GET: ToDoController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _context.toDos.Find(id);
        

           
            return View(result);
        }

        // POST: ToDoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ToDo p)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    _context.toDos.Update(p);
                    

                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _context.toDos.Find(id);

            return View(result);
        }

        // POST: ToDoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var result = _context.toDos.Find(id);
                if (result != null)
                {
                    _context.toDos.Remove(result);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
               
            }
            catch
            {
                return View();
            }
        }
    }
}
