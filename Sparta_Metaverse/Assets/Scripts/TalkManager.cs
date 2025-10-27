using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�ȳ�?:0", "��Ÿ���� ������ ó�� �Ա���?:1","�ֺ��� �ѷ����鼭 �����غ�:2","����� ������ �Խ��ǿ� ���� �ְ� ������ ��ϵǾ� �־�.:1" });
        talkData.Add(2000, new string[] { "�ȳ�?:0", "���� �ִ� ���� ������ ���� ������ �� �� �־�:1","�ű���� ����� ����� �Ǵ� �ѹ� �غ�.:2" });
        talkData.Add(100, new string[] { "����� �������ڴ�." });
        talkData.Add(200, new string[] { "����� �����ִ� �Խ����̴�." });
        talkData.Add(300, new string[] { "������ �� �� �ִ� ���̴�." });
        talkData.Add(400, new string[] { "������ ���̴�. �� �� ����." });
        talkData.Add(500, new string[] { "�ʷϻ� ���̴�. �� �� ����." });
        talkData.Add(3000, new string[] { "�� ������ ���ڱ� �������� �ʹ� ������.:0" });

        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
        portraitData.Add(3000 + 0, portraitArr[8]);
    }
    public string GetTalk(int id, int talkIndex)
    {
        if(talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        }   
    }
    public Sprite GetPortrait(int id, int portaitIndex)
    {
        return portraitData[id + portaitIndex];
    }
}
