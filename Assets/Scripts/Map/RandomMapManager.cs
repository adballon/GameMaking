using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RandomMapManager : MonoBehaviour
{
    public static RandomMapManager Instance;

    public Roomcode[] roomsamples;

    public List<Roomcode> visited = new List<Roomcode>(); //방문 한 방 목록

    public Roomcode NextRoom; //이동 할 방

    public Doorcode Hitdoor;

    int ran()
    {
        return UnityEngine.Random.Range(1, roomsamples.Length - 1);
    }

    //Start is called before the first frame update
    void Start()
    {
        visited.Add(roomsamples[0]);
    }

    //Update is called once per frame
    void Update()
    {
        if (visited.Count == 12) //현재 방이 마지막 보스 방이다
        {
            Roomcode now = roomsamples[roomsamples.Length - 1];
            Roomcode fir = roomsamples[0];

            for(int i=1;i<4;i++)
            {
                now.roomdoors[i].SetActive(false);
            }

            now.roomdoors[0].connected = fir.roomdoors[2];
        }
    }

    public void init() //연결된 모든 문 해제
    {
        for(int i=0; i<roomsamples.Length;i++)
        {
            for(int j=0;j<4;j++)
            {
                roomsamples[i].roomdoors[j].connected = null;
            }
        }

        for(int i=0;i<4;i++)
        {
            roomsamples[roomsamples.Length - 1].roomdoors[i].SetActive(true);
        }

        visited.Clear();
        visited.Add(roomsamples[0]);
    }

    public void randomRoom() //방 이동 함수
    {
        if (Hitdoor.connected == null) //그 문이 연결되지 않은 문이다
        {
            for (;;) //무한루프
            {
                if (visited.Count == 11) //모든 방에 다 방문했다
                {
                    NextRoom = roomsamples[11]; //마지막 방 지정
                    for (int i = 1; i < 4; i++)
                    {
                        NextRoom.roomdoors[i].SetActive(false);
                    }
                }
                else
                {
                    NextRoom = roomsamples[ran()]; // index를 랜덤으로 뽑아서 다음 방으로 지정
                }

                if (visited.Contains(NextRoom) == false) //그 방에 방문하지 않았다
                {
                    visited.Add(NextRoom);
                    Hitdoor.connected = NextRoom.roomdoors[(Hitdoor.direction + 2) % 4]; //다음 방 연결
                    NextRoom.roomdoors[(Hitdoor.direction + 2) % 4].connected = Hitdoor; //이전 방 연결
                    break; //탈출
                }
            }
        }
    }
    void Awake()
    {
        Instance = this;
    }
}