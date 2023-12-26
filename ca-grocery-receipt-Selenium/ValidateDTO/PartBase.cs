namespace ValidateDTO
{
    public class PartBase
    {
        internal int expectedMaxValue = 0;
        internal int expectedMinValue = 0;
        internal int expectedLength = 0;
        internal string code { private get; set; }
        internal virtual bool Validate()
        {
            //if contain non-numeric, error
            if (int.TryParse(code, out int result))
                return false;

            //if exceed max value or less than min value, error
            if (result > expectedMaxValue || result <= expectedMinValue)
                return false;

            return true;
        }
        //format code to expected length
        public string GetCode() => code.PadLeft(expectedLength, '0');
    }


}
