using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMainMenu : MonoBehaviour
{
    public void BoutonJouer()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void BoutonQuitter()
    {
        Application.Quit();
    }
}
