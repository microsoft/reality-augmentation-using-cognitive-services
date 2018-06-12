using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionAPIUtils
{
    const string VISION_API_SUBSCRIPTION_KEY = "YOUR_SUBSCRIPTION_KEY";
    const string VISION_API_BASE_URL = "YOUR_BASE_URL";

    public static IEnumerator MakeAnalysisRequest(string imageFilePath, string textComponent, Type type)
    {
        byte[] bytes = ImageUtils.GetImageAsByteArray(imageFilePath);
        return MakeAnalysisRequest(bytes, textComponent, type);
    }

    public static IEnumerator MakeAnalysisRequest(byte[] bytes, string textComponent, Type type)
    {
        var headers = new Dictionary<string, string>() {
            {"Ocp-Apim-Subscription-Key", VISION_API_SUBSCRIPTION_KEY },
            {"Content-Type","application/octet-stream"}
        };
        string requestParameters = "visualFeatures=Description&language=en";
        string uri = VISION_API_BASE_URL + "/analyze?" + requestParameters;
		if ( (bytes != null) && (bytes.Length > 0) ) {
			WWW www = new WWW(uri, bytes, headers);
			yield return www;

			if (www.error != null)
			{
				TextUtils.setText(www.error, textComponent, type);
			}
			else
			{
				VisionAPIResults results = JsonUtility.FromJson<VisionAPIResults>(www.text);
				TextUtils.setText(results.ToString(), textComponent, type);
			}
		}
    }
}