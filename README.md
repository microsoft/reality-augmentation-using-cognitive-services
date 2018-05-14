# Overview

Augmented reality is hot. Artificial intelligence is hot. Combining the two to create an augmented view of reality where pictures can be identified, tracked, and labeled with meaningful text is a truly fun and exciting experience. This page describes how to use [Unity](https://unity3d.com/unity/beta) and [Microsoft Cognitive Services](https://azure.microsoft.com/en-us/services/cognitive-services/) to create a desktop application to do just that. The application can be run as-is on the desktop emulator, and it can also be deployed onto the [Microsoft HoloLens](https://www.microsoft.com/en-us/hololens).

The application uses the [Microsoft Computer Vision API](https://azure.microsoft.com/en-us/services/cognitive-services/computer-vision/), part of Microsoft Cognitive Services, to extract meaningful text from images. [Vuforia](https://library.vuforia.com/articles/Training/Object-Recognition) is used for image detection and tracking. [Microsoft Visual Studio](https://www.visualstudio.com/) is used to create script actions that call out to the Computer Vision API and also to deploy the application to the HoloLens.

# Prerequisites

This tutorial requires that you have a 64-bit Windows computer with a camera and an internet connection. The following software needs to be installed on your computer:

1. Visual Studio 2017
   - If you do not have Visual Studio 2017 installed:
     - Navigate to [Download and Tools for Windows 10](https://developer.microsoft.com/en-us/windows/downloads)
     - Download a Visual Studio installer; the Community Edition is a good choice
   - Open the Visual Studio installer
	 - If Visual Studio is installed, open it from the Settings > Apps control panel
   - Select the **Universal Windows Platform development** workload
   - Select the **Game Development with Unity** workload
     - You may deselect the Unity Editor optional component since you'll be installing a newer version of Unity from the instructions below

   All editions of Visual Studio 2017 are supported (including Community). While Visual Studio 2015 Update 3 is still supported, we recommend Visual Studio 2017 for the best experience.

1. Unity Editor
   - Navigate to [Download Unity](https://unity3d.com/get-unity/download)
   - Scroll down and under **Resources** click **Older versions of Unity**
   - Scroll down and for **Unity 2018.1.0** click **Downloads (Win)** (NOTE: this is the most recent as of this writing)
   - Select **Unity Editor (64 bit)**
   - Save the installer executable to your `Downloads` folder and double click it
   - Click **Next**, accept the terms of service, click **Next**, click **Next**, select the download folder, click **Next**, and click **Finish**

You also need to have available some cloud services.

1. Microsoft Azure Resource Group
   - Navigate to [Azure Portal](https://ms.portal.azure.com)
     - Sign in to the Azure Cloud if requested
   - Click **Resource groups**
   - In the blade that opens on the right, click **+ Add**
   - In the blade on the right, fill in the following fields:
	 - Resource group name: *myCognitiveResources*
	 - Subscription: select your subscription
	 - Resource group location: select **West US 2**
   - Click **Create**

1. Microsoft Computer Vision API **Wait until the tutorial to do this***
   - Navigate to [Azure Portal](https://ms.portal.azure.com)
     - Sign in to the Azure Cloud if requested
   - Click **Create a resource**
   - Type **Computer Vision** in the search box
   - Click the item named **Computer Vision**
   - Click **Create**
   - In the dialog, fill in the following fields:
	 - Name: Type in *myComputerVision*
	 - Subscription: select your subscription
	 - Pricing tier: select **F0** for free
	 - Resource group:
	   - Select **Use existing**
	   - From the drop-down text box, select *myCognitiveServices*
   - Wait for the **Quick start** page
   - In the right of the page, click **Keys**
   - Copy **KEY 1** to a text file

1. Microsoft Text Analytics API **Wait until the tutorial to do this***
   - Navigate to [Azure Portal](https://ms.portal.azure.com)
     - Sign in to the Azure Cloud if requested
   - Click **Create a resource**
   - Type **Translator Text** in the search box
   - Click the item named **Translator Text**
   - Click **Create**
   - In the dialog, fill in the following fields:
	 - Name: Type in *myTranslatorText*
	 - Subscription: select your subscription
	 - Pricing tier: select **F0** for free
	 - Resource group:
	   - Select **Use existing**
	   - From the drop-down text box, select *myCognitiveServices*
   - Wait for the **Quick start** page
   - In the right of the page, click **Keys**
   - Copy **KEY 1** to a text file

1. Vuforia
   - Navigate to [Vuforia Developer Portal](https://developer.vuforia.com)
   - Click **Register**
   - Enter information to create a development account

# Demos

- [**01-HoloWorld**](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/mlads/01-HoloWorld/01-HoloWorld.md)
- [**02-Cube**](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/mlads/02-Cube/02-Cube.md)
- [**03-ImageLabels**](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/mlads/03-ImageLabels/03-ImageLabels.md)
- [**04-Camera**](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/mlads/04-Camera/04-Camera.md)
- [**05-OCR**](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/mlads/05-OCR/05-OCR.md)
- [**06-Translate**](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/mlads/06-Translate/06-Translate.md)
- [**07-Handwriting**](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/mlads/07-Handwriting/07-Handwriting.md)
- [**08-FacialRecognition**](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/mlads/08-FacialRecognition/08-FacialRecognition.md)
- [**09-CustomModel**](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/mlads/09-CustomModel/09-CustomModel.md)

# Contributing

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
