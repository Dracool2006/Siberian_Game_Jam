using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class AdvertDueGame : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    EventSystem _current;

    void Start()
    {
        StartCoroutine(StartShowAd(YG.YandexGame.timerShowAd));
       
    }

    private IEnumerator StartShowAd(float time)
    {
        yield return new WaitForSeconds(time);
        if(YG.YandexGame.timerShowAd > 65 && YG.YandexGame.nowFullAd == false && YG.YandexGame.nowVideoAd == false)
        {
            _animator.updateMode = AnimatorUpdateMode.UnscaledTime;
            _animator.SetTrigger("ShowAd");
            Time.timeScale = 0.0f;
            _current = EventSystem.current;
            _current.enabled = false;
            AudioListener.volume = 0;
        }
        else
        {
            StartCoroutine(StartShowAd(65.0f));
        }
        
    }

    public void ShowAd()
    {
        YG.YandexGame.FullscreenShow();
        _current.enabled = true;
        AudioListener.volume = 1;
        Time.timeScale = 1.0f;
        StartCoroutine(StartShowAd(65.0f));
    }
}
