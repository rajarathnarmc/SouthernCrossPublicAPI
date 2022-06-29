# SchsTestApp

This project was generated with [ASP.NET Core Web API] version .NET Core 3.1

## Development server

Application is runing debug mode in dev environment and url is `http://localhost:21743/`. if you change any resources or code then you need to rebuild again.

## Running unit tests

XUnit Test project not working properly

## Considerations & Decisions

01) I have consided member search API as public web application, therefore not implemented any security related function (Authentication & Authorization).

02) Member data maintain in the Json file (DataFile/MOCK DATA.json) instead of Database. Because the search API providing one get function only. Another point is there is not much Database related activity.

03) Web API CORS enabled for "http://localhost:21743"and "http://localhost:4200" URLs and "GET" type methods only. If client application running with different domain then Web API CORS settings need to be update for consume the API. 

04) All Web API related exception Returns as "Internal Server Error : 500", becouse global exception handler (ExceptionMiddlewareExtensionsclass) used to manage the excetion in API.

05) SchMember class added to manage the data read and seach functions. Class related all propertis defind in "camal case" instead of "Pascal case" becouse of json string convertion(JsonConvert.DeserializeObject<>) accept same name of properties. Otherwise json convertion getting falied.

06) In the search function member card number field is optional parameter. The user having the flexibility to perform the search activity without card number.

07) The search function working with exact data matching, so if user enter partial policy number or member card number result would be empty.

08) Web API used attribute routing for manage the user request.

9) Added swagger api documentation framework to describe the api functionalities (http://localhost:21743/swagger/index.html).

10) Added XUnit Test project implimentd few test methods to verify the API functionalty. 

## What we could have improved on

01) We can improve the security of the API implementing Authentication & Authorization.

02) We can use the database and API can expose  with more functionality(create,update delete) for client.

03) Search member function we can improve allowing search with other properties also.