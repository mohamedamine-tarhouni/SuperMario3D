using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField]
    private GameObject[] _menu;
    [SerializeField]
    private GameObject _tutorial;
    //[SerializeField]
    //private GameObject[]
    public bool isPaused = false;
    public bool isTuto = true;
    [SerializeField]
    private AudioSource[] _audios_To_Pause;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            MenuManager.Instance = this;
        }
    }
    public void OpenMenu()
    {
        for (int i = 0; i < _audios_To_Pause.Length; i++)
        {
            _audios_To_Pause[i].Pause();
        }
        AudioManagerScript.Instance.playPause();
        for (int i = 0; i < _menu.Length; i++)
        {
            if (_menu[i].tag == "GameplayMenu")
            {
                _menu[i].SetActive(false);
            }
            else
            {
                _menu[i].SetActive(true);
            }
        }

        isPaused = true;
        Time.timeScale = 0;
        //AudioListener.pause = true;
    }
    public void CloseMenu()
    {
        for (int i = 0; i < _audios_To_Pause.Length; i++)
        {
            _audios_To_Pause[i].Play();
        }
        for (int i = 0; i < _menu.Length; i++)
        {
            if (_menu[i].tag == "PauseMenu")
            {
                _menu[i].SetActive(false);
            }
            else
            {
                _menu[i].SetActive(true);
            }
            isPaused = false;
            Time.timeScale = 1;
            //AudioListener.pause = false;
        }
    }
    public void closeTutorial()
    {
        _tutorial.SetActive(false);
        isTuto = false;
        isPaused = false;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        isPaused = false;
        Time.timeScale = 1;
        Debug.Log(isPaused);
        SceneManager.LoadScene("Level1");
    }
}
