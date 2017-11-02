# Follow these instructions to deploy a Unity application to the HoloLens

## Requirements
1. Unity Editor with open project running on desktop
1. HoloLens
1. Visual Studio installed on desktop

## Steps
1. Create Visual Studio Solution from Unity
    - click: File > Build Settings
    - click: Add open scenes
    - select: platform: Universal Windows Platform
    - select: Target device: hololens
    - select: build type: D3D # the default
    - select: SDK: latest installed
    - select: Build: local machine
    - check: unity c# project
    - click: Build
    - mkdir: <target directory>
    - select: <target directory>
    - click: select folder
    - click: <project name>.sln
1. Connect HoloLens to network
    - settings > wifi
1. Enable development mode on HoloLens
    - settings > update > developer on # allows VS to deploy to device
1. Connect cable from HoloLens to desktop
1. Deploy to HoloLens
    - select: Debug
    - select: x86
    - select: device
    - click: run
