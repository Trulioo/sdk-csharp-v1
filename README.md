# Trulioo SDK for C# #

## Version 2.1.7.0

The Trulioo Software Development Kit (SDK) for C# contains library code designed to enable developers to customize the integration of GlobalGateway into your automated business processes or website.

Trulioo is a leading global ID verification company providing advanced analytics based on traditional information such as public records, credit files and government data as well as alternative sources including social login providers, ad networks, mobile applications, e-commerce websites and social networks. Trulioo specializes in scoring online identities as authentic, machine generated or fraudulent with our identity bureau covering 4 billion people in over 40 countries, including coverage for the most challenging demographics from emerging markets such as China, Russia, and Brazil.

Trulioo enables increased trust and safety online by powering fraud prevention and compliance systems for hundreds of clients including governments, eCommerce merchants, financial services, insurance, health, and travel companies.

Below is an example of initializing the Trulioo API client and test connection:

```csharp
using Trulioo.Client.V1;

var truliooClient = new TruliooApiClient("-- YOUR WEB SERVICE USER NAME --", "-- YOUR PASSWORD --");

var responseString = await truliooClient.Connection.TestAuthenticationAsync();

```

## Supported platforms
.NET 4.6 (more to come soon)

#### Development environment

##### Visual Studio
The Trulioo SDK for C# supports development in [Microsoft Visual Studio 2015](http://www.microsoft.com/visualstudio/downloads).

### Changelog

The [CHANGELOG.md](https://github.com/Trulioo/sdk-csharp-v1/blob/master/CHANGELOG.md) file in the root of the repository contains a description of changes for each version of the SDK. 

### Documentation and resources

If you need to know more:

* For more about the Trulioo REST API V1, see the [REST API Reference](https://api.globaldatacompany.com/).

* For more about Trulioo in general, see [Trulioo Website](https://www.trulioo.com/).

### Support


1. You will be granted support if you or your company are already covered under an existing maintenance/support agreement. Send an email to _support@trulioo.com_ and include "Trulioo SDK for C# V1" in the subject line.

2. Trulioo will NOT provide support for the extension if the core library has been modified. We would also like to know why you modified the code please send feedback to _support@trulioo.com_ 

### Contact Us

You can reach via channels listed on [Trulioo website](https://www.trulioo.com/company/contact-us/)

## License

The Trulioo SDK for C# is licensed under the Apache License 2.0. Details can be found in the LICENSE file.
