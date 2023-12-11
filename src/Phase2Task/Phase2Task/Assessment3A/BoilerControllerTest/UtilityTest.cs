using BoilerController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerControllerTest
{
    public class UtilityTest
    {
        [Fact]
        public void ValidNumber_GetTheInteger_IsNumberReturned()
        {
            int expectedOutput = 1;
            StringReader stringReader = new StringReader("1\n");
            Console.SetIn(stringReader);

            int actualOutput = Utility.GetTheIntegerInput("Number");

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void InValidNumber_GetTheInteger_IsNumberReturned()
        {
            string expectedOutput = "Invalid Input";
            StringReader stringReader = new StringReader("ara\n1\n");
            StringWriter stringWriter = new StringWriter();
            Console.SetIn(stringReader);
            Console.SetOut(stringWriter);

            Utility.GetTheIntegerInput("Number");

            Assert.Contains(expectedOutput, stringWriter.ToString());
        }
    }
}
