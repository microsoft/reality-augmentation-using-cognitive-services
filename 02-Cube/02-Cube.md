# Overview

Augmented reality is hot. Artificial intelligence is hot. Combining the two to create an augmented view of reality where pictures can be identified, tracked, and labeled with meaningful text is a truly fun and exciting experience. This page describes how to use [Unity](https://unity3d.com/unity/beta) and [Microsoft Cognitive Services](https://azure.microsoft.com/en-us/services/cognitive-services/) to create a desktop application to do just that. The application can be run as-is on the desktop emulator, and it can also be deployed onto the [Microsoft HoloLens](https://www.microsoft.com/en-us/hololens).

The application uses the [Microsoft Computer Vision API](https://azure.microsoft.com/en-us/services/cognitive-services/computer-vision/), part of Microsoft Cognitive Services, to extract meaningful text from images. [Vuforia](https://library.vuforia.com/articles/Training/Object-Recognition) is used for image detection and tracking. [Microsoft Visual Studio](https://www.visualstudio.com/) is used to create script actions that call out to the Computer Vision API and also to deploy the application to the HoloLens.

The below steps describe how to create two demos. The first demo shows how to recognize and track an image, and draw a cube on top of it. The second demo builds upon the first demo by showing how to extract meaningful text about a recognized image from the Computer Vision API and superimpose it on top of your view.

So, feel free to follow the steps below to get started  - and have fun!

# Demo 2 - Cube

This demo shows how to recognize and track an image, and draw a cube on top of it. When running, it looks like this:

![demo-one](https://msdata.visualstudio.com/AlgorithmsAndDataScience/TeamAbhinav/_git/hololens?_a=contents&path=%2F02-Cube%2Fimages%2Fdemo-1-running.png)

![demo](images/demo-1-running.png)

For an architectural diagram showing how all the components work together, click [here](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/master/demo-1-architecture.md).

## Setup Instructions

Follow these instructions to deploy the application when using the emulator:

1. Clone this repo (or download as zip and extract) into a local repo directory. Example:
   - choose a local repo directory, which we'll refer to as `<local-repo-dir>`, such as **c:\repos**
   - type **mkdir `<local-repo-dir>`**
   - type **cd `<local-repo-dir>`**
   - type **git clone https://github.com/Microsoft/reality-augmentation-using-cognitive-services**
1. Install Unity Editor
   - browse **https://unity3d.com/unity/beta**
   - click **Download installer** > **Archive**
   - scroll down and click **Download** for **2017.3.0 Release Candidate 2** (the most recent as of this writing)
   - click **Download (Windows)**
   - either click **Run** or save the installer executable locally and double click it
   - click **Next**, accept the terms of service, and click **Next**
   - on the **Choose Components** page, make sure that  **Vuforia Augmented Reality Support** is checked
   - click **Next** > **Next** (this takes several minutes)
   - check **Launch Unity** and click **Finish**
   - register
1. Create Unity project
   - click **Projects** > **New project**
   - for Project name type **AugmentedRealityDemo**
   - for Location type **`<local-repo-dir>`\reality-augmentation-using-cognitive-services**
   - click **Create project**
1. Install and configure HoloLens Toolkit
   - browse **https://github.com/Microsoft/MixedRealityToolkit-Unity**
   - click **Clone or download** > **Download ZIP**
   - download installer executable locally
   - extract zip (this takes several minutes)
   - copy contents of zip’s **Assets** folder to **`<local-repo-dir>`\reality-augmentation-using-cognitive-services\AugmentedRealityDemo\Assets** folder (this takes about a minute)
   - you will see a message saying "This project contains scripts and/or assemblies that use obsolete APIs". Click **I made a Backup. Go Ahead!** (this takes a few minutes)
   - click **Enable Visible Meta Files** (this takes a few minutes)
   - menu **Mixed Reality Toolkit** > **Configure** > **Apply Mixed Reality Project Settings**
   - click **Apply**
   - menu **Mixed Reality Toolkit** > **Configure** > **Apply Mixed Reality Scene Settings**
   - click **Apply**
   - menu **Mixed Reality Toolkit** > **Configure** > **Apply UWP Capability Settings**
   - check **Microphone**, **Webcam**, **Spatial Perception**, **Internet Client**
   - click **Apply**
   - menu: **File** > **Save Project**
   - menu: **File** > **Save Scenes**
   - for File name type **Scene1** and click **Save**
1. Register with Vuforia
   - Browse: https://developer.vuforia.com
   - Click: **Register**
   - Enter information to create a development account
1. Create Vuforia license key
   - Click: **Develop** > **License Manager** > **Get Development Key**
   - Type: App Name: **AugmentedRealityDemo**
   - Accept the terms of agreement
   - Click: **Confirm**
   - Click: **AugmentedRealityDemo**
   - Make a note of this license key, which we'll refer to as `<vuforia-license-key>` You will use in later in your Unity project.
1. Create Vuforia image database
   - click:**Target Manager** > **Add Database**
   - type: Name: **AugmentedRealityDemo**
   - select: **Device**
   - click: **Create**
   - click: **AugmentedRealityDemoDatabase** > **Add Target**
   - click: **Add Target**
   - select: **Single Image**
   - click: **Browse...**
   - select: **`<local-repo-dir>`\reality-augmentation-using-cognitive-services\setup\target-images\charlie-card.jpg**
   - click: **Open**
   - type: Width: **5**
   - type: Name: **charlie-card**
   - click: **Add**
1. Download Vuforia image database
   - click: **Download Database (All)**
   - select: **Unity Editor**
   - click: **Download**
   - click: **Save As** > **`<local-repo-dir>`\reality-augmentation-using-cognitive-services**
   - click: **Save**
1. Import Vuforia image database into Unity project
   - from: Unity: project: **AugmentedRealityDemo**
   - menu: **Assets** > **Import Package** > **Custom Package...**
   - browse: **`<local-repo-dir>`\reality-augmentation-using-cognitive-services\AugmentedRealityDemo\AugmentedRealityDemo.unitypackage**
   - click: **open** > **All** > **Import**
1. Restart Unity Editor
   - click **Projects** > **AugmentedRealityDemo**
1. Create cube on top of recognized image in Unity project
   - right-click: **MixedRealityCameraParent** > **Delete**
   - right-click: **Default Cursor** > **Delete**
   - right-click: **InputManager** > **Delete**
   - right click **Directional Light** > **Delete**
   - click menu option **GameObject** > **Vuforia** > **AR Camera**
   - click **Import** to import assets
   - select menu option **Edit** > **Project Settings** > **Player**
   - expand **XR Settings**, check **Vuforia Augmented Realit**, and click **Accept**
   - select: **AR Camera** > **Inspector** tab
   - click: **Open Vuforia configuration**
   - paste: App License Key: **`<vuforia-license-key>`**
   - check: Databases: **Load AugmentedRealityDemo database**
   - check: **Activate**
   - click menu option **GameObject** > **Vuforia** > **Image**
   ??????- drag: under: AR Camera: **ImageTarget**
   - select: **ImageTarget**
   - type: name: **CharlieCardTarget**
   - select: Database: **AugmentedRealityDemo**
   - right click: **CharlieCardTarget**
   - select: **3D Object** > **Cube**
   - type: position: y: **0.5**
   - type: scale: x: **0.25**
   - type: scale: y: **0.25**
   - type: scale: z: **0.25**
   - menu: **File** > **Save Scenes**
   - type: **Scene1**
   - menu: **File** > **Save Project**
1. Run the Demo
   - print: **`<local-repo-dir>`\reality-augmentation-using-cognitive-services\setup\target-images\charlie-card.jpg**
   - click: **run arrow**. If you hold the printed image of the Charlie Card in front of your computer's camera, you will see cube on top of it.

> If you have a HoloLens, you can proceed to deploy this project to a HoloLens by following the instructions [here](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/master/deploy-to-hololens.md).
