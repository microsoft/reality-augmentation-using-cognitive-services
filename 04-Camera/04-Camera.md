# Overview

Augmented reality is hot. Artificial intelligence is hot. Combining the two to create an augmented view of reality where pictures can be identified, tracked, and labeled with meaningful text is a truly fun and exciting experience. This page describes how to use [Unity](https://unity3d.com/unity/beta) and [Microsoft Cognitive Services](https://azure.microsoft.com/en-us/services/cognitive-services/) to create a desktop application to do just that. The application can be run as-is on the desktop emulator, and it can also be deployed onto the [Microsoft HoloLens](https://www.microsoft.com/en-us/hololens).

The application uses the [Microsoft Computer Vision API](https://azure.microsoft.com/en-us/services/cognitive-services/computer-vision/), part of Microsoft Cognitive Services, to extract meaningful text from images. [Vuforia](https://library.vuforia.com/articles/Training/Object-Recognition) is used for image detection and tracking. [Microsoft Visual Studio](https://www.visualstudio.com/) is used to create script actions that call out to the Computer Vision API and also to deploy the application to the HoloLens.

The below steps describe how to create two demos. The first demo shows how to recognize and track an image, and draw a cube on top of it. The second demo builds upon the first demo by showing how to extract meaningful text about a recognized image from the Computer Vision API and superimpose it on top of your view.

So, feel free to follow the steps below to get started  - and have fun!

# Demo Four - Camera

This demo shows how to recognize and track an image, and draw a cube on top of it. When running, it looks like this:

![demo-one](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/master/setup/images/demo-1-running.png)

For an architectural diagram showing how all the components work together, click [here](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/master/demo-1-architecture.md).

## Setup Instructions

Follow these instructions to deploy the application when using the emulator:

1. Clone this repo (or download as zip and extract) into a local repo directory. Example:
   - choose a local repo directory, which we'll refer to as `<local-repo-dir>`, such as **c:\repos**
   - type **mkdir `<local-repo-dir>`**
   - type **cd `<local-repo-dir>`**
   - type **git clone https://github.com/Microsoft/reality-augmentation-using-cognitive-services**
1. Install Unity Editor
   - browse **https://unity3d.com/get-unity/download**
   - scroll down and click **Older versions of Unity**
   - scroll down and click **Downloads (Win)** for **2017.4.1** (the most recent as of this writing)
   - select **Unity Editor (64 bit)** 
   - either click **Run** or save the installer executable locally and double click it
   - click **Next**, accept the terms of service, click **Next**, select the download folder, and click **Next**
   - check **Run Unity** and click **Finish**
   - you may be asked to register at this point
1. Create Unity project
   - click **Projects** > **New**
   - for Project name type **HoloWorld**
   - for Location type **`<local-repo-dir>`\holoworld**
   - click **Create project**
1. Install and configure HoloLens Toolkit
   - browse **https://github.com/Microsoft/MixedRealityToolkit-Unity**
   - click **Clone or download** > **Download ZIP**
   - download installer executable locally
   - extract zip (this takes several minutes)
   - copy contents of zip’s **Assets** folder to **`<local-repo-dir>`\reality-augmentation-using-cognitive-services\HoloWorld\Assets** folder
   - when Unity regains focus, you will see a message saying "This project contains scripts and/or assemblies that use obsolete APIs". Click **I made a Backup. Go Ahead!** (this takes a few minutes)
   #- click **Enable Visible Meta Files** (this takes a few minutes)
   - menu **Mixed Reality Toolkit** > **Configure** > **Apply Mixed Reality Project Settings**
   - keep defaults and click **Apply**
   - menu **Mixed Reality Toolkit** > **Configure** > **Apply Mixed Reality Scene Settings**
   - keep default and click **Apply**
   - menu **Mixed Reality Toolkit** > **Configure** > **Apply UWP Capability Settings**
   - check **Microphone**, **Webcam**, **Spatial Perception**, **Internet Client**
   - click **Apply**
   - menu: **File** > **Save Scenes**
   - for File name type **Scene1** and click **Save**
   - menu: **File** > **Save Project**
1. Install Vuforia
   - menu **File** > **Build Settings...**
   - click **Player Settings...**
   - for **XR Support Installers** click **Vuforia Augmented Reality** > **Save As**
   close Unity
   install
   restart unity
   click **Enable Visible Meta File**
      - menu **File** > **Build Settings...**
   - click **Player Settings...**
   - for **XR Settings** check **Vuforia Augmented Reality**

1. Show "Holo World"
   - right-click: **MixedRealityCameraParent** > **Delete**
   - right-click: **Default Cursor** > **Delete**
   - right-click: **InputManager** > **Delete**
   - right click **Directional Light** > **Delete**
   - click menu option **GameObject** > **Vuforia** > **AR Camera**
   - click **Import**
   - select **Scene1**
   - click **Create** > **UI** > **Text**
   - set **Text** to **Holo World**
   - set **Font Size** to **24**
   - set color to **white**
   - save and run
1. Install Visual Studio 2017
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

1. Run the Demo
   - print: **`<local-repo-dir>`\reality-augmentation-using-cognitive-services\setup\target-images\charlie-card.jpg**
   - click: **run arrow**. If you hold the printed image of the Charlie Card in front of your computer's camera, you will see cube on top of it.

> If you have a HoloLens, you can proceed to deploy this project to a HoloLens by following the instructions [here](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/master/deploy-to-hololens.md).

- menu **File** > **Build Settings...**
- select **Universal Windows Platform**
- click **Open Download Page** > **Run**

# Demo Two

This builds upon the first demo by showing how to extract meaningful text about a recognized image from the Computer Vision API and superimpose it on top of your view. When running, it looks like this:

![demo-two](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/master/setup/images/demo-2-running.png)

For an architectural diagram showing how all the components work together, click [here](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/master/demo-2-architecture.md).

## Setup Instructions

Follow these instructions to deploy the application when using the emulator:

1. Install Visual Studio
   - browse: https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio
1. Get license key from Microsoft Computer Vision API
   - browse: https://azure.microsoft.com/en-us/services/cognitive-services
   - click: Try Cognitive Services for free > Get API key
   - agree to terms of service and select region
   - click: Next
   - login
   - make note of license key
1. Update Vuforia image database
   - browse: https://developer.vuforia.com
   - login
   - click: Develop > Target Manager > AugmentedRealityDemoDatabase
   - click: Add Target
   - select: Single Image
   - file: browse: `<local-repo-dir>`\reality-augmentation-using-cognitive-services\setup\target-images\satya-nadella.jpg
   - type: width:5
   - type: name:satya-nadella
   - click: Add
1. Download updated Vuforia image database
   - click: Download Database
   - Select: Unity Editor
   - click: Download
   - click: Save As: `<local-repo-dir>`\reality-augmentation-using-cognitive-services
   - click: Save
1. Import updated Vuforia image database into Unity project
   - from: Unity: project: AugmentedRealityDemo
   - menu: Asset > Import Package > Custom Package...
   - browse: `<local-repo-dir>`\reality-augmentation-using-cognitive-services\vuforia\target-image-database\AugmentedRealityDemoDatabase.unitypackage
1. Create text on top of recognized images in Unity Project
   - Create Image Targets for satya-nadella
       - expand: Vuforia > Prefabs
       - drag: under: AR Camera: ImageTarget
       - rename: SatyaNadellaTarget
       - click: SatyaNadellaTarget
       - select: Database: AugmentedRealityDemoDatabase
       - select: Image Target: satya-nadella
   - Create 3D Text for: satya-nadella
       - right click: SatyaNadellaTarget
       - select: 3D Object > 3D Text
       - rename: SatyaNadellaText
       - clear: Text
   - Create component and script for: satya-nadella
       - click: SatyaNadellaText
       - click: Add Component
       - type: Name: SetTextSatyaNadella
       - click: Create and Add
       - double click: SetTextSatyaNadella
       - copy: `<local-repo-dir>`\reality-augmentation-using-cognitive-services\setup\target-images\satya-nadella.jpg
         into: `<local-repo-dir>`\reality-augmentation-using-cognitive-services\unity\AugmentedRealityDemo\Assets\StreamingAssets
   - click: SatyaNadellaTarget > SatyaNadellaText
       - type: Transform
           - Position: x: -1, y: 0, z: 0
           - Rotation: x: 90, y: 0, z: 0
           - Scale: x: 0.1, y: 0.1, z: 0.1
       - click: Add Component
       - select: New Script
       - type: SetTextSatyaNadella # this will open Visual Studio
       - copy: contents: `<local-repo-dir>`\reality-augmentation-using-cognitive-services\setup\src\SetTextSatyaNadella.cs
       - menu: file: exit
   - menu: file: exit
   - menu: File > Save Scene
   - type: Scene1
   - menu: File > Save Project
   - click: run arrow

> If you have a HoloLens, you can proceed to deploy this project to a HoloLens by following the instructions [here](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/master/deploy-to-hololens.md).

# Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
