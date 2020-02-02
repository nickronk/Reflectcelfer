using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TitleScript : MonoBehaviour
{
    public GameObject Panel;

    private void Start()
    {
        Panel.SetActive(false);
    }

    public void StartGame(int levelNum)
    {
        SceneManager.LoadSceneAsync(levelNum);
    }

    public void ShowCredits()
    {
        Panel.SetActive(true);
    }

    public void HideCredits()
    {
        Panel.SetActive(false);
    }

}
