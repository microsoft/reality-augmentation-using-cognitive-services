# Demo Three - ImageLabels

This demo builds upon the previous demo by showing how to extract meaningful text about a recognized image from the Computer Vision API and superimpose it on top of your view.

![demo](setup/demo3-running-resized-66.png)

## Setup Instructions

Follow these instructions to deploy the application when using the emulator:

1. Add image to Vuforia image database

   - Navigate to [Vuforia Developer Portal](https://developer.vuforia.com)
   - Login
   - Click **Target Manager**
   - Under **Database** click **HoloWorld**

   ![add target](setup/add-target-labelled-resized-66.png)

   - Click **Add Target**
   - For **Type** select **Single Image**
   - For **File** click **Browse...**
   - Select **`<working-dir>`\reality-augmentation-using-cognitive-services\03-ImageLabels\images\satya-nadella.jpg**
   - Click **Open**
   - For **Width** type **5**
   - For **Name** type **satya-nadella**
   - Click **Add**

1. Download updated Vuforia image database

   ![click download database](setup/click-download-database-labelled-resized-66.png)

   - Click **Download Database (All)**

   ![download database](setup/download-database-labelled-resized-66.png)

   - Select **Unity Editor**
   - Click **Download**
   - Click **Save As** > **`<working-dir>`\HoloWorld.unitypackage**
   - Click **Save** (Note - go ahead and overwrite the existing one)

1. Import updated Vuforia image database into Unity project
   - Start **Unity**
   - Click **Projects** > **HoloWorld**

   ![import package](setup/import-package-labelled-resized-66.png)

   - Menu **Assets** > **Import Package** > **Custom Package...**
   - Browse: **`<working-dir>`\Hololens\HoloWorld.unitypackage**

   ![import all](setup/import-all-labelled-resized-66.png)

   - Click **Open** > **All** > **Import**

1. Create image target

   ![image target](setup/image-target-labelled-resized-66.png)

   - Select **SampleScene**
   - Click **Create** > **Vuforia** > **Image**

   ![text properties](setup/image-target-properties-labelled-resized-66.png)

   - For **ImageTarget** type **SatyaNadellaTarget**
   - For **Database** select **HoloWorld**
   - For **Image Target** select **satya-nadella**

   ![create text](setup/create-text-labelled-resized-66.png)

   - Right click **SatyaNadellaTarget**
   - Select **3D Object** > **3D Text**

   ![text properties](setup/text-properties-labelled-resized-66.png)

   - For **New Text** type **SatyaNadellaText**
   - For **position** > **x** type **-1**
   - For **rotation** > **x** type **90**
   - For **scale** > **x** type **0.1**
   - For **scale** > **y** type **0.1**
   - For **scale** > **z** type **0.1**

   > Checkpoint: Click **Run**. If you hold the picture of Satya Nadella in front of your computer's camera, you will see the default text superimposed on top of it.

1. Copy images to streaming directory

   - Copy **`<working-dir>`\reality-augmentation-using-cognitive-services\03-ImageLabels\images\satya-nadella.jpg** to
  to **`<working-dir>`\HoloWorld\Assets\StreamingAssets**

1. Add scripts for calling Computer Vision API

   - For **Text** remove the default text
   - Create a **Scripts** folder in **`<working-dir>`\HoloWorld\Assets**
   - Copy **`<working-dir>`\reality-augmentation-using-cognitive-services\03-ImageLabels\scripts\ImageUtils.cs** to **`<working-dir>`\HoloWorld\Assets\Scripts**
   - Copy **`<working-dir>`\reality-augmentation-using-cognitive-services\03-ImageLabels\scripts\SetTextSatyaNadella.cs** to **`<working-dir>`\HoloWorld\Assets\Scripts**
   - Copy **`<working-dir>`\reality-augmentation-using-cognitive-services\03-ImageLabels\scripts\TextUtils.cs** to **`<working-dir>`\HoloWorld\Assets\Scripts**
   - Copy **`<working-dir>`\reality-augmentation-using-cognitive-services\03-ImageLabels\scripts\VisionAPIResults.cs** to **`<working-dir>`\HoloWorld\Assets\Scripts**
   - Copy **`<working-dir>`\reality-augmentation-using-cognitive-services\03-ImageLabels\scripts\VisionAPIUtils.cs** to **`<working-dir>`\HoloWorld\Assets\Scripts**

   ![add component](setup/add-component-labelled-resized-66.png)

   - Click **Add Component** > **Scripts** > **Set Text Satya Nadella**

   > Checkpoint: Click **Run**. If you hold the picture of Satya Nadella in front of your computer's camera, you will see a **404 Not Found** error.

1. Configure scripts for calling Computer Vision API

   - For **Script** double click **SetTextSatyaNadella** (Note - this will open the script in Visual Studio)
   - Right click **VisionAPIUtils** in the code and select **Go To Definition**
   - Replace **YOUR_SUBSCRIPTION_KEY** with your Computer Vision API subscription key
   - Replace **YOUR_BASE_URL** with your Computer Vision API base URL
   - Menu **File** > **Save All**

   - From the Unity Editor
   - Menu **File** > **Save Scenes**
   - Menu **File** > **Save Project**

## Run the demo

   ![play](setup/play-labelled-resized-66.png)

   - Click **Run**. If you hold the picture of Satya Nadella in front of your computer's camera, you will see information about him superimposed on top of it.
