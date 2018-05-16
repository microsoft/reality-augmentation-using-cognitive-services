using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Vuforia;
using UnityEngine.XR.WSA.WebCam;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.XR;
using System.Collections;

using System.Runtime.InteropServices;

// https://docs.unity3d.com/2018.1/Documentation/ScriptReference/XR.WSA.WebCam.PhotoCapture.html
// https://answers.unity.com/questions/507330/accessing-monobehaviour-classes-on-other-objects.html
// IMFMediaBuffer https://answers.unity.com/questions/1365662/how-can-i-convert-a-photocaptureframe-byte-data-in.html
// https://westus.dev.cognitive.microsoft.com/docs/services/56f91f2d778daf23d8ec6739/operations/56f91f2e778daf14a499e1fa
// Supported image formats: JPEG, PNG, GIF, BMP.
// Image file size must be less than 4MB.
// Image dimensions must be at least 50 x 50.


public class CameraUtils : MonoBehaviour
{
    static PhotoCapture photoCaptureObject = null;
    static Texture2D targetTexture = null;
    //static Text mText = null;

    const string subscriptionKey = "9f644a608d074bcf9858e4662012b9ab";
    //const string uriBase = "https://westcentralus.api.cognitive.microsoft.com/vision/v1.0/analyze";
    //https://[location].api.cognitive.microsoft.com/vision/v1.0/analyze[?visualFeatures][&details][&language]
    const string uriBase = "https://eastus.api.cognitive.microsoft.com/vision/v1.0/analyze";
    const bool isBackupResponseEnabled = true;

    //public void Identify(Text text)
    public void Identify()
    {
        //return null;

        //mText = text;
        VuforiaBehaviour.Instance.enabled = false;
        TakePicture3();
        //return null;
    }

