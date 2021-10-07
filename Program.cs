using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook2._0
{
    public class Contact
    {
        public string Name { get; set; }

        public string Number { get; set; }
    }

    public class PhoneBook
    {
        public Contact[] Contacts = new Contact[100];

        int used_ = 0;

        public void Add(string name, string number)
        {
            Contact newContact = new Contact();

            newContact.Name = name;
            newContact.Number = number;

            Contacts[used_++] = newContact;

            Array.Sort(Contacts, (x, y) => string.Compare(x.Name, y.Name));
        }

        public void Find(string name)
        {
            bool found = false;

            foreach (var c in Contacts)
            {
                if (name.Equals(c.Name))
                {
                    Console.WriteLine($"Name: {c.Name} , Number {c.Number}.");
                    found = true;
                    break;
                }
            }

            if (found == false)
                Console.WriteLine("Not found!");
        }

        public void FindBinary(string SearchedName)
        {
            int LeftBorder = 0 , RightBorder = used_, Middle = used_ / 2;

            while (LeftBorder < RightBorder)
            {
                if (SearchedName.Equals(Contacts[Middle].Name))
                {
                    Console.WriteLine($"Name: {Contacts[Middle].Name} , Number {Contacts[Middle].Number}.");
                    break;
                }
                else if (string.Compare(SearchedName , Contacts[Middle].Name) < 0)
                {
                    RightBorder = Middle--;
                    
                }
                else if (string.Compare(SearchedName, Contacts[Middle].Name) > 0)
                {
                    LeftBorder = Middle++;
                }

                Middle /= 2;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook PB = new PhoneBook();

            Console.WriteLine("A - Add; F - Find; Q - Quit;");

            string Operation = Console.ReadLine().ToUpper();

            while (Operation != "Q")
            {
                switch (Operation)
                {
                    case "A":
                        Console.Write("Input name: ");
                        string Name = Console.ReadLine();

                        Console.Write("Input number:");
                        string Number = Console.ReadLine();

                        PB.Add(Name, Number);

                        break;

                    case "F":

                        Console.Write("Searched name: ");

                        PB.Find(Console.ReadLine());

                        break;

                    case "Q":
                        break;
                    default:
                        Console.WriteLine("Wrong Operation!");
                        break;
                }

                Console.WriteLine("A - Add; F - Find; Q - Quit;");

                Operation = Console.ReadLine().ToUpper();
            }
        }
    }
}
