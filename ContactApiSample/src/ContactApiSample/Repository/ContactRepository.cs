using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApiSample.Models;

namespace ContactApiSample.Repository
{
    public class ContactRepository :  IContactRepository
    {
        private static readonly List<Contacts> ContactsList = new List<Contacts>();

        public void Add(Contacts item)
        {
            ContactsList.Add(item);
        }

        public Contacts Find(string key)
        {
            return ContactsList
                .SingleOrDefault(e => e.MobilePhone.Equals(key));
        }

        public IEnumerable<Contacts> GetAll()
        {
            return ContactsList;
        }

        public void Remove(string Id)
        {
            var itemToRemove = ContactsList.SingleOrDefault(r => r.MobilePhone == Id);
            if (itemToRemove != null)
                ContactsList.Remove(itemToRemove);
        }

        public void Update(Contacts item)
        {
            var itemToUpdate = ContactsList.SingleOrDefault(r => r.MobilePhone == item.MobilePhone);
            if (itemToUpdate == null) return;
            itemToUpdate.FirstName = item.FirstName;
            itemToUpdate.LastName = item.LastName;
            itemToUpdate.IsFamilyMember = item.IsFamilyMember;
            itemToUpdate.Company = item.Company;
            itemToUpdate.JobTitle = item.JobTitle;
            itemToUpdate.Email = item.Email;
            itemToUpdate.MobilePhone = item.MobilePhone;
        }
    }
}
