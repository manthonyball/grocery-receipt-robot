namespace ValidateDTO
{
    public class Part4 : PartBase
    {
        public Part4(string inputCode)
        {
            expectedMaxValue = 99999;
            expectedMinValue = 1;
            expectedLength = 5;
            code = inputCode;
        }
    }

}