; The name of the installer
Name "Projzilla"
Caption "Projzilla"

Icon "..\img\icons\installer.ico"

; The file to write
OutFile "..\setup.exe"

LicenseText "Projzilla Product License"
LicenseData "..\..\..\docs\license.txt"

; The default installation directory
InstallDir $PROGRAMFILES\Projzilla

; Registry key to check for directory (so if you install again, it will 
; overwrite the old one automatically)
InstallDirRegKey HKLM "Software\Projzilla" "Install_Dir"

/* Replace the values of the two defines below to your applications window class and window title, respectivelly. */ 
!define WNDCLASS ""
!define WNDTITLE "Projzilla"
 
Function un.onInit
  FindWindow $0 "${WNDCLASS}" "${WNDTITLE}"
  StrCmp $0 0 continueInstall
    MessageBox MB_ICONSTOP|MB_OK "The application you are trying to remove is running. Close it and try again."
    Abort
  continueInstall:
FunctionEnd

Function .onInit
  FindWindow $0 "${WNDCLASS}" "${WNDTITLE}"
  StrCmp $0 0 continueInstall
    MessageBox MB_ICONSTOP|MB_OK "The application you are trying to install is running. Close it and try again."
    Abort

  continueInstall:
    System::Call 'kernel32::CreateMutexA(i 0, i 0, t "projzillaMutex") i .r1 ?e'
    Pop $R0
 
    StrCmp $R0 0 +3
    MessageBox MB_OK|MB_ICONEXCLAMATION "The installer is already running."
    Abort
FunctionEnd


;--------------------------------
; Pages

Page license
Page components
Page directory
Page instfiles

UninstPage uninstConfirm
UninstPage instfiles

;--------------------------------

; The stuff to install
Section "Projzilla (required)"

  SectionIn RO
  
  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File /r "..\package-win\*.*"
  
  ; Write the installation path into the registry
  WriteRegStr HKLM SOFTWARE\Projzilla "Install_Dir" "$INSTDIR"
  
  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Projzilla" "DisplayName" "Projzilla"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Projzilla" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Projzilla" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Projzilla" "NoRepair" 1
  WriteUninstaller "uninstall.exe"
  
SectionEnd

; Optional section (can be disabled by the user)
Section "Start Menu Shortcuts"

  CreateDirectory "$SMPROGRAMS\Projzilla"
;  CreateShortCut "$SMPROGRAMS\Projzilla\Projzilla.lnk" "$INSTDIR\Projzilla.exe" "" "$INSTDIR\img\icons\Icon-All.ico" 0
  CreateShortCut "$SMPROGRAMS\Projzilla\Projzilla.lnk" "$INSTDIR\Projzilla.exe" "" "$INSTDIR\img\icons\Icon-All.ico" 0

SectionEnd

;--------------------------------

; Uninstaller

UninstallIcon "..\img\icons\installer.ico"

Section "Uninstall"
  
  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Projzilla"
  DeleteRegKey HKLM SOFTWARE\Projzilla

  ; Backup Config Files
  RENAME "$INSTDIR\Config\DataMapping.xml" "$INSTDIR\Config\DataMapping.xml.backup"
  RENAME "$INSTDIR\Config\SystemConfig.xml" "$INSTDIR\Config\SystemConfig.xml.backup"
  RENAME "$INSTDIR\Config\UserConfig.xml" "$INSTDIR\Config\UserConfig.xml.backup"

  ; Remove files 
  RMDir /r "$INSTDIR\img"
  RMDir /r "$INSTDIR\Docs"
  RMDir /r "$INSTDIR\PreReq"
  DELETE "$INSTDIR\Projzilla.exe"

  ; Remove shortcuts, if any
  Delete "$SMPROGRAMS\Projzilla\*.*"

  ; Remove directories used
  RMDir /r "$SMPROGRAMS\Projzilla"

SectionEnd

Section -Prerequisites
  IfFileExists "$WINDIR\Microsoft.NET\Framework\v3.5\csc.exe" endNet beginNet
    Goto endNet
    beginNet:
    ExecWait '"$INSTDIR\PreReq\dotnetfx35setup.exe"'
  endNet:
  ExecWait 'msiexec /i "$INSTDIR\PreReq\PIA.MSI"'
SectionEnd
