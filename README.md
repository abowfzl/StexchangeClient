# StexchangeClient.Net

StexchangeClient.Net is a wrapper around the Stexchange API's in C#. This library offers methods for creating REST request to Stexchange with custom exceptions.

Using dotnet dependency inject

```

services.AddStexchangeClient("your base address")

```

Then use **IStexchangeRestClient** interface in your services to make requests

## Release notes
	* Version 1.0.6 - 18 Sep 2023
		* Fix order side in user market deals
		* Add UserRole enum
	* Version 1.0.5 - 10 Sep 2023
		* Undo renamed properties
	* Version 1.0.4 - 09 Sep 2023
		* Change json formatted details in update balance
	* Version 1.0.3 - 12 Aug 2023
		* Force upper case asset name

	* Version 1.0.2 - 09 Aug 2023
		* Fix assetName and businessType string format when sending to exchange
		* Make UpdateBalance to generic
		* Request UpdateBalance with dictionary format of details

	* Version 1.0.1 - 06 Aug 2023
		* Renamed StexchangeClient to IStexchangeRestClient
		* Downgrade AspNetCore.Http.Extensions version to 1.0.1 for using Newtonsoft.Json

	* Version 1.0.0 - 06 Aug 2023
		* First release for Exchange Client

### Maintainer:
* Abolfazl Moslemian (moslemianAbolfazl@gmail.com)