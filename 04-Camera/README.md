# Demo Four - Camera

This demo builds upon the previous demo by showing how to take pictures on your device's camera, send it to the Computer Vision API, and overlay information about it on top of it in your view. When running, here's an example of what it might look like:

![demo-four](setup/demo4-running-resized-66.png)

## Setup Instructions

Follow these instructions to deploy the application when using the emulator:

1. Add UI Image

   - Start **Unity**
   - Click **Projects** > **HoloWorld**

   ![create ui image](setup/create-ui-image-resized-66.png)

   - Select **SampleScene** > **Create** > **UI** > **Image**

   ![image properties](setup/ui-image-properties-labelled-resized-66.png)

   - For **Image** type **imgSnapshot**
   - For **Pos X** type **-580**
   - For **Pos Y** type **150**
   - For **Width** type **300**
   - For **Height** type **200**

1. Add UI Button

   ![create ui button](setup/create-ui-button-resized-66.png)

   - Click **SampleScene** > **Create** > **UI** > **Button**

   ![ui button properties](setup/ui-button-properties-labelled-resized-66.png)

   - Type **btnIdentify**
   - For **Pos X** type **-630**
   - For **Pos Y** type **300**
   - For **Width** type **160**
   - For **Height** type **30**

   ![ui button text properties](setup/ui-button-text-properties-labelled-resized-66.png)

   - Expand **btnIdentify**
   - Select **Text**
   - For **Text** type **Identify**
   - For **Font Size** type **20**

1. Add UI Panel

   ![create ui panel](setup/create-ui-panel-resized-66.png)

   - Click **SampleScene** > **Create** > **UI** > **Panel**

   ![ui panel properties](setup/ui-panel-properties-labelled-resized-66.png)

   - Type **pnlImageInfo**
   - For **Left** type **30**
   - For **Top** type **330**
   - For **Right** type **1190**
   - For **Bottom** type **130**

   ![create ui text](setup/create-ui-text-resized-66.png)

   - Click **SampleScene** > **Create** > **UI** > **Text**

1. Add UI Text

   ![ui text properties](setup/ui-text-properties-labelled-resized-66.png)

   - Type **txtImageInfo**
   - For **Pos X** type **-630**
   - For **Pos Y** type **-120**
   - For **Width** type **160**
   - For **Height** type **200**
   - For **Text** remove the default text **Next Text**
   - For **Font Size** set to **20**

  > Checkpoint: Click **Run**. For now you will see the layout of the new UI components. The won't do anything yet, but that's in the next section, where we will configure scripts so that when you click the **Identify** button your device's camera takes a picture, sends the image to the Computer Vision API, and the results are displayed. *Note:* you may need to click **Maximize On Play** to see the components.

1. Add scripts
   - Copy **`<working-dir>`\reality-augmentation-using-cognitive-services\04-Camera\scripts\ButtonHandler.cs** to **`<working-dir>`\HoloWorld\assets\Scripts**
   - Copy **`<working-dir>`\reality-augmentation-using-cognitive-services\04-Camera\scripts\CameraUtils.cs** to **`<working-dir>`\HoloWorld\assets\Scripts**
   - Copy **`<working-dir>`\reality-augmentation-using-cognitive-services\04-Camera\scripts\SetImageLabels.cs** to **`<working-dir>`\HoloWorld\assets\Scripts**

1. Hook up scripts

   ![add button script](setup/add-button-script-labelled-resized-66.png)

   - Click **btnIdentify**
   - Click **Add Component** > **Scripts** > **Button Handler**

    ![add text script](setup/add-text-script-labelled-resized-66.png)

   - Click **txtImageInfo**
   - Click **Add Component** > **Scripts** > **Set Image Label**
   - Menu **File** > **Save All**

## Run the demo

  ![play](setup/play-labelled-resized-66.png)

  - Click **Run**. If you hold your cellphone in front of your computer's camera and the click the **Identify** button and it will use the device camera to take a picture, send it to the Computer Vision API, and overlay information about it on top of it in your view.
