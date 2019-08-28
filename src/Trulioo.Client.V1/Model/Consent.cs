namespace Trulioo.Client.V1.Model
{
    /// <summary>
    /// Business class to hold name value pair to be passed for verification
    /// </summary>
    public class Consent
    {
        /// <summary>
        /// Name of the data source
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Text outlining what the user is consenting to
        /// </summary>   
        public string Text { get; set; }
        /// <summary>
        /// Url where to find more information about how the data will be used
        /// </summary>   
        public string Url { get; set; }
    }
}
