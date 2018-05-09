# Overview

Augmented reality is hot. Artificial intelligence is hot. Combining the two to create an augmented view of reality where pictures can be identified, tracked, and labeled with meaningful text is a truly fun and exciting experience. This page describes how to use [Unity](https://unity3d.com/unity/beta) and [Microsoft Cognitive Services](https://azure.microsoft.com/en-us/services/cognitive-services/) to create a desktop application to do just that. The application can be run as-is on the desktop emulator, and it can also be deployed onto the [Microsoft HoloLens](https://www.microsoft.com/en-us/hololens).

The application uses the [Microsoft Computer Vision API](https://azure.microsoft.com/en-us/services/cognitive-services/computer-vision/), part of Microsoft Cognitive Services, to extract meaningful text from images. [Vuforia](https://library.vuforia.com/articles/Training/Object-Recognition) is used for image detection and tracking. [Microsoft Visual Studio](https://www.visualstudio.com/) is used to create script actions that call out to the Computer Vision API and also to deploy the application to the HoloLens.

The below steps describe how to create two demos. The first demo shows how to recognize and track an image, and draw a cube on top of it. The second demo builds upon the first demo by showing how to extract meaningful text about a recognized image from the Computer Vision API and superimpose it on top of your view.

So, feel free to follow the steps below to get started  - and have fun!

# Demo 3 - ImageLabels

This demo shows how to recognize and track an image, and draw a cube on top of it. When running, it looks like this:

![demo](images/demo-2-running.png)

For an architectural diagram showing how all the components work together, click [here](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/master/demo-1-architecture.md).

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
