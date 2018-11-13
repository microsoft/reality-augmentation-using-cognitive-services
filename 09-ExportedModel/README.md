Demo Nine - Run Model Exported from Cognitive Services

Overview

Recognize business card using a model exported from Microsoft Cognitive Services

Steps
	type: Name: rbaAnimalsClassification
	select: Resource Group: rbaCustomVisions-rg
	select: Project Types: Classification
	select: Classification Types: Multiclass (Single tag per image)
	select: Domains: General (compact)
	click: Create project
	type: My Tags: rabbit
	click: Upload 10 files
	type: My Tags: dog
	click: Upload 10 files
	type: My Tags: cat
	click: Upload 10 files
	click: Export
	select:ONNX Windows ML
		Check Windows 10 Build Version
			Win + R. Open up the run command with the Win + R key combo.
			Launch winver. Simply type in winver into the run command text box and hit OK. That is it. You should now see a dialog screen revealing the OS build and registration information.
			I'm Version 1803 (OS Build 17134.345)
		select: ONNX1.0 (works for Windows 10 build lower than 17738)
		click: Download
	Generate Windows ML wrapper
		download Windows ML SDK
			download and install the latest version of the winmltools package
				https://pypi.org/project/winmltools/
				
tutorial https://docs.microsoft.com/en-us/windows/ai/get-started-uwp
	prerequisites
		I have Windows 10, version 1803, OS build 17134.345
---

Steps (didn't work)

click: create new
	type: Name: rbaCustomVision-rg
	select: Azure Subscription: Boston Team Tao
	select: Location: South Central Us
	select: Pricing Tier: S0
	click: Create resource

browse: customvision.ai
click: SIGN IN > NEW PROJECT
	type: Name: rbaAnimals
	select: Resource Group: Limited trial
	select: Project Types: Object Detection (preview)
	select: Domains: General
	click: Create project
click: Add images need 15 images per tag!
	browse: select: cat1, cat2, dog1, dog2, rabbit1, rabbit2
	click: Upload 6 files > Done
click each image and tag it
click: Train
click: Use the Prediction API
click: Make default
click: Export
	
preview of the Object Detection model with bounding boxes!

links
-https://blogs.msdn.microsoft.com/uk_faculty_connection/2018/03/29/windows-10-rs4-preview-for-hololens-and-onnx-offline-machine-learning/
	-https://mtaulty.com/2018/03/11/first-experiment-with-image-classification-on-windows-ml-from-uwp/
	-https://mtaulty.com/2018/03/29/second-experiment-with-image-classification-on-windows-ml-from-uwp-on-hololens/
	-https://mtaulty.com/2018/03/29/third-experiment-with-image-classification-on-windows-ml-from-uwp-on-hololens-in-unity/
-http://meulta.com/en/2018/05/18/experimenting-with-windows-machine-learning-and-mixed-reality/
-https://www.microsoft.com/en-us/hololens/developers
https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK
https://pypi.org/project/winmltools/
https://docs.microsoft.com/en-us/windows/ai/get-started-uwp
http://meulta.com/en/2018/05/18/experimenting-with-windows-machine-learning-and-mixed-reality/