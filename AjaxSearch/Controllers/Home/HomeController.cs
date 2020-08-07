using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AjaxSearch.Data;
using AjaxSearch.Models.Home;
using System.Linq;

namespace AjaxSearch.Controllers.Home
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            var model = new IndexModel
                {
                    Filter = new SearchFilter(),
                    Contacts = TestData.Contacts
                };

            return View(model);
        }

        [HttpPost]
        public PartialViewResult Search(SearchFilter filter)
        {
            return PartialView("Display", FilterContacts(filter));
        }

        public ViewResult ViewContact(Guid id)
        {
            return View(TestData.Contacts.Single(c => c.Id == id));
        }

        static IEnumerable<Contact> FilterContacts(SearchFilter filter)
        {
            return TestData.Contacts.Where(c => c.Name.Contains(filter.Term ?? string.Empty));
        }
    }
}