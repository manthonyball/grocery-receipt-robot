using ValidateDTO;
namespace test_grcery_receipt
{
    public class Part3Tests
    {
        [Test]
        [Category("Validator")]
        public void Part3_ValidCode_ReturnTrue()
        {
            //SetUp
            var part3 = new Part3(DateTime.Now.ToString("1234"));

            //Act
            var result = part3.Validate();

            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        [Category("Validator")]
        public void Part3_InvalidCode_WrongLength_ReturnFalse()
        {
            //SetUp
            var part3 = new Part3("12345");

            //Act
            var result = part3.Validate();

            //Assert
            Assert.IsFalse(result);
        }
        [Test]
        [Category("Validator")]
        public void Part3_InvalidCode_BelowMin_ReturnFalse()
        {
            //SetUp
            var part3 = new Part3("0000");

            //Act
            var result = part3.Validate();

            //Assert
            Assert.IsFalse(result);
        }
    }
}