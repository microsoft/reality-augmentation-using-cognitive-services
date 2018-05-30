using System.Collections.Generic;

/*
  Example:
  "{\"status\":\"Succeeded\",\"recognitionResult\":{\"lines\":[{\"boundingBox\":[347,218,1028,264,1007,584,326,538],\"text\":\"Hello\",\"words\":[{\"boundingBox\":[287,269,975,247,931,552,243,574],\"text\":\"Hello\"}]}]}}"
 
"{
  \"status\": \"Succeeded\",
  \"recognitionResult\": {
    \"lines\": [
      {
        \"boundingBox\": [
          347,
          218,
          1028,
          264,
          1007,
          584,
          326,
          538
        ],
        \"text\": \"Hello\",
        \"words\": [
          {
            \"boundingBox\": [
              287,
              269,
              975,
              247,
              931,
              552,
              243,
              574
            ],
            \"text\": \"Hello\"
          }
        ]
      }
    ]
  }
}"
    
 */

[System.Serializable]
public class HandwritingAPIResults
{
    public string status;
    public RecognitionResult recognitionResult;

    override
    public string ToString()
    {
        string words = "";
        foreach (Line2 line in recognitionResult.lines)
        {
            if (words.Length > 0)
            {
                words += " ";
            }
            words += line.text;
        }
        return words;
    }
}

[System.Serializable]
public class RecognitionResult
{
    public List<Line2> lines;
}

[System.Serializable]
public class Line2
{
    public string text;
}