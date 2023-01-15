using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class coinsUpdate : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        int coins = GameManager.Instance.coins;
        text.text ="COINS X "+ coins.ToString();
    }
}