    private void TakePicture3()
    {
        Resolution cameraResolution = PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();
        targetTexture = new Texture2D(cameraResolution.width, cameraResolution.height, TextureFormat.RGBA32, false);
        PhotoCapture.CreateAsync(false, delegate (PhotoCapture captureObject) {
            photoCaptureObject = captureObject;

            CameraParameters c = new CameraParameters();
            c.cameraResolutionWidth = targetTexture.width;
            c.cameraResolutionHeight = targetTexture.height;
            //c.pixelFormat = CapturePixelFormat.BGRA32;
            c.pixelFormat = CapturePixelFormat.PNG; // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            captureObject.StartPhotoModeAsync(c, delegate (PhotoCapture.PhotoCaptureResult result) {
                photoCaptureObject.TakePhotoAsync(OnCapturedPhotoToMemory3);
            });
        });
    }

    // https://sushanta1991.blogspot.com/2015/04/how-to-crop-image-in-unity-3d-or-how-to.html
    private Texture2D crop(Texture2D source, int targetWidth, int targetHeight)
    {
        int sourceWidth = source.width;
        int sourceHeight = source.height;
        float sourceAspect = (float)sourceWidth / sourceHeight;
        float targetAspect = (float)targetWidth / targetHeight;
        int xOffset = 0;
        int yOffset = 0;
        float factor = 1;
        if (sourceAspect > targetAspect)
        { // crop width
            factor = (float)targetHeight / sourceHeight;
            xOffset = (int)((sourceWidth - sourceHeight * targetAspect) * 0.5f);
        }
        else
        { // crop height
            factor = (float)targetWidth / sourceWidth;
            yOffset = (int)((sourceHeight - sourceWidth / targetAspect) * 0.5f);
        }
        Color32[] data = source.GetPixels32();
        Color32[] data2 = new Color32[targetWidth * targetHeight];
        for (int y = 0; y < targetHeight; y++)
        {
            for (int x = 0; x < targetWidth; x++)
            {
                var p = new Vector2(Mathf.Clamp(xOffset + x / factor, 0, sourceWidth - 1), Mathf.Clamp(yOffset + y / factor, 0, sourceHeight - 1));
                // bilinear filtering
                var c11 = data[Mathf.FloorToInt(p.x) + sourceWidth * (Mathf.FloorToInt(p.y))];
                var c12 = data[Mathf.FloorToInt(p.x) + sourceWidth * (Mathf.CeilToInt(p.y))];
                var c21 = data[Mathf.CeilToInt(p.x) + sourceWidth * (Mathf.FloorToInt(p.y))];
                var c22 = data[Mathf.CeilToInt(p.x) + sourceWidth * (Mathf.CeilToInt(p.y))];
                var f = new Vector2(Mathf.Repeat(p.x, 1f), Mathf.Repeat(p.y, 1f));
                data2[x + y * targetWidth] = Color.Lerp(Color.Lerp(c11, c12, p.y), Color.Lerp(c21, c22, p.y), p.x);
            }
        }

        var tex = new Texture2D(targetWidth, targetHeight);
        tex.SetPixels32(data2);
        tex.Apply(true);
        return tex;
    }

    public static Texture2D Crop(Texture2D source, int targetWidth, int targetHeight)
    {
        int factor = 3;

        int sourceWidth = source.width;
        int sourceHeight = source.height;
        Color32[] data = source.GetPixels32();
        //Color32[] data2 = new Color32[targetWidth * targetHeight];
        Color32[] data2 = new Color32[sourceWidth/ factor * sourceHeight/ factor];
        //for (int y = 0; y < targetHeight; y++)
        for (int y = 0; y < sourceHeight; y++)
        {
            //for (int x = 0; x < targetWidth; x++)
            for (int x = 0; x < sourceWidth; x++)
            {
                if ((y <= targetHeight / factor) && (x <= targetWidth / factor))
                {
                    data2[x + y * sourceWidth] = data[x + y * sourceWidth];
                }
            }
        }

        //var tex = new Texture2D(targetWidth, targetHeight);
        var tex = new Texture2D(sourceWidth/ factor, sourceHeight/ factor);
        tex.SetPixels32(data2);
        tex.Apply(true);
        return tex;
    }

    public static byte[] Crop(byte[] bytes)
    {
        //Resolution cameraResolution = PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();
        //int width = cameraResolution.width;
        //int height = cameraResolution.height;



        Resolution cameraResolution = PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();
        targetTexture = new Texture2D(cameraResolution.width, cameraResolution.height, TextureFormat.RGBA32, false);
        int width = targetTexture.width;
        int height = targetTexture.height;



        //byte[] data2 = new Byte[width * height];
        byte[] data2 = new byte[width * height];
        for (int y = 0; y < height; y++)
        {
            //for (int x = 0; x < targetWidth; x++)
            for (int x = 0; x < width; x++)
            {
                data2[x + y * width] = bytes[x + y * width];
                //data2[x + y * sourceWidth] = Color.Lerp(Color.Lerp(c11, c12, p.y), Color.Lerp(c21, c22, p.y), p.x);
            }
        }
        return data2;
    }


    public static Color32[] Crop(Texture2D source)
    {
        int width = source.width;
        int height = source.height;

        Color32[] data = source.GetPixels32();
        Color32[] data2 = new Color32[width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                data2[x + y * width] = data[x + y * width];
            }
        }
        return data2;
    }

    private static byte[] Color32ArrayToByteArray(Color32[] colors)
    {
        if (colors == null || colors.Length == 0)
            return null;

        int lengthOfColor32 = Marshal.SizeOf(typeof(Color32));
        int length = lengthOfColor32 * colors.Length;
        byte[] bytes = new byte[length];

        GCHandle handle = default(GCHandle);
        try
        {
            handle = GCHandle.Alloc(colors, GCHandleType.Pinned);
            IntPtr ptr = handle.AddrOfPinnedObject();
            Marshal.Copy(ptr, bytes, 0, length);
        }
        finally
        {
            if (handle != default(GCHandle))
                handle.Free();
        }

        return bytes;
    }

    //List<byte> OnCapturedPhotoToMemory3(PhotoCapture.PhotoCaptureResult result, PhotoCaptureFrame photoCaptureFrame)
    private void OnCapturedPhotoToMemory3(PhotoCapture.PhotoCaptureResult result, PhotoCaptureFrame photoCaptureFrame)
    //IEnumerator OnCapturedPhotoToMemory3(PhotoCapture.PhotoCaptureResult result, PhotoCaptureFrame photoCaptureFrame)
    {
        VuforiaBehaviour.Instance.enabled = true;
        List<byte> imageBufferList = new List<byte>();
        // Copy the raw IMFMediaBuffer data into our empty byte list.
        photoCaptureFrame.CopyRawImageDataIntoBuffer(imageBufferList);
        //return imageBufferList;
        //mText.text = "picture\ntaken";
        //XRSettings.enabled = true;

        byte[] bytes = imageBufferList.ToArray();
        //byte[] bytes = imageBufferList.ToArray().Take(5000).ToArray();

        //bytes = Crop(bytes);


        //StartCoroutine(MakeAnalysisRequest(bytes));
        //Text myText = GameObject.Find("test").GetComponent<Text>().
        //myText.StartCoroutine

        //StartCoroutine(Camera.main.GetComponent<myTimer>().Counter());
        //StartCoroutine(GameObject.Find("test").GetComponent<Text>().M

        //Text myText = GameObject.Find("test").GetComponent<Text>();
        //myText.
        //GameObject.Find("test").GetComponent(SetImageLabel)
        //GameObject g = (GameObject)GameObject.Instantiate("test");
        //var test = GameObject.Find("test");
        //test.GetComponent(SetImageLabel).

        SetImageLabel setImageLabel = GameObject.Find("txtImageInfo").gameObject.GetComponent<SetImageLabel>();
        //setImageLabel.MakeAnalysisRequest("satya-nadella.jpg");
        //setImageLabel.MakeAnalysisRequest("ddd");
        //setImageLabel.imageFilePath = "satya-nadella.jpg";
        setImageLabel.image = bytes;

        //GetComponent<Image>().sprite = dogImg;

        

        //byte[] fileData = File.ReadAllBytes(userImagePath);
        UnityEngine.UI.Image imgSnapshot = GameObject.Find("imgSnapshot").gameObject.GetComponent<UnityEngine.UI.Image>();
        Texture2D texture2D = new Texture2D(2, 2, TextureFormat.RGBA32, false);
        texture2D.LoadImage(bytes);


        //Texture2D texture2D2 = Crop(texture2D, 10, 10);





        Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(1.0f, 1.0f));
        //int x = 1280;
        //int y = 720;
        //Sprite sprite = Sprite.Create(texture2D, new Rect(texture2D.width/2, texture2D.height/2+100, 400, 300), new Vector2(1.0f, 1.0f));
        //Sprite sprite = Sprite.Create(texture2D, new Rect(400, 100, 480, 520), new Vector2(0.5f, 0.5f));
        //Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, 426, 240), new Vector2(1.0f, 1.0f));
        //Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D2.width, texture2D2.height), new Vector2(1.0f, 1.0f));
        imgSnapshot.sprite = sprite;

        //Color32[] colors = sprite.texture.GetPixels32();
        //byte[] bytes2 = Color32ArrayToByteArray(colors);
        //setImageLabel.image = sprite.texture.GetRawTextureData();
        //setImageLabel.image = bytes2;


        //setImageLabel.image = texture2D2.GetRawTextureData();







        //SetImageLabel setImageLabel = new SetImageLabel();
        //setImageLabel.MakeAnalysisRequest("satya-nadella.jpg");
        //myText.GetComponent(SetImageLabel.).
        //var other : SetImageLabel = FindObjectOfType(SetImageLabel);
        //go.GetComponent(OtherScript).DoSomething();

        //myText.StartCoroutine(myText.SetImageLabel());

        //transform.Find("Hand").GetComponent(OtherScript).foo = 2;

        //var otherScript: OtherScript = GetComponent(OtherScript);
        //otherScript.DoSomething();




        // Copy the raw image data into our target texture
        //photoCaptureFrame.UploadImageDataToTexture(targetTexture);

        // Create a gameobject that we can apply our texture to
        //GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        //Renderer quadRenderer = quad.GetComponent<Renderer>() as Renderer;
        //quadRenderer.material = new Material(Shader.Find("Unlit/Texture"));

        //quad.transform.parent = this.transform;
        //quad.transform.localPosition = new Vector3(0.0f, 0.0f, 3.0f);






        // In this example, we captured the image using the BGRA32 format.
        // So our stride will be 4 since we have a byte for each rgba channel.
        // The raw image data will also be flipped so we access our pixel data
        // in the reverse order.
        //int stride = 4;
        //float denominator = 1.0f / 255.0f;
        //List<Color> colorArray = new List<Color>();
        //for (int i = imageBufferList.Count - 1; i >= 0; i -= stride)
        //{
        //    float a = (int)(imageBufferList[i - 0]) * denominator;
        //    float r = (int)(imageBufferList[i - 1]) * denominator;
        //    float g = (int)(imageBufferList[i - 2]) * denominator;
        //    float b = (int)(imageBufferList[i - 3]) * denominator;

        //    colorArray.Add(new Color(r, g, b, a));
        //}

        //XRSettings.enabled = true;
        //VuforiaBehaviour.Instance.enabled = true;
        //setText("picture\ntaken");
        //XRSettings.enabled = true;
        //VuforiaBehaviour.Instance.enabled = true;
        //return colorArray;

        // Deactivate our camera
        photoCaptureObject.StopPhotoModeAsync(OnStoppedPhotoMode);
    }

    void OnStoppedPhotoMode(PhotoCapture.PhotoCaptureResult result)
    {
        // Shutdown our photo capture resource
        photoCaptureObject.Dispose();
        photoCaptureObject = null;
    }
}
