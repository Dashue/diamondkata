namespace Diamond.tests
{
    public class ImplementationTests
    {
        [Fact]
        public void Creates_correct_number_of_rows()
        {
            Assert.Equal(1, Diamond.Create('A').Length);
            Assert.Equal(3, Diamond.Create('B').Length);
            Assert.Equal(5, Diamond.Create('C').Length);
        }
    }
}