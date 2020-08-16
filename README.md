# Web API for Managing Contacts

This test is to create a Visual Studio solution for a Web API for managing contacts (which have names, phone numbers, emails etc) using C# and .NET Core.

Requirements:

- Provide RESTful API to create, update and delete contact information.
- Utilise C# with .NET Core.
- Use database for storage, either MS SQL, SQLite or an online provider with credentials and instructions.
- Demonstrate good programming practices such as repository pattern.


## Development and Test Environment

  - Only operating System Windows 10 has been tested
  
  - IDE and Test tool:Visual Studio 2019, you can download it from https://visualstudio.microsoft.com/downloads/  
  
  - .NET Core 3.1 SDK is required, you can download it from https://dotnet.microsoft.com/download/visual-studio-sdks  
    
## After cloned the code from https://github.com/sethfengli/Web-API-for-managing-contacts.git
  
 - Please use Visual Studio 2019 to open code-test-contacts-api.sln solution file in your working folder
 
 - Solution code-test-contacts-api.sln is the main repository  
 
 - Project Tests is the unit test repository  
  
## Getting Started

You will need to update **WebUI/appsettings.json** as follows:

Verify that the **DefaultConnection** connection string within **appsettings.json** points to a valid SQL Server instance. 

Navigate to `src/WebUI` and run `dotnet run` to launch the project

When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied.

### If you are having problems, please let me know by email at sethfengli@yahoo.com.au.