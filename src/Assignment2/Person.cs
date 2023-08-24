namespace Assignment2
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class describes the person characteristics in contact manager
    /// </summary>
    public class Person
    {
        private string Name { get; set; }

        private string Phone { get; set; }

        private string Email { get; set; }

        private string AdditionalNotes { get; set; }

        /// <summary>
        /// Method will get the details of the person
        /// </summary>
        /// <returns>It return the string of the details of the person</returns>
        public string GetDetails()
        {
            return $"Name: {this.Name}\nPhone no: {this.Phone}\nEmail: {this.Email}\nAdditional Notes: {this.AdditionalNotes}";
        }

        /// <summary>
        /// Method is to set the name
        /// </summary>
        /// <param name="name">Method will take the name as a string to set the name</param>
        /// <returns>It returns boolean datatype</returns>
        public bool SetName(string name)
        {
            Regex pattern = new Regex("^[a-zA-Z\\s]*$");
            if (pattern.IsMatch(name))
            {
                this.Name = name;
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Name");
            }
            return false;
        }

        /// <summary>
        /// Method get the name of person class
        /// </summary>
        /// <returns>It returns string</returns>
        public string GetName()
        {
            return this.Name;
        }

        /// <summary>
        /// Method returns the Email
        /// </summary>
        /// <returns>It returns string</returns>
        public string GetPhone()
        {
            return this.Phone;
        }

        /// <summary>
        /// Method returns the phone number
        /// </summary>
        /// <returns>It returns string</returns>
        public string GetEmail()
        {
            return this.Email;
        }

        /// <summary>
        /// Method is to set the phone number
        /// </summary>
        /// <param name="phone">Method will take the name as a string to set the phone</param>
        /// <returns>It returns the boolean</returns>
        public bool SetPhone(string phone)
        {
            Regex regex = new Regex("^[0-9]{10}$");
            if (regex.IsMatch(phone))
            {
                this.Phone = phone;
            }
            else
            {
                Console.WriteLine("Invalid Phone number");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method is to set the email
        /// </summary>
        /// <param name="email">Method will take the name as a string to set the email</param>
        /// <returns>It returns the Boolean type</returns>
        public bool SetEmail(string email)
        {
            Regex regex = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,}$");
            if (regex.IsMatch(email))
            {
                this.Email = email;
            }
            else
            {
                Console.WriteLine("Invalid Email");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method is to set the notes
        /// </summary>
        /// <param name="notes">Method will take the name as a string to set the Additional Notes</param>
        public void SetNotes(string notes)
        {
            this.AdditionalNotes = notes;
        }

        /// <summary>
        /// Method overrides the equals method in object class
        /// </summary>
        /// <param name="obj"> It uses the instance of the object class</param>
        /// <returns>It returns bool</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Person? other = obj as Person;
            if (other == null)
            {
                return false;
            }

            return this.Phone == other.Phone;
        }

        /// <summary>
        /// It overrides the GetHashCode when Equals Method overridden in the person class
        /// </summary>
        /// <returns>It returns the Integer</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
