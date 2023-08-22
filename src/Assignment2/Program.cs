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
            string? name, phone, email, notes;
            Person? person;
            List<Person> people = new List<Person>();
            Console.WriteLine("Welcome to Contacts Manager");
            while (flag)
            {
                Console.Write("Actions 1.Add 2.Remove 3.Search 4.Displyall 5.Exit: ");
                choose = IntegerInput(NullException(Console.ReadLine()));
                Console.Clear();
                switch (choose)
                {
                    case 1:
                        Console.Write("Name: ");
                        name = NullException(Console.ReadLine());
                        Console.Write("Phone number: ");
                        phone = NullException(Console.ReadLine());
                        Console.Write("Email: ");
                        email = NullException(Console.ReadLine());
                        Console.Write("Notes: ");
                        notes = NullException(Console.ReadLine());
                        if (IsValidString(name))
                        {
                            Add(name, phone, email, notes);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Name");
                        }

                        Console.WriteLine("Press Enter to Continue: ");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        person = PersonSearch();
                        if (person != null && Remove(person))
                        {
                            Console.WriteLine("Person is removed successfully");
                            Console.WriteLine("Press Enter to Continue: ");
                            Console.ReadLine();
                            Console.Clear();
                        }

                        break;
                    case 3:
                        person = PersonSearch();
                        if (person != null)
                        {
                            Console.Write("Are you want to edit? 1 - Yes or 0 - No: ");
                            option = IntegerInput(NullException(Console.ReadLine()));
                            if (option == 1)
                            {
                                Edit(person);
                            }
                            else
                            {
                                Console.WriteLine("Exiting...");
                                Console.WriteLine("Press Enter to Continue: ");
                                Console.ReadLine();
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
            bool phonec = person.SetPhone(phone);
            bool emailc = person.SetEmail(email);
            if (phonec && emailc)
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
            int i;
            string? temp;
            Console.Write("What do you want to edit: 1.Name 2.Phone Number 3.Email 4.Additional Notes: ");
            i = IntegerInput(NullException(Console.ReadLine()));
            temp = NullException(Console.ReadLine());
            if (i == 1)
            {
                person.SetName(temp);
            }
            else if (i == 2)
            {
                person.SetPhone(temp);
            }
            else if (i == 3)
            {
                person.SetEmail(temp);
            }
            else if (i == 4)
            {
                person.SetNotes(temp);
            }
            else
            {
                Console.WriteLine("Invalid Choice");
            }
        }

        /// <summary>
        /// Method to search for name, phone number, email in directory (List of Person)
        /// </summary>
        /// <returns>It returns the selected person</returns>
        public static List<Person> Search()
        {
            int option;
            string? temp1;
            List<Person> temp = new List<Person>();
            if (list.Count == 0)
            {
                Console.WriteLine("Directory is Empty !!!");
            }
            else
            {
                Console.Write("Search By 1.Name 2.Phone Number 3.Email: ");
                option = IntegerInput(NullException(Console.ReadLine()));
                if (option == -1)
                {
                    Console.WriteLine("Invalid Choice");
                }

                Console.Write("Enter Search: ");
                temp1 = NullException(Console.ReadLine());
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
            int id, i;
            Person? person = null;
            for (i = 0; i < people.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. " + people.ElementAt(i).GetDetails());
            }

            if (list.Count() != 0 && people.Count() == 0)
            {
                Console.WriteLine("Person Doesn't Exists");
                Console.WriteLine("Press Enter to Continue: ");
                Console.ReadLine();
                Console.Clear();
                return null;
            }
            else if (people.Count() != 0)
            {
                Console.WriteLine("Which Contact should you want to pick by number? ");
                id = IntegerInput(NullException(Console.ReadLine()));
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
            int i;
            if (list.Count == 0)
            {
                Console.WriteLine("Directory is Empty !!!");
            }
            else
            {
                i = 1;
                foreach (Person p1 in list)
                {
                    Console.Write($"{i}. ");
                    Console.WriteLine(p1.GetDetails());
                    i++;
                }
            }

            Console.WriteLine("Press Enter to Continue: ");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Method is error handling of input mismatch
        /// </summary>
        /// <param name="input">It takes the string as the input</param>
        /// <returns>It returns integer</returns>
        public static int IntegerInput(string input)
        {
            try
            {
                return Convert.ToInt32(input);
            }
            catch
            {
                return -1;
            }
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
        /// <param name="input">It takes the string</param>
        /// <returns>it returns string</returns>
        public static string NullException(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return " ";
            }
            else
            {
                return input;
            }
        }
    }
}
