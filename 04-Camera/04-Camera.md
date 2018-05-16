# Demo Four - Camera

This demo builds upon the previous demo by showing how to take pictures on your device's camera, send it to the Computer Vision API, and overlay information about it on top of it in your view. When running, it looks like this:

![demo-one](https://github.com/Microsoft/reality-augmentation-using-cognitive-services/blob/master/setup/images/demo-1-running.png)

## Setup Instructions

Follow these instructions to deploy the application when using the emulator:

1. Add UI components

- Start **Unity**
- Click **Projects** > **HoloWorld**
- Click **SampleScene** > **Create** > **UI** > **Image**
- Type **imgSnapshot**
- For **Pos X** type **-580**
- For **Pos Y** type **100**
- For **Width** type **300**
- For **Height** type **200**
- Click **SampleScene** > **Create** > **UI** > **Button**
- Type **btnIdentify**
- For **Pos X** type **-630**
- For **Pos Y** type **300**
- For **Width** type **160**
- For **Height** type **30**
- Expand **btnIdentify**
- Select **Text**
- For **Text** type **Identify**
- Click **SampleScene** > **Create** > **UI** > **Panel**
- Type **pnlImageInfo**
- For **Left** type **30**
- For **Top** type **370**
- For **Right** type **1190**
- For **Bottom** type **100**
- Click **SampleScene** > **Create** > **UI** > **Text**
- Type **txtImageInfo**
- For **Pos X** type **-630**
- For **Pos Y** type **-150**
- For **Width** type **160**
- For **Height** type **200**
- For **Text** remove the default text **Next Text**

  > Checkpoint: Click **Run**. For now you will the new UI components. The don't do anything yet, but next we will configure scripts so that when you click the **Identify** button your device's camera takes a picture, sends the image to the Computer Vision API, and the results are displayed.

1. Add scripts
- Copy **`<working-dir>`\reality-augmentation-using-cognitive-services\scripts\ButtonHandler.cs** to **`<working-dir>`\HoloWorld\assets\Scripts\**
- Copy **`<working-dir>`\reality-augmentation-using-cognitive-services\scripts\CameraUtils.cs** to **`<working-dir>`\HoloWorld\assets\Scripts\**
- Copy **`<working-dir>`\reality-augmentation-using-cognitive-services\scripts\IdentificationUtils.cs** to **`<working-dir>`\HoloWorld\assets\Scripts\**
- Copy **`<working-dir>`\reality-augmentation-using-cognitive-services\scripts\SetImageLabels.cs** to **`<working-dir>`\HoloWorld\assets\Scripts\**

1. Hook up scripts

- Click **btnIdentify**
- Click **Add Component** > **Scripts** > **Button Handler**
- Click **txtImageInfo**
- Click **Add Component** > **Scripts** > **Set Image Label**
- Menu **File** > **Save All**

## Run the demo

  ![play](setup/play-labelled-resized-66.png)

  - Click **Run**. If you hold the picture of Satya Nadella in front of your computer's camera, you will see information about him superimposed on top of it.
