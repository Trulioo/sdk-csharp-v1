namespace Trulioo.Client.V1.Model
{
    public class BusinessRegistrationNumberMask
    {
        /// <summary>
        /// The mask used to validate the format of the business registration number
        /// </summary>
        public string Mask { get; set; }

        /// <summary>
        /// Flag showing whether we can ignore whitespace
        /// </summary>
        public bool IgnoreWhitespace { get; set; }

        /// <summary>
        /// Flag showing whether we can ignore special character
        /// </summary>
        public bool IgnoreSpecialCharacter { get; set; }

        /// <summary>
        /// Flag showing if 0s should be prepended to meet Mask Length
        /// </summary>
        public bool PrependZeroes { get; set; }

        /// <summary>
        /// Flag showing if repeating characters should be overwritten
        /// </summary>
        public bool OverwriteRepeating { get; set; }
    }
}
