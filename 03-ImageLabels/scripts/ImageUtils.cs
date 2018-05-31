using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ImageUtils
{
    public static byte[] GetImageAsByteArray(string imageFilePath)
    {
        string fileName = Path.Combine(Application.streamingAssetsPath, imageFilePath);
        return System.IO.File.ReadAllBytes(fileName);
    }
}