using System;

namespace ValidateDTO
{
    public class Part2 : PartBase
    {
        public Part2(string inputCode)
        {
            expectedMaxValue = 235959;
            expectedMinValue = 0;
            expectedLength = 6;
            code = inputCode;
        }
        /// <summary>
        /// this method will validate the code by calling the base class and with the following rules:
        /// the first 2 digit should be 00-23
        /// the 2 and 3 digit should be 00-59
        /// the last 2 digit should be 00-59
        /// return true if the code is valid
        /// return false if the code is invalid 
        /// </summary> 
        /// <returns>bool</returns>
        ///
        internal override bool Validate()
        {
            if (!base.Validate())
                return false;

            //if the first 2 digit is not 00-23, error
            if (int.Parse(base.GetCode().AsSpan(0, 2)) > 23)
                return false;

            //if the 2 and 3 digit is not 00-59, error
            if (int.Parse(base.GetCode().AsSpan(2, 2)) > 59)
                return false;

            //if the last 2 digit is not 00-59, error
            if (int.Parse(base.GetCode().AsSpan(4, 2)) > 59)
                return false;

            return true;
        }
    }

}