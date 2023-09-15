namespace CollectionsAndGenerics
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Book class of the library management system
    /// </summary>
    public class BookClass
    {
        /// <summary>
        /// Gets or sets it stores the title of the book
        /// </summary>
        /// <value>
        /// value is the type of the string
        /// </value>
        public string TitleOfTheBook { get; set; }

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

            BookClass other = obj as BookClass;
            if (other == null)
            {
                return false;
            }

            return this.TitleOfTheBook.Equals(other.TitleOfTheBook);
        }

        /// <summary>
        /// Method overrides the toString method in object class
        /// </summary>
        /// <param name="obj"> It uses the instance of the object class</param>
        /// <returns>It returns string</returns>
        public override string ToString()
        {
            return this.TitleOfTheBook;
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