namespace Assignment2
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class describes the person characteristics in contact manager
    /// </summary>
    public class Person
    {
        private string _name;

        private string _phone;

        private string _email;

        private string _additionalNotes;

        /// <summary>
        /// Method will get the details of the person
        /// </summary>
        /// <returns>It return the string of the details of the person</returns>
        public string GetDetails()
        {
            return $"Name: {this._name}\nPhone no: {this._phone}\nEmail: {this._email}\nAdditional Notes: {this._additionalNotes}";
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
                this._name = name;
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Name");
                return false;
            }
        }

        /// <summary>
        /// Method get the name of person class
        /// </summary>
        /// <returns>It returns string</returns>
        public string GetName()
        {
            return this._name;
        }

        /// <summary>
        /// Method returns the Email
        /// </summary>
        /// <returns>It returns string</returns>
        public string GetPhone()
        {
            return this._phone;
        }

        /// <summary>
        /// Method returns the phone number
        /// </summary>
        /// <returns>It returns string</returns>
        public string GetEmail()
        {
            return this._email;
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
                this._phone = phone;
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
                this._email = email;
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
            this._additionalNotes = notes;
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

            Person other = obj as Person;
            if (other == null)
            {
                return false;
            }

            return this._phone == other._phone;
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
