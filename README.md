# Project Background
This project hopes to achieve a full automated workflow to give feedback to a grocery store. 
The identified manual works 1) manual input of the receipt code 2) the manual data entry. 

The project is broken down into different stages:  
 - to use Image AI to extract the code on the receipt
 - to gather the receipt code and store on the google spreadsheet (tentatively)
 - batch entry the data using this repo (***we are here***)

## Currently
The 1st step - free version of Credly was used, which is currently working on. 
The 2nd step is pending. 
The 3rd step is this repository. 

# The final step - data entry using Selenium 
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
