using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatistics : MonoBehaviour
{
    private int m_score = 0;

    private int m_health = 5;

    public TMP_Text ScoreTextField = null;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreTextField();
    }

    
    public void AddScore(int diff = 1)
    {
        m_score += diff;
        UpdateScoreTextField();
    }

    public void removeHealth(int diff = 1)
    {
        this.m_health -= diff;
        Debug.Log(m_health.ToString());
    }

    private void UpdateScoreTextField()
    {
        if (ScoreTextField != null)
        {
            ScoreTextField.text = m_score.ToString();
        }
    }

    public bool IsDead()
    {
        return this.m_health <= 0;
    }

}
