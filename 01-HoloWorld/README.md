# Demo One - Holo World

This demo shows how to overlay text in the augmented reality camera running in the Unity Emulator.

![thumbs up](setup/demo1-running-resized-66.png)

## Setup Instructions

Follow these instructions to deploy and run the application in the emulator:

1. Create Unity project
   - open **Unity**
   - click **Projects** > **New**
   - for **Project name** type *HoloWorld*
   - for **Location** accept the default or type your own choice
   - for **Template** accept the default **3D**
   - click **Create project**

   ![create project](setup/create-project-labelled-resized-66.png)

1. Configure platform
   - menu **File** > **Build Settings...**
   - in the **Build Settings** dialog, select **Universal Windows Platform**
   - click **Open Download page**
   - save the installer executable to `Downloads`
   - close **Unity**
   - double click the installer executable
   - click **Next** > accept the terms of service > click **Next** > **Next**, select the Unity folder, click **Next** > **Finish**

   ![configure platform](setup/configure-platform-labelled-resized-66.png)

1. Configure Vuforia
   - start **Unity**
   - click **Projects** > **HoloWorld**
   - menu **File** > **Build Settings...**
   - in the **Build Settings** dialog, select **Universal Windows Platform**
   - click **Switch Platform**
   - select **HoloLens** for **Target Device**

   ![switch platform](setup/switch-platform-labelled-resized-66.png)
   
   - click **Player Settings...**
   - in the **Inspector** window that opens, click **Other Settings**
   - select **.NET** for **Scripting Backend**

   ![other settings](setup/other-settings-labelled-resized-66.png)
   
   - click **Publishing Settings**
   - for **Capabilities** check **InternetClient**, **WebCam**, and **Microphone**

   ![capabilities](setup/capabilities-labelled-resized-66.png)
   
   - click **XR Settings**
   - check **Virtual Reality Supported**
   - click the **Vuforia Augmented Reality** link
   - save the installer executable to `Downloads`
   - close **Unity**
   - double click the installer executable
   - click **Next** > accept the terms of service > click **Next** > **Next**, select the Unity folder, click **Next** > **Finish**
   - start **Unity**
   - click **Projects** > **HoloWorld**
   - menu **File** > **Build Settings...**

   ![xr settings](setup/xr-settings-labelled-resized-66.png)
   
   - click **Player Settings...**
   - In the **Inspector** window that opens, click **XR Settings**
   - check **Vuforia Augmented Reality**, accept the conditions, click **Finish**

   ![check vuforia](setup/check-vuforia-labelled-resized-66.png)

1. Create UI
   - In the **Hierarchy** window, select: **MainCamera** and **Directional Light** (Note: Hold down Ctrl key for multi-select)
   - right click: select **Delete**

   ![delete camera and light](setup/delete-camera-and-light-labelled-resized-66.png)

   - right click **SampleScene**
   - click menu option **GameObject** > **Vuforia** > **AR Camera**
   - click **Import**
   
   ![ar camera](setup/ar-camera-labelled-resized-66.png)

   - in the **Hierarchy** window on the left, click **Create** > **UI** > **Text**
   
   ![create text](setup/create-text-labelled-resized-66.png)

   - in the **Inspector** window on the right, in the **Text (Script)** section, set **Text** to *Holo World!*
   - set **Font Size** to **24**
   
   ![text properties](setup/text-properties-labelled-resized-66.png)

   - click **Color**
   - in the **Color** dialog that opens, set **R**, **G**, and **B** to **255**
   - menu **File** > **Save Scenes**
   - menu **File** > **Save Project**
   
   ![rgb](setup/rgb-labelled-resized-66.png)

## Run the demo
   - click **Run**. You will see a live camera view overlayed with the words "Holo World!" near the bottom (Note: you may need to widen the display to see the words)

   ![play](setup/play-labelled-resized-66.png)
