using System;
using System.Collections.Generic;

public class ConfigDTO {
    public DateTime _todayIs = DateTime.Now;
    public DateTime todayIs => _todayIs;
    public DateTime date2 => _todayIs.AddYears(-40);
    public bool isBroker { get; set; }
    public ProductEnum.Product productCode { get; set; }
    public char environment { get; set; }
    public int numberOfInsured { get; set; }
    public string receiveMail { get; set; }
    public char gender { get; set; }
    public string language { get; set; }
    public List<OptionalBenefitEnum.OptionalBenefit> optionalBenefitItems { get; set; }
}
