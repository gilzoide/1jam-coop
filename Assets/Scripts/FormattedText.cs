using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormattedText : MonoBehaviour
{
    public Text text;
    public string format;

    void Awake()
    {
        if (!text)
        {
            text = GetComponentInChildren<Text>();
        }
    }

    public void SetWith(params object[] list)
    {
        text.text = string.Format(format, list);
    }
}
