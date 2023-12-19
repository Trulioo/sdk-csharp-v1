# Trulioo SDK for C# Changelog

## Version 3.0.35.0

Add CountryCode field to CountrySubdivison model

## Version 3.0.34.0

Updated methods from Napi (GetCountryJOI, GetBusinessRegistrationNumbersAsync) to get configurations for all countries through one call.
Updated Unit Tests

## Version 3.0.16.0

Added new Methods from NAPI (GetCountryJOI, GetBusinessRegistrationNumbersAsync, GetPartialResultAsync)
Updated Models for (Business, DataFields, DatasourceField, Location, Record, RecordRule, TransactionStatus, VerifyResultPartial, VerifyResult, BusinessSearchModel,
					BusinessSearchRequest, SearchResult, SearchResultAddress)
Created Models for (BusinessRegistrationNumber, BusinessRegistrationNumberMask, RiskMonitorSettings, TestEntityDataFields, BusinessSearchResponseIndustryCode)
Updated Unit Tests

## Version 3.0.15.0

Updated library to .net Standard 2.0.  
Breaking change to correct method name: GetDocumentDownload changed to GetDocumentDownloadAsync in Verification.cs

## Version 2.1.9.0

Changed type of Model/AppendedField's Data from string to dynamic in order to allow WatchListDetails, returned as Dictionary, parsable.

## Version 2.1.7.0

Added new Methods from NAPI (GetTestEntities, GetDatasources, GetTransactionRecordVerbose, GetTransactionStatus, GetDocumentTypes, BusinessSearch, BusinessSearchResult)    
Added new Models for Document and Business Verification
Added new Fields in VerifyRequest to reflect NAPI  
Created better Test Classes

## Version 2.1.5

Added CountryCode and ProductName in VerifyResult
Added Rule in Record

## Version 2.1.4

Fix dependency on Newtonsoft,  nuget was incorrectly marked as requiring v8, v9 was required

## Version 2.1.3

Breaking change to add the correct Additional Fields to Person and Location
FullName for PersonInfo
Address1 for Location

## Version 1.1.0

Added Country Specific fields and move the code base to GitHub

## Version 1.0.0

### In Private 

Initial Trulioo SDK for C# in private testing.
