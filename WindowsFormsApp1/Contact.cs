using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Contact
    {
        string name;
        string phone;

        public string Name
        {
            get { return name; }
            set
            {
                bool isTested = true;

                foreach (Char chr in value)
                {
                    if (!(Char.IsLetter(chr)) && !(chr == ' '))
                    {
                        isTested = false;
                    }
                }
                if (isTested)
                {
                    name = value;
                }
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                bool isTested = true;

                foreach (Char chr in value)
                {
                    if (Char.IsLetter(chr))
                    {
                        isTested = false;
                    }
                }
                if (isTested)
                {
                    phone = value;
                }
            }
        }


        public Contact(string name, string phone)
        {

            bool isTestedName = true;
            bool isTestedNumber = true;

            foreach (Char chr in name)
            {
                if (!(Char.IsLetter(chr)) && !(chr == ' '))
                {
                    isTestedName = false;
                }
            }
            if (isTestedName)
            {
                this.name = name;
            }

            foreach (Char chr in phone)
            {
                if (Char.IsLetter(chr))
                {
                    isTestedNumber = false;
                }
            }
            if (isTestedNumber)
            {
                this.phone = phone;
            }
        }  
        
    }
}
