using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    public GameObject PanelOptions;
    public GameObject PanelPosthumous;
    public GameObject Inventory;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 0)
            {
                OffOptions();
            }
            else
            {
                OnOptions();
            }
        }
    }

    public void ToStartGame()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("StartMenu");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadYourAsyncSceneRestart());
    }

    IEnumerator LoadYourAsyncSceneRestart()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameMode");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void ActivatePostPortus()
    {
        Time.timeScale = 0;
        PanelPosthumous.SetActive(true);
        Inventory.SetActive(false);
    }

    public void OnOptions()
    {

        Time.timeScale = 0;
        Inventory.SetActive(false);
        PanelOptions.SetActive(true);
    }


    public void OffOptions()
    {
        Time.timeScale = 1;
        PanelOptions.SetActive(false);
        Inventory.SetActive(true);
    }
}
