# ObjectComparer

Class library desgin to compare if two objects are identical. 



## Testing and coverage with xunit

Creating and running test is fairly easy with xunit. Generating a coverage report was a bit tricky. The next steps describe how I managed to get it working.

To generate the coverage file we need to install **coverlet.msbuild**. I was able to install the nuget using the nuget package manager but I noticed **dotnet test** commands where not working as expected. Based on the following [Github Post](https://github.com/coverlet-coverage/coverlet/issues/201) I was able to get it working by uninstalling the nuget and executing the following command: 

```dotnet add package coverlet.msbuild ```

Using this aproach fixed the isues I was having. To generate a coverage file (coverage.json) use the following command: 

```dotnet test /p:CollectCoverage=true```

To generate a more readable file (coverage.cobertura) based on the json previously generated use the following command:  

```dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura```

This alone can be used to publish code coverage data to VSTS build results. After generating our .xml file we can generate a more visual report using the follwoing command: 

```reportgenerator "-reports:ObjectComparer.Test\coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html```

In case you don't have report generator execute the following command:

```dotnet tool install -g dotnet-reportgenerator-globaltool```


### Links:

Development:

https://stackoverflow.com/questions/506096/comparing-object-properties-in-c-sharp
https://stackoverflow.com/questions/10454519/best-way-to-compare-two-complex-objects
https://stackoverflow.com/questions/238555/how-do-i-get-the-value-of-memberinfo
https://stackoverflow.com/questions/15921608/getting-the-type-of-a-memberinfo-with-reflection

Testing:

https://github.com/coverlet-coverage/coverlet
https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-code-coverage?tabs=windows
https://medium.com/bluekiri/code-coverage-in-vsts-with-xunit-coverlet-and-reportgenerator-be2a64cd9c2f

