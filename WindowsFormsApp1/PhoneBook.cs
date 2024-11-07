using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class PhoneBook
    {
        List<Contact> list = new List<Contact>();

        public void AddContact(Contact contact)
        {
            if (!(contact.Name == "") && !(contact.Phone == ""))
            {
                list.Add(contact);
            }
         
        }

        public void RemoveContact(string name)
        {
            list.RemoveAll(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public Contact FindContact(string name)
        {
            return list.FirstOrDefault(c => c.Name.Equals(name,StringComparison.OrdinalIgnoreCase));
        }

        public List<Contact> GetList()
        {
            return list;
        }

    }
}
