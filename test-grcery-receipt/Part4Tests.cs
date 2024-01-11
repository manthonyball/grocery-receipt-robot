using ValidateDTO;
namespace test_grcery_receipt
{
    public class Part4Tests
    {
        [Test]
        [Category("Validator")]
        public void Part4_ValidCode_ReturnTrue()
        {
            //SetUp
            var part4 = new Part4(DateTime.Now.ToString("12345"));

            //Act
            var result = part4.Validate();

            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        [Category("Validator")]
        public void Part4_InvalidCode_WrongLength_ReturnFalse()
        {
            //SetUp
            var part4 = new Part4("123456");

            //Act
            var result = part4.Validate();

            //Assert
            Assert.IsFalse(result);
        }
        [Test]
        [Category("Validator")]
        public void Part4_InvalidCode_BelowMin_ReturnFalse()
        {
            //SetUp
            var part4 = new Part4("00000");

            //Act
            var result = part4.Validate();

            //Assert
            Assert.IsFalse(result);
        }
    }
}