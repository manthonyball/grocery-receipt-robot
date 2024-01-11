using ValidateDTO;
namespace test_grcery_receipt
{
    public class Part1Tests
    {
        [Test]
        [Category("Validator")]
        public void Part1_ValidCode_ddMMyy_ReturnTrue()
        {
            //SetUp
            var part1 = new Part1(DateTime.Now.ToString("ddMMyy"));

            //Act
            var result = part1.Validate();

            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        [Category("Validator")]
        public void Part1_ValidCode_MMddyy_ReturnTrue()
        {
            //SetUp
            var part1 = new Part1(DateTime.Now.ToString("MMddyy"));

            //Act
            var result = part1.Validate();

            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        [Category("Validator")]
        public void Part1_InvalidCode_10DaysBefore_ReturnFalse()
        {
            //SetUp
            var part1 = new Part1(DateTime.Now.AddDays(-8).ToString("MMddyy"));

            //Act
            var result = part1.Validate();

            //Assert
            Assert.IsFalse(result);
        }

        [TestCase("999999", false)]
        [TestCase("123256", false)]
        [TestCase("000000", false)]
        [TestCase("321256", false)]
        [TestCase("ao2323", false)]
        [TestCase("1o2323", false)]
        [TestCase("12f223", false)]
        [TestCase("121a23", false)]
        [TestCase("1211r3", false)]
        [TestCase("12112f", false)]
        [TestCase("12112212", false)]
        [TestCase("a", false)]
        [TestCase("0", false)]
        [Category("Validator")]
        public void Part1_InvalidCode_Invalid_ReturnFalse(string aCase, bool expectedResult)
        {
            //SetUp
            var part1 = new Part1(aCase);

            //Act
            var result = part1.Validate();

            //Assert 
            if (expectedResult)
                Assert.IsTrue(result);
            else
                Assert.IsFalse(result);
        }
    }
}