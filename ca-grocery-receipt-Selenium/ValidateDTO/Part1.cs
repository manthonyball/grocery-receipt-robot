using System;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        /// the code in mmddyy / ddmmyy is within 7 days of the current day
        /// return true if the code is valid
        /// return false if the code is invalid
        /// </summary>
        /// 
        internal override bool Validate()
        {
            //format validation
            if (!base.Validate())
                return false;

            if (!Utility.DateTimeExactParser(base.GetCode(), "MMddyy")
                 && !Utility.DateTimeExactParser(base.GetCode(), "ddMMyy"))
                return false;

            //biz logic validation
            int month = int.Parse(base.GetCode().Substring(0, 2));
            int day = int.Parse(base.GetCode().Substring(2, 2));
            int year = int.Parse(base.GetCode().Substring(4, 2)) + 2000;

            //to handle mmddyy / ddmmyy format
            if (month is > 12 and < 32)
            {
                var tmp_day = day;
                day = month;
                month = tmp_day; 
            }

            // should be within past 7 days of the current day
            var receiptDate = new DateTime(year, month, day);
            if ((receiptDate.Date - DateTime.Now.AddDays(-7).Date).TotalDays <= 0)
            {
                return false;
            }

            return true;
        }

    }

}