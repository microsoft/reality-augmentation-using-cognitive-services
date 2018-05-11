# Demo 2 - Cube

This demo shows how to recognize and track an image, and draw a cube on top of it. When running, it looks like this:

![running](setup/demo2-running.png)

## Setup Instructions

For this demo, we will build upon what we did for the previous demo.

1. Clone this repo into a local download directory. Example:
   - choose a local repo directory, which we'll refer to as `<working-dir>, such as **c:\hololens**
   - open a DOS command prompt
   - type **mkdir `<working-dir>`**
   - type **cd `<working-dir>`**
   - type **git clone https://github.com/Microsoft/reality-augmentation-using-cognitive-services**
   - type **cd reality-augmentation-using-cognitive-services**
   - type **git checkout -b mlads**
   - type **git pull origin mlads**
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
   - Click **Target Manager** > **Add Database**
   - For **Name** type **HoloWorld**
   - Select **Device**
   - Click **Create**
   - Under **Database** click **HoloWorld**

   ![add target](setup/add-target-labelled-resized-66.png)

   - Click **Add Target**
   - For **Type** select **Single Image**
   - For **File** click **Browse...**
   - Select **`<working-dir>`\reality-augmentation-using-cognitive-services\images\businesscard.png**
   - Click **Open**
   - For **Width** type **5**
   - For **Name** type **businesscard**
   - Click **Add**
1. Download Vuforia image database

   ![click download database](setup/click-download-database-labelled-resized-66.png)

   - Click **Download Database (All)**

   ![download database](setup/download-database-labelled-resized-66.png)

   - Select **Unity Editor**
   - Click **Download**
   - Click **Save As** > **`<working-dir>`\HoloWorld.unitypackage**
   - Click **Save**
1. Import Vuforia image database into Unity project
   - Start **Unity**
   - Click **Projects** > **HoloWorld**

   ![import package](setup/import-package-labelled-resized-66.png)

   - Menu **Assets** > **Import Package** > **Custom Package...**
   - Browse: **`<working-dir>`\Hololens\HoloWorld.unitypackage**

   ![import all](setup/import-all-labelled-resized-66.png)

   - Click **Open** > **All** > **Import**

1. Create cube on top of recognized image in Unity project

   ![vuforia configuration](setup/vuforia-configuration-labelled-resized-66.png)

   - Click **AR Camera** > **Open Vuforia configuration**

   ![license key](setup/license-key-labelled-resized-66.png)

   - For **App License Key** paste your **`<vuforia-license-key>`**

   ![image target](setup/image-target-labelled-resized-66.png)

   - Select **SampleScene**
   - Click **Create** > **Vuforia** > **Image**

   ![target properties](setup/target-properties-labelled-resized-66.png)

   - For **ImageTarget** type **BusinessCardTarget**
   - For **Database** select **HoloWorld**
   - For **Image Target** select **businesscard**

   ![create cube](setup/create-cube-labelled-resized-66.png)

   - right click: **BusinessCardTarget**
   - select: **3D Object** > **Cube**

   ![cube properties](setup/cube-properties-labelled-resized-66.png)

   - For **position** > **y** type **0.5**
   - for **scale** > **x** type **0.25**
   - for **scale** > **y** type **0.25**
   - For **scale** > **z** type **0.25**
   - menu **File** > **Save Scenes**
   - menu **File** > **Save Project**

## Run the demo

![play](setup/play-labelled-resized-66.png)

- click **Run**. If you hold the business card in front of your computer's camera, you will see cube on top of it.
