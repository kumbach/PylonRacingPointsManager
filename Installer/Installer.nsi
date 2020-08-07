;--------------------------------
;Include Modern UI

  !include "MUI2.nsh"

;--------------------------------
;General

  ;Name and file
  Name "Pylon Racing Points Manager"
  OutFile "pylon-racing-points-manager-1.0.0.exe"

  ;Default installation folder
  InstallDir "$LOCALAPPDATA\Pylon Racing Points Manager"

  ;Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\Pylon Racing Points Manager" ""

  ;Request application privileges for Windows Vista
  RequestExecutionLevel user

;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING

;--------------------------------
;Pages

  !insertmacro MUI_PAGE_WELCOME
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  !insertmacro MUI_PAGE_FINISH

  !insertmacro MUI_UNPAGE_WELCOME
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  !insertmacro MUI_UNPAGE_FINISH

;--------------------------------
;Languages

  !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Section "Dummy Section" SecDummy

  SetOutPath "$INSTDIR"
  SetOverwrite on

  ;ADD YOUR OWN FILES HERE...
  File /r "d:\workspace\clubpylonmanager\ClubPylonManager\bin\Release\*"

  ;Store installation folder
  WriteRegStr HKCU "Software\Pylon Racing Points Manager" "" $INSTDIR

  ; create start menu items
    CreateDirectory "$SMPROGRAMS\Pylon Racing Points Manager"
	CreateShortCut "$SMPROGRAMS\Pylon Racing Points Manager\Pylon Racing Points Manager.lnk" "$INSTDIR\PylonRacingPointsManager.exe"
	CreateShortCut "$SMPROGRAMS\Pylon Racing Points Manager\Uninstall.lnk" "$INSTDIR\uninstall.exe"

  ;Create uninstaller
  WriteUninstaller "$INSTDIR\Uninstall.exe"

SectionEnd

;--------------------------------
;Uninstaller Section

Section "Uninstall"

  ;ADD YOUR OWN FILES HERE...
	rmdir /r "$INSTDIR"
	Delete "$SMPROGRAMS\Pylon Racing Points Manager\Pylon Racing Points Manager.lnk"
	Delete "$SMPROGRAMS\Pylon Racing Points Manager\Uninstall.lnk"
	rmdir "$SMPROGRAMS\Pylon Racing Points Manager"

  Delete "$INSTDIR\Uninstall.exe"

  RMDir "$INSTDIR"

  DeleteRegKey /ifempty HKCU "Software\Pylon Racing Points Manager"

SectionEnd
