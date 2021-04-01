using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public GameObject PanelCredits;
    public GameObject PanelOptions;

    public GameObject ScrollBarSound;
    public GameObject ScrollBarMusic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnGame()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        GlobalList.SaundValue = ScrollBarSound.GetComponent<Scrollbar>().value;
        GlobalList.MusicValue = ScrollBarMusic.GetComponent<Scrollbar>().value;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameMode");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void OnExit()
    {
        Application.Quit();
    }

    
    public void OnCredits()
    {
        PanelCredits.SetActive(true);
    }

    
    public void OffCredits()
    {
        PanelCredits.SetActive(false);
    }
    
    public void OnOptions()
    {
        PanelOptions.SetActive(true);
    }

    
    public void OffOptions()
    {
        PanelOptions.SetActive(false);
    }


}
