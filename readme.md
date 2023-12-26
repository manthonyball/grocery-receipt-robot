A. Dot Net Framework set-up
  1. Right click on the *.csproj 
  2. configure the section "Target framework"  

B. Update WebDriver in your local machine
  1. Driver located in "C:\TFS\seleniumDriver"
  2. Driver can be found in https://www.selenium.dev/documentation/webdriver/getting_started/install_drivers/ 
  3. (Or) Configure the path in Utilities.AutomatedDrivers.GetDriver()

C. Project set-up
  1. Configure Utilities.Utility.cs -> GetURL()
  2. Configure Utilities.JobList.cs 
  3. Configure DTO.ConfigDTO.cs 
  4. Configure DTO.ProjectDTO.cs  