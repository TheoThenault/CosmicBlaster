using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatistics : MonoBehaviour
{
    private int m_score = 0;

    public TMP_Text ScoreTextField = null;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTextField();
    }

    
    public void AddScore(int diff = 1)
    {
        m_score += diff;
        UpdateTextField();
    }

    private void UpdateTextField()
    {
        if (ScoreTextField != null)
        {
            ScoreTextField.text = m_score.ToString();
        }
    }

}
