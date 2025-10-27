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
                Debug.Log("10 ������ �����մϴ�.");
            }
            else
            {
                Debug.Log("�ʹ� ����");
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
                Debug.Log("15 ������ �����մϴ�.");
            }
            else
            {
                Debug.Log("�� ����");
                int coin = PlayerPrefs.GetInt("Coins");
                PlayerPrefs.SetInt("Coins", coin - 15);
                player.BuyPetBear();
            }
        }
        
    }
}
