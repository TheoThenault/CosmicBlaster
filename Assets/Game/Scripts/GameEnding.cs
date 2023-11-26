using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public PlayerStatistics playerStatistics = null;

    public CanvasGroup GameOverUi = null;
    
    private bool isUiShown = false;

    public float fadeDuration = 1f;

    float m_Timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (isUiShown)
        {
            m_Timer += Time.deltaTime;
            GameOverUi.alpha = m_Timer / fadeDuration;
        }
    }

    public void EnableUI()
    {
        m_Timer = 0;
        isUiShown = true;
        GameOverUi.gameObject.SetActive(true);
    }

    public void DisableUI()
    {
        isUiShown = false;
        GameOverUi.alpha = 0;
        GameOverUi.gameObject.SetActive(false);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
