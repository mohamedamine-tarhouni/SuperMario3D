using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        int score = GameManager.Instance.score;
        text.text = "Score : \n" + score.ToString();
    }
}
