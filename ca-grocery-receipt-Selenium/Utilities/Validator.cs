using System;

class Validator {
    public static bool IsSupportMultiMbr(ProductDTO p) => p.isMultiMemberSupported;

    public static bool IsValidNoOfInsuredMbr(ProductDTO p, int numberOfInsured) => !(numberOfInsured > p.maxInsuredPersons);
    public static void CheckProduct(ProductDTO p, int numberOfInsured) {
        if (numberOfInsured > 0 && !IsSupportMultiMbr(p))
            throw new Exception("product not support multi-members");
        if (numberOfInsured > 0 && !IsValidNoOfInsuredMbr(p, numberOfInsured))
            throw new Exception("exceeded max of insured person");
    }
}
