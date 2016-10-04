using System.Collections.Generic;

namespace Trulioo.Client.V1.Model
{
    /// <summary>
    /// Fields specific for the country the verification is being done for.  
    /// Call configuration/v1/fields/Identity Verification/countryCode to get the list of fields that are valid for your configuration
    /// </summary>
    public class CountrySpecific : Dictionary<string, Dictionary<string, string>>
    {
    }
}
