using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.WSA.WebCam;
using Vuforia;

public class CameraUtils : MonoBehaviour
{
    static PhotoCapture photoCaptureObject = null;
    static Texture2D targetTexture = null;

    //public void Identify()
    public static void Identify()
    {
        VuforiaBehaviour.Instance.enabled = false;
        TakePicture();
    }

    //private void TakePicture()
    private static void TakePicture()
    {
        Resolution cameraResolution = PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();
        targetTexture = new Texture2D(cameraResolution.width, cameraResolution.height, TextureFormat.RGBA32, false);
        PhotoCapture.CreateAsync(false, delegate (PhotoCapture captureObject) {
            photoCaptureObject = captureObject;

            CameraParameters c = new CameraParameters();
            c.cameraResolutionWidth = targetTexture.width;
            c.cameraResolutionHeight = targetTexture.height;
            c.pixelFormat = CapturePixelFormat.PNG;

            captureObject.StartPhotoModeAsync(c, delegate (PhotoCapture.PhotoCaptureResult result) {
                photoCaptureObject.TakePhotoAsync(OnCapturedPhotoToMemory);
            });
        });
    }

    private static void OnCapturedPhotoToMemory(PhotoCapture.PhotoCaptureResult result, PhotoCaptureFrame photoCaptureFrame)
    {
        VuforiaBehaviour.Instance.enabled = true;
        List<byte> imageBufferList = new List<byte>();

        // Copy the raw IMFMediaBuffer data into our empty byte list.
        photoCaptureFrame.CopyRawImageDataIntoBuffer(imageBufferList);
        byte[] bytes = imageBufferList.ToArray();

        // Populate image info
        SetImageLabel setImageLabel = GameObject.Find("txtImageInfo").gameObject.GetComponent<SetImageLabel>();
        setImageLabel.image = bytes;

        // Show snapshhot
        UnityEngine.UI.Image imgSnapshot = GameObject.Find("imgSnapshot").gameObject.GetComponent<UnityEngine.UI.Image>();
        Texture2D texture2D = new Texture2D(2, 2, TextureFormat.RGBA32, false);
        texture2D.LoadImage(bytes);
        Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(1.0f, 1.0f));
        imgSnapshot.sprite = sprite;

        // Deactivate our camera
        photoCaptureObject.StopPhotoModeAsync(OnStoppedPhotoMode);
    }

    private static void OnStoppedPhotoMode(PhotoCapture.PhotoCaptureResult result)
    {
        // Shutdown our photo capture resource
        photoCaptureObject.Dispose();
        photoCaptureObject = null;
    }
}