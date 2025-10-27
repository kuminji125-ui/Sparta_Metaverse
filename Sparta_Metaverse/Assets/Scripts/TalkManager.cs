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
        talkData.Add(1000, new string[] { "안녕?:0", "메타버스 마을에 처음 왔구나?:1","주변을 둘러보면서 구경해봐:2","참고로 오른쪽 게시판엔 게임 최고 점수가 기록되어 있어.:1" });
        talkData.Add(2000, new string[] { "안녕?:0", "여기 있는 돌을 만지면 수영 게임을 할 수 있어:1","신기록을 세우면 기록이 되니 한번 해봐.:2" });
        talkData.Add(100, new string[] { "평범한 나무상자다." });
        talkData.Add(200, new string[] { "기록이 적혀있는 게시판이다." });
        talkData.Add(300, new string[] { "게임을 할 수 있는 돌이다." });
        talkData.Add(400, new string[] { "빨간색 집이다. 들어갈 수 없다." });
        talkData.Add(500, new string[] { "초록색 집이다. 들어갈 수 없다." });
        talkData.Add(3000, new string[] { "이 동굴은 갑자기 빨려들어가서 너무 무서워.:0" });

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
