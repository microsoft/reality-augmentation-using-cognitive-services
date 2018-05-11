# Demo 2 - Cube

This demo shows how to recognize and track an image, and draw a cube on top of it. When running, it looks like this:

![demo](images/demo-1-running.png)

## Setup Instructions

For this demo, we will build upon what we did for the previous demo.

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
   - Click **Add Target**
   - For **Type** select **Single Image**
   - For **File** click **Browse...**
   - select: **`<local-repo-dir>`\reality-augmentation-using-cognitive-services\setup\target-images\charlie-card.jpg**
   - click: **Open**
   - type: Width: **5**
   - type: Name: **charlie-card**
   - click: **Add**
1. Download Vuforia image database
   - click: **Download Database (All)**
   - select: **Unity Editor**
   - click: **Download**
   - click: **Save As** > **`<local-repo-dir>`\reality-augmentation-using-cognitive-services**
   - click: **Save**
1. Import Vuforia image database into Unity project
   - from: Unity: project: **AugmentedRealityDemo**
   - menu: **Assets** > **Import Package** > **Custom Package...**
   - browse: **`<local-repo-dir>`\reality-augmentation-using-cognitive-services\AugmentedRealityDemo\AugmentedRealityDemo.unitypackage**
   - click: **open** > **All** > **Import**
1. Restart Unity Editor
   - click **Projects** > **AugmentedRealityDemo**
1. Create cube on top of recognized image in Unity project
   - right-click: **MixedRealityCameraParent** > **Delete**
   - right-click: **Default Cursor** > **Delete**
   - right-click: **InputManager** > **Delete**
   - right click **Directional Light** > **Delete**
   - click menu option **GameObject** > **Vuforia** > **AR Camera**
   - click **Import** to import assets
   - select menu option **Edit** > **Project Settings** > **Player**
   - expand **XR Settings**, check **Vuforia Augmented Realit**, and click **Accept**
   - select: **AR Camera** > **Inspector** tab
   - click: **Open Vuforia configuration**
   - paste: App License Key: **`<vuforia-license-key>`**
   - check: Databases: **Load AugmentedRealityDemo database**
   - check: **Activate**
   - click menu option **GameObject** > **Vuforia** > **Image**
   ??????- drag: under: AR Camera: **ImageTarget**
   - select: **ImageTarget**
   - type: name: **CharlieCardTarget**
   - select: Database: **AugmentedRealityDemo**
   - right click: **CharlieCardTarget**
   - select: **3D Object** > **Cube**
   - type: position: y: **0.5**
   - type: scale: x: **0.25**
   - type: scale: y: **0.25**
   - type: scale: z: **0.25**
   - menu: **File** > **Save Scenes**
   - type: **Scene1**
   - menu: **File** > **Save Project**
1. Run the Demo
   - print: **`<local-repo-dir>`\reality-augmentation-using-cognitive-services\setup\target-images\charlie-card.jpg**
   - click: **run arrow**. If you hold the printed image of the Charlie Card in front of your computer's camera, you will see cube on top of it.
