#!/bin/bash

printf "Preparing Directories\n"
cd ..
rm -rf package-win
rm -f setup-2003.exe setup-2007.exe
rm -rf bin
mkdir package-win
mkdir package-win/Config
mkdir package-win/Docs
mkdir package-win/img
mkdir package-win/img/icons
mkdir package-win/PreReq
mkdir package-win/SampleData

printf "Compile\n"
"/cygdrive/c/Program Files/Microsoft Visual Studio 9.0/Common7/IDE/devenv.exe" ../ProjectBugzilla.sln  /build Release

printf "Copy Files\n"
cp bin/Release/ProjectBugzilla.exe package-win/Projzilla.exe
cp Config/Blank.mpp package-win/Config/
cp Config/DataMapping.xml package-win/Config/
cp Config/SystemConfig.xml package-win/Config/
cp Installer/UserConfig.xml package-win/Config/
cp ../../docs/license.txt package-win/Docs/
cp img/icons/installer.ico package-win/img/icons
cp img/icons/Icon-All.ico package-win/img/icons
cp Installer/dotnetfx35setup.exe package-win/PreReq
cp Installer/SampleData/bugs.mpp package-win/SampleData/
cp Installer/SampleData/bugs.xml package-win/SampleData/

printf "Project 2003\n"
cp Installer/O2003PIA/O2003PIA.msi package-win/PreReq/PIA.msi
cp Installer/O2003PIA/o2003PIA_EULA.txt package-win/PreReq/PIA_EULA.txt
cp Installer/O2003PIA/o2003PIA_ReadMe.rtf package-win/PreReq/PIA_ReadMe.rtf
"/cygdrive/c/Program Files/NSIS/makensis.exe" Installer/Projzilla.nsi
mv setup.exe setup-2003.exe

printf "Project 2007\n"
cp Installer/O2007PIA/o2007pia.msi package-win/PreReq/PIA.msi
cp Installer/O2007PIA/eula.txt package-win/PreReq/PIA_EULA.txt
cp Installer/O2007PIA/o2007pia_readme.rtf package-win/PreReq/PIA_ReadMe.rtf
"/cygdrive/c/Program Files/NSIS/makensis.exe" Installer/Projzilla.nsi
mv setup.exe setup-2007.exe

printf "Copy to Server\n"
scp setup-2003.exe dwmccorm@192.168.0.3:/www/projzilla/files/
scp setup-2007.exe dwmccorm@192.168.0.3:/www/projzilla/files/
