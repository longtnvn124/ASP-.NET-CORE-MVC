using Microsoft.AspNetCore.Mvc;
using baithi1.DAL;
using baithi1.Models;
using System.Collections.Generic;


namespace baithi1.Controllers
{
    public class BooksController : Controller
    {
        private BookDAL _bookDAL = new BookDAL();
        private List<Book> lb = new List<Book>();

        public ActionResult ListBook()
        {
            
            lb = _bookDAL.ListBook();
            return View(lb);
        }

        [HttpGet]
        public ActionResult CreateBooK()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBooK(Book b)
        {
            _bookDAL.addBook(b);
            return View("ListBook",_bookDAL.ListBook());
        }

        [HttpGet]
        public ActionResult EditBook(int ID)   
        {
            lb = _bookDAL.ListBook();
            Book b = new Book();
            for(int i = 0; i < lb.Count; i++)
            {
                if(lb[i].ID == ID)
                {
                   b = lb[i];

                }
            }
            return View(b);
        }

        [HttpPost]
        public ActionResult EditBook(Book b)
        {
            _bookDAL.EditBook(b);
            return View("ListBook", _bookDAL.ListBook());
        }
        
        
        
        public ActionResult DeleteBook(int ID)
        {
            _bookDAL.DeleteBook(ID);
            return View("ListBook", _bookDAL.ListBook());
        }

    }
}
