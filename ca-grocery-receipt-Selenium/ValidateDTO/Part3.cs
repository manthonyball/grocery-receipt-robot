namespace ValidateDTO
{
    public class Part3 : PartBase
    {
        public Part3(string inputCode)
        {
            expectedMaxValue = 9999;
            expectedMinValue = 1;
            expectedLength = 4;
            code = inputCode;
        } 
    }
}