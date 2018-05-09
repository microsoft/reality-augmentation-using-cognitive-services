# Overview

Augmented reality is hot. Artificial intelligence is hot. Combining the two to create an augmented view of reality where pictures can be identified, tracked, and labeled with meaningful text is a truly fun and exciting experience. This page describes how to use [Unity](https://unity3d.com/unity/beta) and [Microsoft Cognitive Services](https://azure.microsoft.com/en-us/services/cognitive-services/) to create a desktop application to do just that. The application can be run as-is on the desktop emulator, and it can also be deployed onto the [Microsoft HoloLens](https://www.microsoft.com/en-us/hololens).

The application uses the [Microsoft Computer Vision API](https://azure.microsoft.com/en-us/services/cognitive-services/computer-vision/), part of Microsoft Cognitive Services, to extract meaningful text from images. [Vuforia](https://library.vuforia.com/articles/Training/Object-Recognition) is used for image detection and tracking. [Microsoft Visual Studio](https://www.visualstudio.com/) is used to create script actions that call out to the Computer Vision API and also to deploy the application to the HoloLens.

# Prerequisites
This tutorial requires that you have a Windows computer with a camera. The following software needs to be installed on your computer:

1. [Visual Studio 2017](https://developer.microsoft.com/en-us/windows/downloads)
   - Select the **Universal Windows Platform development workload**
   - Select the **Game Development with Unity** workload
   - You may deselect the Unity Editor optional component since you'll be installing a newer version of Unity from the instructions below.

   All editions of Visual Studio 2017 are supported (including Community). While Visual Studio 2015 Update 3 is still supported, we recommend Visual Studio 2017 for the best experience.

1. [Unity Editor](https://unity3d.com/get-unity/download)
   - scroll down and under **Resources** click **Older versions of Unity**
   - scroll down and for **Unity 2018.1.0** click **Downloads (Win)** (NOTE: this is the most recent as of this writing)
   - select **Unity Editor (64 bit)**
   - choose a local working directory, which we'll refer to as `<working-dir>`, such as **c:\hololens**
   - save the installer executable to `<working-dir>` and double click it
   - click **Next**, accept the terms of service, click **Next**, click **Next**, select the download folder, click **Next**, and click **Finish**

You also need to have available the following cloud services:

1. [Microsoft Computer Vision API](https://azure.microsoft.com/en-us/services/cognitive-services)
   - click **Try Cognitive Services for free** > **Get API key**
   - agree to terms of service and select region
   - click **Next**
   - login
   - make note of license key

1. [Vuforia](https://developer.vuforia.com)
   - click **Register**
   - Enter information to create a development account

# Demos

1. [**01-HoloWorld**](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/mlads/01-HoloWorld/01-HoloWorld.md)
1. [**02-Cube**](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/mlads/02-Cube/02-Cube.md)
1. [**03-ImageLabels**](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/mlads/03-ImageLabels/03-ImageLabels.md)
1. [**04-Camera**](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/mlads/04-Camera/04-Camera.md)
1. [**05-OCR**](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/mlads/05-OCR/05-OCR.md)
1. [**06-Translate**](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/mlads/06-Translate/06-Translate.md)
1. [**07-Handwriting**](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/mlads/07-Handwriting/07-Handwriting.md)
1. [**08-FacialRecognition**](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/mlads/08-FacialRecognition/08-FacialRecognition.md)
1. [**09-CustomModel**](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/mlads/09-CustomModel/09-CustomModel.md)
