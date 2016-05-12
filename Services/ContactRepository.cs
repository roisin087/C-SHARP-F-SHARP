using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestAPI.Models;

namespace RestAPI.Services
{
    public class ContactRepository
    {
        private const string CacheKey = "ContactStore";

        public ContactRepository()
        {
            //get the instance for the current request
            var _context = HttpContext.Current;

            if (_context != null)
            {
                if (_context.Cache[CacheKey] == null)
                {
                    //create a new list of contacts
                    var _contacts = new Contact[]
            {
                new Contact
                {
                    Id = 1, Name = "Sam Smith"
                },
                new Contact
                {
                    Id = 2, Name = "Tim Daily"
                }
            };
                    //store list of contacts to cache
                    _context.Cache[CacheKey] = _contacts;
                }
            }

        }


        public Contact[] GetAllContacts()
        {
            var _context = HttpContext.Current;

            if (_context != null)
            {
                return (Contact[])_context.Cache[CacheKey];
            }

            return new Contact[]
        {
            new Contact
            {
                Id = 0,
                Name = ""
            }
        };

        }


        public bool SaveContact(
            Contact contact)
        {
            var _context = HttpContext.Current;

            if (_context != null)
            {
                try
                {
                    var _currentData = ((Contact[])_context.Cache[CacheKey]).ToList();
                    _currentData.Add(
                        contact);
                    _context.Cache[CacheKey] = _currentData.ToArray();
                    
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
           
            return false;
        }

    }
}