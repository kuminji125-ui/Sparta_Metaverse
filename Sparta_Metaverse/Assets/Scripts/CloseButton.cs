using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CloaseButton : MonoBehaviour
{
    public Image panel;
    public GameManager gameManager;
    public void Close()
    {
        panel.gameObject.SetActive(false);
        gameManager.isAction = false;
    }
}
