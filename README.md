# **Notes**
## About app:

This is a test single page application. 
Where i used web API as the back end and angular app as the front end.

The main goal of this application is to learn how to connect the front end to the back end.

## How to use the app:
### _Locally:_
1) Download the project repository to your computer

2) Go to the _./notes/backend_ directory, open the project solution (_Notes.sln_) in the development environment and run it.

3) Open a command prompt, go to the directory _./notes/frontend_ and write the command data:
```bash
npm install
```
```bash
ng serve --o
```

After that, the application will open on the specified port.

## File structure

```
Folder Name                                              Description
├──Tests                                    * backend tests
├──Notes.Core                               * core code
├──Notes.Domain                             * domain code
├──Notes.Domain.Services                    * domain services
├──Notes.Domain.Services.Abstractions       * domain services abstractions
├──Notes.Repository                         * repository code
├──Notes.Repository.Abstractions            * repository abstractions
├──Notes.WebApi                             * app's startup project
```
## Database settings

You need to configure database`s settings for connection. You can tune it in appsettings.json or user secrets.json. 

Settings should include server name, database name, username and password.

```bash
"DatabaseSettings": {
    "Server": "server_name",
    "Database": "db_name",
    "User": "user",
    "Pass": "password"
  }
```