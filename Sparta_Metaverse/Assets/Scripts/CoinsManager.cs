using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CoinsManager : MonoBehaviour
{
    public TextMeshProUGUI coinsTXT;
    public int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("Coins",0); //코인 삭제
        coins = PlayerPrefs.GetInt("Coins");
    }

    // Update is called once per frame
    void Update()
    {
        coinsTXT.text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
