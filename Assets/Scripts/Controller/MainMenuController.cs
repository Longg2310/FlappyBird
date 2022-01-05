using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void _PlayButtom()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void _Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
