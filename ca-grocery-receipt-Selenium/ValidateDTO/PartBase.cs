﻿namespace ValidateDTO
{
    public class PartBase
    {
        internal int expectedMaxValue = 0;
        internal int expectedMinValue = 0;
        internal int expectedLength = 0;
        internal string code { private get; set; }
        internal virtual bool Validate()
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
        private bool IsInvalidRange(int result) => result > expectedMaxValue || result <= expectedMinValue;
        //format code to expected length
        public string GetCode() => code.PadLeft(expectedLength, '0');
    }


}
