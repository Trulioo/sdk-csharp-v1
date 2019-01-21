﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        /// Gets a list of TestEntities as a list of DataFields objects
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="configurationName"></param>
        /// <returns>List of Datafields object</returns>
        public async Task<IEnumerable<DataFields>> GetTestEntitiesAsync(string countryCode, string configurationName)
        {
            var resource = new ResourceName("testentities", configurationName, countryCode);
            var response = await _context.GetAsync<IList<DataFields>>(_configurationNamespace, resource).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Gets a list of Datasources
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="configurationName"></param>
        /// <returns> List of Datsource Group Countries </returns>
        public async Task<IEnumerable<NormalizedDatasourceGroupCountry>> GetDatasourcesAsync(string countryCode, string configurationName)
        {
            var resource = new ResourceName("datasources", configurationName, countryCode);
            var response = await _context.GetAsync<IList<NormalizedDatasourceGroupCountry>>(_configurationNamespace, resource).ConfigureAwait(false);
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
