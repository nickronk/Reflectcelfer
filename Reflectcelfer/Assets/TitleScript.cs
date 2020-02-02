using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TitleScript : MonoBehaviour
{
    public GameObject Panel;
    public Button startButton;

    private void Start()
    {
        Panel.SetActive(false);
        startButton.interactable = true;
    }

    public void StartGame(int levelNum)
    {
        SceneManager.LoadSceneAsync(levelNum);
    }

    public void ShowCredits()
    {
        Panel.SetActive(true);
        startButton.interactable = false;
    }

    public void HideCredits()
    {
        Panel.SetActive(false);
        startButton.interactable = true;
    }

}
