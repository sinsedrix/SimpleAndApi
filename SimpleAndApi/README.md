# Simple Android API

## Build
- dotnet publish -c Release -r android-x64 --self-contained -f net8.0-android /p:DefineConstants=ANDROID

## ADB commands
- adb devices
- adb uninstall org.tool2team.simpleandapi
- adb install -r .\bin\Release\net8.0-android\android-x64\publish\org.tool2team.simpleandapi-Signed.apk

- adb shell dumpsys package org.tool2team.simpleandapi
- adb logcat | grep simpleandapi

- adb shell am start-foreground-service -n org.tool2team.simpleandapi/.MainFgService
- adb shell am start-foreground-service -n org.tool2team.simpleandapi/.AuxFgService
- adb shell am startservice -n org.tool2team.simpleandapi/.MainService
- adb shell am startservice -n org.tool2team.simpleandapi/.AuxService

- adb shell am force-stop org.tool2team.simpleandapi

## Uncompile
- https://apktool.org/
- https://raw.githubusercontent.com/iBotPeaches/Apktool/master/scripts/windows/apktool.bat
- apktool.bat d .\bin\Release\net8.0-android\android-x64\publish\org.tool2team.simpleandapi-Signed.apk


## Termux
- pkg install android-tools
- adb devices
- adb shell am start -n org.tool2team.simpleandapi/.MainActivity
- adb shell am start -n org.tool2team.simpleandapi/org.tool2team.simpleandapi.MainActivity
