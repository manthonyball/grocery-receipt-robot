
public class ProductDTO {     //Item1: productName ; Item2: is multi?; Item3 : is fullfillment needed?; Item4: max no. of insured persons

    public bool isMultiMemberSupported { get; set; }
    public bool isFullfillmentFormNeeded { get; set; }
    public int maxInsuredPersons { get; set; }
    public string productName { get; set; }
}
