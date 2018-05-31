using System.Collections.Generic;

/*
  Example:
  "{\"language\":\"en\",\"orientation\":\"Up\",\"textAngle\":-0.027925268031908652,\"regions\":[{\"boundingBox\":\"328,286,714,187\",\"lines\":[{\"boundingBox\":\"328,286,714,187\",\"words\":[{\"boundingBox\":\"328,286,714,187\",\"text\":\"hello\"}]}]}]}"
 
"{
  \"language\": \"en\",
  \"orientation\": \"Up\",
  \"textAngle\": -0.027925268031908652,
  \"regions\": [
    {
      \"boundingBox\": \"328,
      286,
      714,
      187\",
      \"lines\": [
        {
          \"boundingBox\": \"328,
          286,
          714,
          187\",
          \"words\": [
            {
              \"boundingBox\": \"328,
              286,
              714,
              187\",
              \"text\": \"hello\"
            }
          ]
        }
      ]
    }
  ]
}"
    
 */

[System.Serializable]
public class OCRAPIResults
{
    public string language;
    public string orientation;
    public float textAngle;
    public List<Region> regions;

    override
    public string ToString()
    {
        string words = "";
        foreach (Region region in regions)
        {
            foreach (Line line in region.lines)
            {
                foreach (Word word in line.words)
                {
                    if (words.Length > 0)
                    {
                        words += " ";
                    }
                    words += word.text;
                }
            }
        }
        return words;
    }
}

[System.Serializable]
public class Region
{
    public string boundingBox;
    public List<Line> lines;
}

[System.Serializable]
public class Line
{
    public string boundingBox;
    public List<Word> words;
}

[System.Serializable]
public class Word
{
    public string boundingBox;
    public string text;
}