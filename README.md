#Table of Content
1.Automator
2.Msilengwe.csproj
##Msilengwe.csproj
Added all the dependencies that needed for the project.
##Automator
1.Framework
2.POM
3.TestSuite
###Framework
This contains base class that has the selenium events needed to execute automation.
###POM
1.Data
2.Globalsqa(folder)
3.Model
4.Globalsqa(class)
####Data
This has all the external files needed as test data.
####Globalsqa(folder)
Where you do your page object model,capture locators and create methods with automation steps
####Model
Classes needed to map up the data from external files
####Globalsqa(class)
This group together all pages per application
###TestSuite
This has test classes where you execute your test methods