using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int coins=0;
    public int score=0;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }
    public void updateCoins()
    {
        coins++;
        AudioManagerScript.Instance.playCoinSound();
        updateScore(100);
        if (coins >= 100)
        {
            SceneLoader("Levelclear");
        }
        Debug.Log(coins);
    }        
    public void updateScore(int scoreToAdd)
    {
        score+= scoreToAdd;
    }    
    public void SceneLoader(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
