using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Trulioo.Client.V1.Model;
using Trulioo.Client.V1.URI;

namespace Trulioo.Client.V1
{
    /// <summary>
    /// Provides a class for working with Trulioo Configuration.
    /// </summary>
    public class Configuration
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        /// <param name="service">
        /// An object representing the root of Trulioo configuration service.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="service"/> is <c>null</c>.
        /// </exception>
        protected internal Configuration(TruliooApiClient service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));

            _service = service;
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        /// <summary>
        /// Consents required for the provided country and configuration
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="configurationName"></param>
        public async Task<IEnumerable<string>> GetСonsentsAsync(string countryCode, string configurationName)
        {
            var resource = new ResourceName("consents", configurationName, countryCode);
            var response = await _context.GetAsync<IEnumerable<string>>(_configurationNamespace, resource).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Details about consents required for the provided country and configuration
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="configurationName"></param>
        public async Task<IEnumerable<Consent>> GetDetailedСonsentsAsync(string countryCode, string configurationName)
        {
            var resource = new ResourceName("detailedConsents", configurationName, countryCode);
            var response = await _context.GetAsync<IEnumerable<Consent>>(_configurationNamespace, resource).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Get Country Codes configured for your account
        /// </summary>
        /// <param name="configurationName"></param>
        public async Task<IEnumerable<string>> GetCountryCodesAsync(string configurationName)
        {
            var resource = new ResourceName("countrycodes", configurationName);
            var response = await _context.GetAsync<IEnumerable<string>>(_configurationNamespace, resource).ConfigureAwait(false);
            return response;
        }


        /// <summary>
        /// Gets the provinces states or other subdivisions for a country, mostly matches ISO 3166-2
        /// </summary>
        /// <param name="countryCode"></param>
        public async Task<IEnumerable<CountrySubdivision>> GetCountrySubdivisionsAsync(string countryCode)
        {
            var resource = new ResourceName("countrysubdivisions", countryCode);
            var response = await _context.GetAsync<IList<CountrySubdivision>>(_configurationNamespace, resource).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Gets all jurisdictions of incorporation for all countries if no country is supplied.
        /// Gets the jurisdictions of incorporation for a country, if country is supplied.
        /// </summary>
        /// <param name="countryCode"> Optional country alpha2 code </param>
        /// <returns></returns>
        public async Task<IEnumerable<CountrySubdivision>> GetCountryJOI(string countryCode = null)
        {
            IEnumerable<CountrySubdivision> countrySubdivisions = Array.Empty<CountrySubdivision>();
            var resourceParams = new List<string> { "countryJOI", countryCode }.Where(x => !string.IsNullOrWhiteSpace(x));
            var resource = new ResourceName(resourceParams);
            try
            {
                countrySubdivisions = await _context
                    .GetAsync<IEnumerable<CountrySubdivision>>(_configurationNamespace, resource).ConfigureAwait(false);
            }
            catch (JsonReaderException ex)
            {
                // Consuming JsonReaderException here: NAPI returns 200 with HTML content when countryCode is not found.
            }

            return countrySubdivisions;
        }

        /// <summary>
        /// Gets the currently configured business registration numbers, for optionally supplied country and jurisdiction
        /// A country must be supplied in order to use a jurisdiction.
        /// </summary>
        /// <param name="countryCode"> Optional country alpha2 code, get via the call to https://developer.trulioo.com/reference#getcountrycodes </param>
        /// <param name="jurisdictionCode"> Optional jurisdiction code, get via the call to https://developer.trulioo.com/reference#getcountrysubdivisions </param>
        /// <returns></returns>
        public async Task<List<BusinessRegistrationNumber>> GetBusinessRegistrationNumbersAsync(string countryCode = null, string jurisdictionCode = null)
        {
            if (string.IsNullOrWhiteSpace(countryCode) && !string.IsNullOrWhiteSpace(jurisdictionCode))
            {
                throw new ArgumentException("Cannot use jurisdiction without a country.");
            }

            var resourceParams = new List<string> { "businessregistrationnumbers", countryCode, jurisdictionCode }.Where(x => !string.IsNullOrWhiteSpace(x));
            var resource = new ResourceName(resourceParams);
            var response = await _context.GetAsync<List<BusinessRegistrationNumber>>(_configurationNamespace, resource).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the country and configuration you are using.
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="configurationName"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, dynamic>> GetFieldsAsync(string countryCode, string configurationName)
        {
            var resource = new ResourceName("fields", configurationName, countryCode);
            var response = await _context.GetAsync<Dictionary<string, dynamic>>(_configurationNamespace, resource).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the recommendedFields country and account you are using.
        /// http://json-schema.org/documentation.html
        /// </summary>
        /// <param name="countryCode">Call CountryCodes to get the countries available to you.</param>
        /// <param name="configurationName">Identity Verification</param>
        public async Task<Dictionary<string, dynamic>> GetRecommendedFieldsAsync(string countryCode, string configurationName)
        {
            var resource = new ResourceName("recommendedfields", configurationName, countryCode);
            var response = await _context.GetAsync<Dictionary<string, dynamic>>(_configurationNamespace, resource).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Gets a list of TestEntities as a list of DataFields objects
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="configurationName"></param>
        /// <returns>List of Datafields object</returns>
        public async Task<IEnumerable<TestEntityDataFields>> GetTestEntitiesAsync(string countryCode, string configurationName)
        {
            var resource = new ResourceName("testentities", configurationName, countryCode);
            var response = await _context.GetAsync<IList<TestEntityDataFields>>(_configurationNamespace, resource).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Gets a list of Datasources
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="configurationName"></param>
        /// <returns> List of Datasource Group Countries </returns>
        public async Task<IEnumerable<NormalizedDatasourceGroupCountry>> GetDatasourcesAsync(string countryCode, string configurationName)
        {
            var resource = new ResourceName("datasources", configurationName, countryCode);
            var response = await _context.GetAsync<IList<NormalizedDatasourceGroupCountry>>(_configurationNamespace, resource).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Gets all Datasources
        /// </summary>
        /// <param name="configurationName"></param>
        /// <returns> List of Datasource Group Countries </returns>
        public async Task<IEnumerable<NormalizedDatasourceGroupsWithCountry>> GetAllDatasourcesAsync(string configurationName)
        {
            var resource = new ResourceName("alldatasources", configurationName);
            var response = await _context.GetAsync<IList<NormalizedDatasourceGroupsWithCountry>>(_configurationNamespace, resource).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Gets a list of document types
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns> Dictionary with Keys as the Country Codes and Values as list of document types for that country </returns>
        public async Task<Dictionary<string, IList<string>>> GetDocumentTypesAsync(string countryCode = null)
        {
            ResourceName resource;
            if (countryCode != null)
            {
                resource = new ResourceName("documentTypes", countryCode);
            } else
            {
                resource = new ResourceName("documentTypes");
            }
            var response = await _context.GetAsync<Dictionary<string, IList<string>>>(_configurationNamespace, resource).ConfigureAwait(false);
            return response;
        }


        #endregion

        #region Privates/internals

        private readonly TruliooApiClient _service;

        private Context _context { get { return _service?.Context; } }

        private readonly Namespace _configurationNamespace = new Namespace("configuration");

        #endregion
    }
}
