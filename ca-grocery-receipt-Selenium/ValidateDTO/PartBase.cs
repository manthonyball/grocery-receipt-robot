namespace ValidateDTO
{
    public class PartBase
    {
        protected int expectedMaxValue { get; init; }
        protected int expectedMinValue { get; init; }
        protected int expectedLength { get; init; }
        protected string code { private get; init; }
        public virtual bool Validate()
        {
            int result;
            //if contain non-numeric, error
            if (!int.TryParse(code, out result))
                return false;

            //if exceed max value or less than min value, error
            if (IsInvalidRange(result))
                return false;

            return true;
        }
        private bool IsInvalidRange(int result) => 
            result > expectedMaxValue ||
             result <= expectedMinValue;

        //format code to expected length
        public string GetCode() => code.PadLeft(expectedLength, '0');
    }


}
