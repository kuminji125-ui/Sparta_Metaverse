using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public TalkManager talkManager;
    public int talkIndex;
    public Image portraitImg;
    public Image panel;
    public TextMeshProUGUI bestScoreTXT;
    public Image gameGuide;
    public void Action(GameObject scanObj)
    {
        isAction = true;
        scanObject = scanObj;
        ObjectData objData = scanObj.GetComponent<ObjectData>();
        if (objData.id == 300)
        {
            gameGuide.gameObject.SetActive(true);
            return;
        }
        if(objData.id == 200)
        {
            bestScoreTXT.text = PlayerPrefs.GetInt("BestScore").ToString();
            panel.gameObject.SetActive(true);
            return;
        }
        Talk(objData.id, objData.isNpc);
        talkPanel.SetActive(isAction);
        
    }
    void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
        if(talkData == null)
        {
            isAction =false;
            talkIndex = 0;
            return;
        }
        if (isNpc)
        {
            talkText.text = talkData.Split(':')[0];
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(":")[1]));
            portraitImg.color = new Color(1, 1, 1, 1);//����
        }
        else
        {
            talkText.text = talkData;
            portraitImg.color = new Color(1, 1, 1, 0);
        }
        isAction = true;
        talkIndex++;
    }
}
