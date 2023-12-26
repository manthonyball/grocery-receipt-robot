namespace ValidateDTO
{
    public class Part1 : PartBase
    {
        public Part1(string inputCode)
        {
            expectedMaxValue = int.Parse("31" + "31" + Utility.GetYearIn2Digi().ToString());
            expectedMinValue = Utility.GetYearIn2Digi();
            expectedLength = 6;
            code = inputCode;
        }
        /// <summary>
        /// this method will validate the code by calling the base class and with the following rules:
        /// the last 2 digit of the year must be the same / +1 as the year within 7 days   
        /// for e.g. purchase date is 2019/12/31, the last 2 digit of the year must be 19 (current year) or 20 (next year)
        /// for e.g. purchase date is 2019/12/01, the last 2 digit of the year must be 19 (current year) but not others
        /// the format of the code sometimes is mmddyy, sometimes is ddmmyy, so we need to check the last 2 digit of the year
        /// return true if the code is valid
        /// return false if the code is invalid
        /// </summary>
        internal override bool Validate()
        {
            if (!base.Validate())
                return false;

            //if the last 2 digit of the year is not the same / +1 as the year within 7 days, error
            if (base.GetCode().Substring(4, 2) != Utility.GetYearIn2Digi().ToString()
                && base.GetCode().Substring(4, 2) != (Utility.GetYearIn2Digi() + 1).ToString())
                return false;

            return true;
        }

    }

}