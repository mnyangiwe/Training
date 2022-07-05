# Table of Content
* Automator
* Msilengwe.csproj

## Msilengwe.csproj
Add all the dependencies that are needed for the project.
## Automator
* Framework
* POM
* TestSuite
### Framework
This contains base class that has the selenium events needed to execute automation.
### POM
* Data
* Globalsqa(folder)
* Model
* Globalsqa(class)
#### Data
This has all the external files needed as test data.
#### Globalsqa(folder)
Where you do your page object model,capture locators and create methods with automation steps
#### Model
Classes needed to map up the data from external files
#### Globalsqa(class)
This group together all pages per application
### TestSuite
This has test classes where you execute your test methods
