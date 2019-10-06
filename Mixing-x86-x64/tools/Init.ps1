
param($installPath, $toolsPath, $package, $project)

# $installPath will contain the path to the folder where the package is installed

# $toolsPath will contain the path to the tools folder in the package; this is where the script is run from

# $package will contain a reference to the package object

# $project will contain a reference to the DTE project object into which the
# package is installed; it will be empty in Init.ps1 because it is run at the
# solution level and not for a specific project

Write-Host "This script is run the first time the package+version is installed into a solution, it is not run again if you remove/add the same package+version"
