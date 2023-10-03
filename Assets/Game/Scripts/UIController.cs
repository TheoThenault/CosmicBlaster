using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_Text ScoreTextField = null;

    public RectTransform Gauge = null;

    public void SetScore(int value)
    {
        if(ScoreTextField != null)
        {
            ScoreTextField.text = value.ToString(); 
        }
    }

    public void SetGaugeFill(float percent)
    {
        if(Gauge != null)
        {
            Vector2 anchors = Gauge.anchorMax;
            anchors.Set(percent, 1);
            Gauge.anchorMax = anchors;  
        }
    }
}
