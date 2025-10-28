using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchase : MonoBehaviour
{
    public void PurchaseSushi()
    {
        Player2 player = FindAnyObjectByType<Player2>();
        if(player != null)
        {
            if (PlayerPrefs.GetInt("Coins") < 10)
            {
                Debug.Log("10 코인이 부족합니다.");
            }
            else
            {
                Debug.Log("초밥 구매");
                int coin = PlayerPrefs.GetInt("Coins");
                PlayerPrefs.SetInt("Coins", coin - 10);
                player.BuyPetSushi();
            }
        }
                
    }
    public void PurchaseBear()
    {
        Player2 player = FindAnyObjectByType<Player2>();
        if(player != null)
        {
            if (PlayerPrefs.GetInt("Coins") < 15)
            {
                Debug.Log("15 코인이 부족합니다.");
            }
            else
            {
                Debug.Log("곰 구매");
                int coin = PlayerPrefs.GetInt("Coins");
                PlayerPrefs.SetInt("Coins", coin - 15);
                player.BuyPetBear();
            }
        }
        
    }
}
