using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject H2P_Panel;

    public void PlayGame(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ToggleH2P()
    {
        H2P_Panel.SetActive(true);
    }

    public void ExitH2P()
    {
        H2P_Panel.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void backToMain(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
