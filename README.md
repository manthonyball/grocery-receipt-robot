#Project Background
This is the final stage of my project. 
My different stages of the project :
 - to use Image AI to extract the code on the receipt
 - to gather the codes and store on the google spreadsheet (tentatively)
 - batch entry the data using this repo (we are here)

The 1st step I used free version of Credly, which I am currently working on. 
The 2nd step is pending. 
The 3rd step is on. 

This repository is to automate the repetitive data entry action of the grocey feedback form using Selenium. 
Here, the adopted framework is Dot Not 8 with OpenQA.

The flow is yet to complete. 

A. Dot Net Framework set-up
  1. Right click on the *.csproj 
  2. configure the section "Target framework"  

B. Update WebDriver in your local machine
  1. Driver located in "C:\TFS\seleniumDriver"
  2. Driver can be found in https://www.selenium.dev/documentation/webdriver/getting_started/install_drivers/ 
  3. (Or) Configure the path in appsettings.json

C. Project set-up
  1. Configure Utilities.Utility.cs -> GetURL()
  2. Configure JobList.cs 
  3. Configure appsettings.json (json -> DTO) 
  4. Configure DTO.ProjectDTO.cs  
