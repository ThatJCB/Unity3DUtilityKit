REM Copy files to another folder ready to zip or transfer
REM Excludes all source control and temporary folders
robocopy.exe ..\. ..\..\UtilityKitCopy /MIR /XO /XD obj bin .svn .git Library Temp *_Data
