@echo off
echo Administrative permissions required. Detecting permissions...
    
net session >nul 2>&1
if %errorLevel% == 0 (
  sc create "fivemServer" start="auto" binpath="%~dp0\fivemAsService.exe" displayname="FiveM Server"
  sc failure fivemServer reset= 86400 actions= restart/1000/restart/1000     
  net start fivemServer
  pause > nul
  exit
) else (
  echo Failure: Current permissions inadequate.
  pause > nul
  exit
)    
