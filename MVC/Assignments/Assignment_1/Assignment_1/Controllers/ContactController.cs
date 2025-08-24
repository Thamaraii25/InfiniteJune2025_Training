using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Assignment_1.Repositories;
using Assignment_1.Models;

namespace Assignment_1.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        IContactRepository contactRepo = null;

        public ContactController()
        {
            contactRepo = new ContactRepository();
        }

        public async Task<ActionResult> Index()
        {
            var contacts = await contactRepo.GetAllAsync();
            return View(contacts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await contactRepo.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public async Task<ActionResult> Delete(long id)
        {
            var contact = await contactRepo.FindAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            await contactRepo.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}