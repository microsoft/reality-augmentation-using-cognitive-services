using System.Collections.Generic;

/*
  Example:
  "[{\"faceId\":\"aecc1a04-a618-4f02-a0b2-0cd1d300ece6\",\"faceRectangle\":{\"top\":325,\"left\":512,\"width\":262,\"height\":262},\"faceAttributes\":{\"gender\":\"male\",\"age\":42.0,\"emotion\":{\"anger\":0.0,\"contempt\":0.002,\"disgust\":0.0,\"fear\":0.0,\"happiness\":0.152,\"neutral\":0.846,\"sadness\":0.0,\"surprise\":0.0}}}]"
 
"[
  {
    \"faceId\": \"aecc1a04-a618-4f02-a0b2-0cd1d300ece6\",
    \"faceRectangle\": {
      \"top\": 325,
      \"left\": 512,
      \"width\": 262,
      \"height\": 262
    },
    \"faceAttributes\": {
      \"gender\": \"male\",
      \"age\": 42.0,
      \"emotion\": {
        \"anger\": 0.0,
        \"contempt\": 0.002,
        \"disgust\": 0.0,
        \"fear\": 0.0,
        \"happiness\": 0.152,
        \"neutral\": 0.846,
        \"sadness\": 0.0,
        \"surprise\": 0.0
      }
    }
  }
]"
    
 */

[System.Serializable]
public class FacesAPIResults
{
    public string faceId;
    public FaceRectangle faceRectangle;
    public FaceAttributes faceAttributes;

    override
    public string ToString()
    {
        string text = "Age: " + faceAttributes.age + ", Gender: " + faceAttributes.gender +
                        ", Emotion: (Anger: " + faceAttributes.emotion.anger +
                        ", Contempt: " + faceAttributes.emotion.contempt +
                        ", Disgust: " + faceAttributes.emotion.disgust +
                        ", Fear: " + faceAttributes.emotion.fear +
                        ", Happiness: " + faceAttributes.emotion.happiness +
                        ", Neutral: " + faceAttributes.emotion.neutral +
                        ", Sadness: " + faceAttributes.emotion.sadness +
                        ", Surprise: " + faceAttributes.emotion.surprise + ")";
        return text;
    }
}

[System.Serializable]
public class FaceRectangle
{
    public float top;
    public float left;
    public float width;
    public float height;
}

[System.Serializable]
public class FaceAttributes
{
    public string gender;
    public float age;
    public Emotion emotion;
}

[System.Serializable]
public class Emotion
{
    public float anger;
    public float contempt;
    public float disgust;
    public float fear;
    public float happiness;
    public float neutral;
    public float sadness;
    public float surprise;
}