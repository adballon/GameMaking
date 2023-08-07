using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMapManager : MonoBehaviour
{
    public Roomcode[] roomsamples;

    public Roomcode NextRoom; //이동 할 방
    public Roomcode CurrRoom; //현재 방
    public GameObject Hero;

    int ran;
    int cnt = 0;

    //Start is called before the first frame update
    void Start()
    {
        Hero = GameObject.Find("hero");

        ran = Random.Range(1, roomsamples.Length - 1);
        CurrRoom = roomsamples[0];
        NextRoom = roomsamples[ran];
        CurrRoom.isEnter = true;

        CurrRoom.roomdoors[0].connected = NextRoom.roomdoors[(CurrRoom.roomdoors[0].direction + 2) % 4];
        CurrRoom.roomdoors[1].connected = NextRoom.roomdoors[(CurrRoom.roomdoors[1].direction + 2) % 4];
        CurrRoom.roomdoors[2].connected = NextRoom.roomdoors[(CurrRoom.roomdoors[2].direction + 2) % 4];
        CurrRoom.roomdoors[3].connected = NextRoom.roomdoors[(CurrRoom.roomdoors[3].direction + 2) % 4];

    }

    //Update is called once per frame
    void Update()
    {
        if (Hero.GetComponent<Hero1>().MoveRoom == true)
        {
            Hero.GetComponent<Hero1>().MoveRoom = false;

            CurrRoom = NextRoom;
            CurrRoom.isEnter = true;

            randomRoom();
        }
    }

    void randomRoom()
    {
        if (CurrRoom == roomsamples[11]) //현재 방이 마지막 방이다
        {
            CurrRoom.roomdoors[0].connected = roomsamples[0].roomdoors[2]; //첫 번째 방 아래쪽과 연결
            for (int i = 1; i < 4; i++)//위쪽 문을 제외한 문 못가게
            {
                CurrRoom.roomdoors[i].Setactive(false);
            }

            for (int i = 1; i < roomsamples.Length; i++) //나머지 방에 대해 방문 표시 삭제
            {
                roomsamples[i].isEnter = false;
            }
            NextRoom = roomsamples[0];

            return;
        }

        for (; ; ) //무한루프
        {
            if (cnt == 10) //모든 방에 다 방문했다
            {
                break; //루프 탈출
            }

            ran = Random.Range(1, roomsamples.Length - 1); //index를 랜덤으로 뽑아서
            NextRoom = roomsamples[ran]; //그 index에 해당하는 방이

            if (NextRoom.isEnter == false) //방문하지 않았다
            {
                cnt = 0;
                break; //루프 탈출
            }
            cnt++; //방문 했다면 방문 cnt++
        }

        if (cnt == 10) //모든 방에 방문 했다
        {
            NextRoom = roomsamples[11];
        }

        for (int i = 0; i < 4; i++)
        {
            CurrRoom.roomdoors[i].connected = NextRoom.roomdoors[(NextRoom.roomdoors[i].direction + 2) % 4]; //현재 방과 다음 방을 연결
        }
    }
}