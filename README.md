# PowerPlant
Engie's coding challenge

## Build and run
To build and run the API you will need .NET 7.0 available [here](https://dotnet.microsoft.com/en-us/download/dotnet/7.0).  
Once installed open a terminal and run the following command from the root of the repo :
```dotnet run --project src/PowerPlant.Host --launch-profile http```

Other profiles such as `https` are available in the `src/PowerPlant.Host/Properties/launchSettings.json` file.  

## Docker
A DockerFile is also available in the `src/PowerPlant.Host` folder.

## Documentation
I didn't have enough time to make JSON converters so the name of most properties are different.
The swagger documentation can be found in the `doc/PowerPlant-swagger.json` file.

## Tests
I only had a few minutes to write some unit tests