using ValidateDTO;
namespace test_grcery_receipt
{
    public class Part2Tests
    {
        [Test]
        [Category("Validator")]
        public void Part2_ValidCode_mmsshh_ReturnTrue()
        {
            //SetUp
            var part2 = new Part2(DateTime.Now.ToString("hhmmss"));

            //Act
            var result = part2.Validate();

            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        [Category("Validator")]
        public void Part2_InvalidCode_WrongLength_ReturnFalse()
        {
            //SetUp
            var part2 = new Part2(string.Concat(DateTime.Now.ToString("hhmmss"), "999"));

            //Act
            var result = part2.Validate();

            //Assert
            Assert.IsFalse(result);
        }
        [TestCase("011212", true)]
        [TestCase("235959", true)]
        [TestCase("121256", true)]
        [TestCase("999999", false)]
        [TestCase("129956", false)]
        [TestCase("991256", false)]
        [TestCase("000000", false)]
        [TestCase("ao2323", false)]
        [TestCase("1o2323", false)]
        [TestCase("12f223", false)]
        [TestCase("121a23", false)]
        [TestCase("1211r3", false)]
        [TestCase("12112f", false)]
        [TestCase("a", false)]
        [TestCase("0", false)]
        [Category("Validator")]
        public void Part2_InvalidCode_Invalid_ReturnFalse(string aCase, bool expectedResult)
        {
            //SetUp
            var part2 = new Part2(aCase);

            //Act
            var result = part2.Validate();

            //Assert 
            if (expectedResult)
                Assert.IsTrue(result);
            else
                Assert.IsFalse(result);
        }
    }
}