using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Main_Menu : MonoBehaviour
{
    public string SceneName;

    public Image FadeUI;

    public GameObject OptionsWindow;
    public GameObject Buttons;
    public GameObject fade;

    public void Awake()
    {
        //FadeUI.CrossFadeAlpha(0, 0, true);
        OptionsWindow.SetActive(false);
    }
    // Start is called before the first frame update
    public void Play()
    {
        FadeUI.CrossFadeAlpha(1, 1, true);
        //Buttons.SetActive(false);
        StartCoroutine(ChangeScene());

    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Update is called once per frame
    public void Quit()
    {
        print("QUIT GAME");
        Application.Quit();
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync(SceneName);
    }

    public void FadeOut()
    {
        fade.GetComponent<Animator>().Play("Fade"); 
    }

    public void Options()
    {
        OptionsWindow.SetActive(true);
    }

    public void CloseWindow()
    {
        OptionsWindow.SetActive(false);
    }
}
