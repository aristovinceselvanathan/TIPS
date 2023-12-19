using ExpenseTracker;

namespace ExpenseTrackerTest
{
    public class UserInterfaceTest
    {
        [Fact]
        public void InitializeUserInterface_AddTheEntry_IsChangedData()
        {
            UserInterface userInterface = new UserInterface();
            StringReader reader = new StringReader("1\n1\n200\nLunch\n");
            Console.SetIn(reader);
            string expectedCategory = "Lunch";
            int expectedAmount = 200;
            DateTime expectedDate = DateTime.Now.Date;

            userInterface.ManipulateEntry(userInterface.AddTheEntry);

            Assert.Equal(expectedCategory, userInterface.Expenses.First().Category);
            Assert.Equal(expectedAmount,  userInterface.Expenses.First().Amount);
            Assert.Equal(expectedDate, userInterface.Expenses.First().EntryDate);
        }

        [Fact]
        public void InitializeUserInterface_UpdateTheEntry_IsChangedData()
        {
            UserInterface userInterface = new UserInterface();
            StringReader reader = new StringReader("1\n1\n200\nLunch\n1\n4\n0\n2\n400\n2\n");
            Console.SetIn(reader);
            string expectedCategory = "Lunch";
            int expectedAmount = 400;
            DateTime expectedDate = DateTime.Now.Date;

            userInterface.ManipulateEntry(userInterface.AddTheEntry);
            userInterface.ManipulateEntry(userInterface.UpdateTheEntry);

            Assert.Equal(expectedCategory, userInterface.Expenses.First().Category);
            Assert.Equal(expectedAmount, userInterface.Expenses.First().Amount);
            Assert.Equal(expectedDate, userInterface.Expenses.First().EntryDate);
        }

        [Fact]
        public void InitializeUserInterface_UpdateTheEntryByDate_IsChangedData()
        {
            UserInterface userInterface = new UserInterface();
            StringReader reader = new StringReader($"1\n1\n200\nLunch\n1\n1\n1\n1\n0\n2\n400\n2\n");
            Console.SetIn(reader);
            string expectedCategory = "Lunch";
            int expectedAmount = 400;
            DateTime expectedDate = DateTime.Now.Date;

            userInterface.ManipulateEntry(userInterface.AddTheEntry);
            userInterface.ManipulateEntry(userInterface.UpdateTheEntry);

            Assert.Equal(expectedCategory, userInterface.Expenses.First().Category);
            Assert.Equal(expectedAmount, userInterface.Expenses.First().Amount);
            Assert.Equal(expectedDate, userInterface.Expenses.First().EntryDate);
        }

        [Fact]
        public void InitializeUserInterface_UpdateTheEntryByCategory_IsChangedData()
        {
            UserInterface userInterface = new UserInterface();
            StringReader reader = new StringReader($"1\n1\n200\nLunch\n1\n2\nLunch\n0\n2\n400\n2\n");
            Console.SetIn(reader);
            string expectedCategory = "Lunch";
            int expectedAmount = 400;
            DateTime expectedDate = DateTime.Now.Date;

            userInterface.ManipulateEntry(userInterface.AddTheEntry);
            userInterface.ManipulateEntry(userInterface.UpdateTheEntry);

            Assert.Equal(expectedCategory, userInterface.Expenses.First().Category);
            Assert.Equal(expectedAmount, userInterface.Expenses.First().Amount);
            Assert.Equal(expectedDate, userInterface.Expenses.First().EntryDate);
        }

        [Fact]
        public void InitializeUserInterface_UpdateTheEntryByAmount_IsChangedData()
        {
            UserInterface userInterface = new UserInterface();
            StringReader reader = new StringReader($"1\n1\n200\nLunch\n1\n3\n200\n200\n0\n2\n400\n2\n");
            Console.SetIn(reader);
            string expectedCategory = "Lunch";
            int expectedAmount = 400;
            DateTime expectedDate = DateTime.Now.Date;

            userInterface.ManipulateEntry(userInterface.AddTheEntry);
            userInterface.ManipulateEntry(userInterface.UpdateTheEntry);

            Assert.Equal(expectedCategory, userInterface.Expenses.First().Category);
            Assert.Equal(expectedAmount, userInterface.Expenses.First().Amount);
            Assert.Equal(expectedDate, userInterface.Expenses.First().EntryDate);
        }
    }
}