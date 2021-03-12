## Tag Export 

Small console program for fill data from CSV input file, based on XML model document. You can configure program in cofing.json file.

| Value | Type | Description |
|-------|------|-------------|
|DefaultInput|string|Path to input CSV file|
|OutputFolder|string|Path to output folder| 
|TaxXmlFile|string|Model document for tax export|
|HealthCareXdoFile|string|Model document for healt export|
|SocialXmlFile|string|Model document for social export|
|CSV|JSON Object|Numbers of row with data based on input CSV file|

Example of CSV file: 

[]: https://github.com/vasekzdvihal/tax-export/blob/master/TaxExport.Console.UI/Resources/Capture.PNG


Part of JSON with CSV fields configuration. Row numbers are from 0!
```json
"CSV" : {
    "NamePosition" : 0,
    ...
    "StreetPosition" : 5,
    ...
    "PostNumberPosition" : 8,
    ...
    "EmailPosition": 11,
    
    ...
```

And in XML we can put data from CSV to XML like that
```xml
<VetaP
    ulice="StreetPosition" 
    psc="PostNumberPosition" 
    email="EmailPosition" 
    
    ...
```
