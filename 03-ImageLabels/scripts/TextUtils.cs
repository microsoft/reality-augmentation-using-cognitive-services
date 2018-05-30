using System;
using UnityEngine;
using UnityEngine.UI;

public class TextUtils
{
    public static void setText(string labelText, string textComponent, Type type)
    {
        Component component = GameObject.Find(textComponent).GetComponent(type);
        Type componentType = component.GetType();
        if (componentType == typeof(TextMesh))
        {
            ((TextMesh)component).text = labelText;
        }
        if (componentType == typeof(Text))
        {
            ((Text)component).text = labelText;
        }
    }
}