using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.tests
{
    public class BehaviourTests
    {
        [Fact]
        public void Diamond_renders_correctly()
        {
            var expectation = new string[] {
                                    "_____A_____",
                                    "____B_B____",
                                    "___C___C___",
                                    "__D_____D__",
                                    "_E_______E_",
                                    "F_________F",
                                    "_E_______E_",
                                    "__D_____D__",
                                    "___C___C___",
                                    "____B_B____",
                                    "_____A_____"};

            var diamond = Diamond.Create('F');

            Assert.Equal(expectation, diamond);
        }
    }
}
