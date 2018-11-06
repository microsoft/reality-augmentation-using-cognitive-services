# Demo Four - Camera

This demo builds upon the previous demo by showing how to take pictures on your device's camera, send it to the Computer Vision API, and overlay information about it on top of it in your view. When running, here's an example of what it might look like:

![demo-four](setup/demo4-running-resized-66.png)

## Setup Instructions

Follow these instructions to deploy the application when using the emulator:

1. Add UI Dropdown

   - Start **Unity**
   - Click **Projects** > **HoloWorld**
   - Select **SampleScene** > **Create** > **UI** > **Dropdown**
   
   ![create ui dropdown](setup/create-ui-dropdown-resized-80.png)
   
   - Rename **Dropdown** to **ddAction**. Click *enter* to save the name change.
   - For **Pos X** type **-650**
   - For **Pos Y** type **300**
   
   ![image properties](setup/ui-dropdown-properties-labelled.png)
   
   - Remove default options
   - Add option **Identify**
   
   ![image properties](setup/ui-dropdown-options.png)
   
1. Add UI Button

   - Click **SampleScene** > **Create** > **UI** > **Button**

   ![create ui button](setup/create-ui-button-resized-66.png)

   - Rename **Button** to **btnGo**. Click *enter* to save the name change.
   - For **Pos X** type **-500**
   - For **Pos Y** type **300**
   - For **Width** type **100**

   ![ui button properties](setup/ui-button-properties-labelled.png)
   
   - Expand **btnGo**
   - Select **Text**
   - For **Text** type **Go**

   ![ui button text properties](setup/ui-button-text-properties-labelled.png)

1. Add UI Image

   - Select **SampleScene** > **Create** > **UI** > **Image**

   ![create ui image](setup/create-ui-image-resized-66.png)

   - Rename **Image** to **imgSnapshot**. Click *enter* to save the name change.
   - For **Pos X** type **-580**
   - For **Pos Y** type **150**
   - For **Width** type **300**
   - For **Height** type **200**

   ![image properties](setup/ui-image-properties-labelled-resized-66.png)

1. Add UI Panel

   - Click **SampleScene** > **Create** > **UI** > **Panel**

   ![create ui panel](setup/create-ui-panel-resized-66.png)
   
   - Rename **Panel** to **pnlImageInfo**. Click *enter* to save the name change.
   - For **Left** type **30**
   - For **Top** type **330**
   - For **Right** type **1190**
   - For **Bottom** type **130**

   ![ui panel properties](setup/ui-panel-properties-labelled-resized-66.png)

1. Add UI Text

   - Click **SampleScene** > **Create** > **UI** > **Text**

   ![create ui text](setup/create-ui-text-resized-66.png)

   - Rename **Text** to **txtImageInfo**. Click *enter* to save the name change.
   - For **Pos X** type **-630**
   - For **Pos Y** type **-120**
   - For **Width** type **160**
   - For **Height** type **200**
   - For **Text** remove the default text **New Text**
   - For **Font Size** set to **20**   

   ![ui text properties](setup/ui-text-properties-labelled-resized-66.png)

   > Checkpoint: Click **Run**. For now you will see the layout of the new UI components. This won't do anything yet, but in the next section we will configure scripts so that when you click the **Identify** button your device's camera takes a picture, sends the image to the Computer Vision API, and the results are displayed. *Note:* you may need to click **Maximize On Play** to see the components.

1. Add scripts
   - Copy **`<working-dir>`\reality-augmentation-using-cognitive-services\04-Camera\scripts\ButtonHandler.cs** to **`<working-dir>`\HoloWorld\Assets\Scripts**
   - Copy **`<working-dir>`\reality-augmentation-using-cognitive-services\04-Camera\scripts\CameraUtils.cs** to **`<working-dir>`\HoloWorld\Assets\Scripts**
   - Copy **`<working-dir>`\reality-augmentation-using-cognitive-services\04-Camera\scripts\SetImageLabels.cs** to **`<working-dir>`\HoloWorld\Assets\Scripts**

1. Hook up scripts

   - Click **btnGo**
   - Click **Add Component** > **Scripts** > **Button Handler**

   ![add button script](setup/add-button-script-labelled-resized-66.png)
   
   - Click **txtImageInfo**
   - Click **Add Component** > **Scripts** > **Set Image Label**
   - Menu **File** > **Save Scenes**
   - Menu **File** > **Save Project**

   ![add text script](setup/add-text-script-labelled-resized-66.png)

## Run the demo

  ![play](setup/play-labelled-resized-66.png)

  - Click **Run**. If you hold your cellphone in front of your computer's camera and click the **Identify** button, it will use the device camera to take a picture, send it to the Computer Vision API, and overlay information about it on top of it in your view.
