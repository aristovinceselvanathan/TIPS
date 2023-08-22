namespace Assignment2
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program Class
    /// </summary>
    public class Program
    {
        private static List<Person> list = new List<Person>();

        /// <summary>
        /// Main method prompts the user to choose the operations of the contact manager
        /// Add operation takes the required information from the user
        /// Search operations use the linear search person list for any matching contacts
        /// Remove operations search for the name, phone number, email and ask the user to remove it
        /// Display all it is simply display every contacts
        /// </summary>
        /// <param name="args"> It is String array in the parameters of the main method</param>
        public static void Main(string[] args)
        {
            int choose, option;
            bool flag = true;
            string name, phone, email, notes;
            Person? person;
            List<Person> people = new List<Person>();

            Console.WriteLine("Welcome to Contacts Manager");
            while (flag)
            {
                Console.Write("Actions 1.Add 2.Remove 3.Search 4.Displyall 5.Exit: ");
                int.TryParse(Console.ReadLine(), out choose);

                Console.Clear();
                switch (choose)
                {
                    case 1:
                        Console.Write("Name: ");
                        name = CheckStringIsNull(Console.ReadLine());
                        Console.Write("Phone number: ");
                        phone = CheckStringIsNull(Console.ReadLine());
                        Console.Write("Email: ");
                        email = CheckStringIsNull(Console.ReadLine());
                        Console.Write("Notes: ");
                        notes = CheckStringIsNull(Console.ReadLine());

                        if (IsValidString(name))
                        {
                            Add(name, phone, email, notes);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Name");
                        }

                        Console.WriteLine("Press any key to Continue: ");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        person = PersonSearch();
                        if (person != null && Remove(person))
                        {
                            Console.WriteLine("Person is removed successfully");
                            Console.WriteLine("Press any key to Continue: ");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        break;
                    case 3:
                        person = PersonSearch();
                        if (person != null)
                        {
                            Console.Write("Are you want to edit? 1 - Yes or 0 - No: ");
                            int.TryParse(Console.ReadLine(), out option);
                            if (option == 1)
                            {
                                Edit(person);
                            }
                            else
                            {
                                Console.WriteLine("Exiting...");
                                Console.WriteLine("Press any key to Continue: ");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }

                        break;
                    case 4:
                        Displayall();
                        break;
                    case 5:
                        flag = false;
                        Console.WriteLine("Thank you for using Contacts Manager");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }

        /// <summary>
        /// Method is to add contact to the directory (List of Person). It sets the values to the person
        /// </summary>
        /// <param name="name">It takes the string as parameter for name</param>
        /// <param name="phone">It takes the string as parameter for phone</param>
        /// <param name="email">It takes the string as parameter for email</param>
        /// <param name="notes">It takes the string as parameter for notes</param>
        public static void Add(string name, string phone, string email, string notes)
        {
            Person person = new Person();
            bool isPhone = person.SetPhone(phone);
            bool isEmail = person.SetEmail(email);

            if (isPhone && isEmail)
            {
                person.SetName(name);
                person.SetNotes(notes);
                if (!list.Contains(person))
                {
                    list.Add(person);
                    Console.WriteLine("Person is added successfully");
                }
                else
                {
                    Console.WriteLine("The phone number is already present");
                }
            }

            list.Sort((a, b) => a.GetName().CompareTo(b.GetName()));
        }

        /// <summary>
        /// Method is to remove the contact from the directory (List of Person).
        /// </summary>
        /// <param name="person">It takes the person as a parameter</param>
        /// <returns>It returns the Boolean of person can be removed</returns>
        public static bool Remove(Person person)
        {
            if (list.Remove(person) == false)
            {
                Console.WriteLine("Person name is not in the list");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method is to edit the contacts in the directory (List of Person).
        /// </summary>
        /// <param name="person">It takes the person as a parameter</param>
        public static void Edit(Person person)
        {
            int option;
            string temp;

            Console.Write("What do you want to edit: 1.Name 2.Phone Number 3.Email 4.Additional Notes: ");
            int.TryParse(Console.ReadLine(), out option);
            temp = CheckStringIsNull(Console.ReadLine());

            switch (option)
            {
                case 1:
                    person.SetName(temp);
                    break;
                case 2:
                    person.SetPhone(temp);
                    break;
                case 3:
                    person.SetEmail(temp);
                    break;
                case 4:
                    person.SetNotes(temp);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }

        /// <summary>
        /// Method to search for name, phone number, email in directory (List of Person)
        /// </summary>
        /// <returns>It returns the selected person</returns>
        public static List<Person> Search()
        {
            int option;
            string temp1;
            List<Person> temp = new List<Person>();

            if (list.Count == 0)
            {
                Console.WriteLine("Directory is Empty !!!");
            }
            else
            {
                Console.Write("Search By 1.Name 2.Phone Number 3.Email: ");
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid Choice");
                }

                Console.Write("Enter Search: ");
                temp1 = CheckStringIsNull(Console.ReadLine());
                foreach (Person p1 in list)
                {
                    switch (option)
                    {
                        case 1:
                            if (p1.GetName().ToLower().Contains(temp1.ToLower()))
                            {
                                temp.Add(p1);
                            }

                            break;
                        case 2:
                            if (p1.GetPhone().ToLower().Contains(temp1.ToLower()))
                            {
                                temp.Add(p1);
                            }

                            break;
                        case 3:
                            if (p1.GetEmail().ToLower().Contains(temp1.ToLower()))
                            {
                                temp.Add(p1);
                            }

                            break;
                        default:
                            Console.WriteLine("Invalid Selection");
                            break;
                    }
                }
            }

            return temp;
        }

        /// <summary>
        /// Method will allow to select the contact in search or remove operations
        /// </summary>
        /// <returns>It returns the person object</returns>
        public static Person? PersonSearch()
        {
            List<Person> people = Search();
            Person? person = null;
            for (int i = 0; i < people.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. " + people.ElementAt(i).GetDetails());
            }

            if (list.Count() != 0 && people.Count() == 0)
            {
                Console.WriteLine("Person Doesn't Exists");
                Console.WriteLine("Press any key to Continue: ");
                Console.ReadKey();
                Console.Clear();
                return null;
            }
            else if (people.Count() != 0)
            {
                Console.WriteLine("Which Contact should you want to pick by number? ");
                int.TryParse(Console.ReadLine(), out int id);
                try
                {
                    person = people.ElementAt(id - 1);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Selection");
                }
            }

            return person;
        }

        /// <summary>
        /// Method display all the contacts in the directory (List of Person)
        /// </summary>
        public static void Displayall()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Directory is Empty !!!");
            }
            else
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}. " + list.ElementAt(i).GetDetails());
                }
            }

            Console.WriteLine("Press any Key to Continue: ");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Method checks for the string is valid
        /// </summary>
        /// <param name="input">It takes the string as the input</param>
        /// <returns>It returns integer</returns>
        public static bool IsValidString(string input)
        {
            Regex pattern = new Regex("^[a-zA-Z\\s]*$");
            if (pattern.IsMatch(input))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method checks for string is null or not
        /// </summary>
        /// <param name="input">It takes the string as inut</param>
        /// <returns>It returns the string</returns>
        public static string CheckStringIsNull(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return " ";
            }

            return input;
        }
    }
}
