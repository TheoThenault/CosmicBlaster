using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatistics : MonoBehaviour
{
    static public int default_health = 5;
    static public int default_max_health = 5;

    public GameEnding gameEnding = null;

    private int m_score = 0;

    private int m_health = default_health;

    private int m_maxHealth = default_max_health;

    public UIController UserInterfaceController = null;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreTextField();
        UpdateHealthGauge();
    }

    public void Restart()
    {
        m_score = 0;
        m_health = default_health;
        m_maxHealth = default_max_health;
        UpdateScoreTextField();
        UpdateHealthGauge(); 
    }
    
    public void AddScore(int diff = 1)
    {
        m_score += diff;
        UpdateScoreTextField();
    }

    public void removeHealth(int diff = 1)
    {
        this.m_health -= diff;
        UpdateHealthGauge();
        if(this.m_health <= 0)
        {
            if(gameEnding != null)
            {
                Debug.Log("apoziejk");
                gameEnding.EnableUI();
            }
        }
    }

    public void addHealth(int diff = 1)
    {
        this.m_health += diff;
        if(this.m_health > m_maxHealth)
            m_health = m_maxHealth;
        UpdateHealthGauge();
    }

    private void UpdateScoreTextField()
    {
        if (UserInterfaceController != null)
        {
            UserInterfaceController.SetScore(m_score);
        }
    }

    private void UpdateHealthGauge()
    {
        if (UserInterfaceController != null)
        {
            float val = m_health / (m_maxHealth / 1.0f);
            //Debug.Log(val);
            UserInterfaceController.SetGaugeFill(val);
        }
    }

    public bool IsDead()
    {
        return this.m_health <= 0;
    }

}
