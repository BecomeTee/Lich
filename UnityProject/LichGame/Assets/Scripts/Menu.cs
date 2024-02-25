using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("Lvl1");
    }

    public void ExitButtonPressed()
    {
        Application.Quit();
    }
}
