# Demo Two - Cube

This demo shows how to recognize and track an image, and draw a cube on top of it. When running, it looks like this:

![running](setup/demo2-running-resized-66.png)

## Setup Instructions

For this demo, we will build upon what we did for the previous demo.

1. Download the contents of this repo as a zip into a local working directory

   - If you haven't already, create a local working directory which we'll refer to as `<working-dir>` (Example: **c:\hololens**)
   - Click **Clone or download** > **Download ZIP**
   - Save and extract the zip into `<working-dir>`
   
   ![download zip](setup/download-zip-labelled-resized-66.png)

1. Create Vuforia license key

   - Navigate to [Vuforia Developer Portal](https://developer.vuforia.com)
   - Login
   - Click **Develop** > **License Manager** > **Get Development Key**
   - For **App Name** type **HoloWorld**
   - Accept the terms of agreement
   - Click **Confirm**
   - Under **Name** click **HoloWorld**
   - Make a note of this license key, which we'll refer to as `<vuforia-license-key>` You will need in later in your Unity project.

1. Create Vuforia image database

   - In the **Vuforia Developer Portal**, click **Target Manager** > **Add Database**
   - For **Name** type **HoloWorld**
   - Select **Device**
   - Click **Create**
   - Under **Database** click **HoloWorld**
   - Click **Add Target**
   - For **Type** select **Single Image**
   - For **File** click **Browse...**
   - Select **`<working-dir>`\reality-augmentation-using-cognitive-services\02-Cube\images\businesscard.png**
   - Click **Open**
   - For **Width** type **5**
   - For **Name** type **businesscard**
   - Click **Add**

   ![add target](setup/add-target-labelled-resized-66.png)

1. Download Vuforia image database

   - Click **Download Database (All)**

   ![click download database](setup/click-download-database-labelled-resized-66.png)
   
   - Select **Unity Editor**
   - Click **Download**
   - Click **Save As** > **`<working-dir>`\HoloWorld.unitypackage**
   - Click **Save**

   ![download database](setup/download-database-labelled-resized-66.png)

1. Import Vuforia image database into Unity project

   - Start **Unity**
   - Click **Projects** > **HoloWorld**
   - Menu **Assets** > **Import Package** > **Custom Package...**
   - Browse: **`<working-dir>`\Hololens\HoloWorld\HoloWorld.unitypackage**

   ![import package](setup/import-package-labelled-resized-66.png)
   
   - Click **Open** > **All** > **Import**

   ![import all](setup/import-all-labelled-resized-66.png)

1. Create cube on top of recognized image in Unity project

   - Click **AR Camera**
   - In the **Inspector** window, click **Open Vuforia configuration**

   ![vuforia configuration](setup/vuforia-configuration-labelled-resized-66.png)

   - For **App License Key** paste your **`<vuforia-license-key>`**

   ![license key](setup/license-key-labelled-resized-66.png)

   - Select **SampleScene**
   - Click **Create** > **Vuforia** > **Image**  

   ![image target](setup/image-target-labelled-resized-66.png)

   - In the **Inspector** window, for **ImageTarget** type *BusinessCardTarget*
   - For **Database** select **HoloWorld**
   - For **Image Target** select **businesscard**

   ![target properties](setup/target-properties-labelled-resized-66.png)

   - In the **SampleScene**, right click **BusinessCardTarget**
   - Select **3D Object** > **Cube**

   ![create cube](setup/create-cube-labelled-resized-66.png)

   - In the **Inspector** window, for **position** > **y** type **0.5**
   - For **scale** > **x** type **0.25**
   - For **scale** > **y** type **0.25**
   - For **scale** > **z** type **0.25**

   ![cube properties](setup/cube-properties-labelled-resized-66.png)
   
   - Menu **File** > **Save Scenes**
   - Menu **File** > **Save Project**

## Run the demo

   - Click **Run**. If you hold the business card in front of your computer's camera, you will see cube on top of it. If you do not have the business card, you can use a printout or a phone capture of the image found at **`<working-dir>`\reality-augmentation-using-cognitive-services\02-Cube\images\businesscard.png**.

   ![play](setup/play-labelled-resized-66.png)
