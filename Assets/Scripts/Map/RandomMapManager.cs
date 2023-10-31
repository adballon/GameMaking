using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RandomMapManager : MonoBehaviour
{
    public static RandomMapManager Instance;

    public Roomcode[] roomsamples;

    public List<Roomcode> visited = new List<Roomcode>(); //�湮 �� �� ���

    public Roomcode NextRoom; //�̵� �� ��

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
        if (visited.Count == 12) //���� ���� ������ ���� ���̴�
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

    public void init() //����� ��� �� ����
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

    public void randomRoom() //�� �̵� �Լ�
    {
        if (Hitdoor.connected == null) //�� ���� ������� ���� ���̴�
        {
            for (;;) //���ѷ���
            {
                if (visited.Count == 11) //��� �濡 �� �湮�ߴ�
                {
                    NextRoom = roomsamples[11]; //������ �� ����
                    for (int i = 1; i < 4; i++)
                    {
                        NextRoom.roomdoors[i].SetActive(false);
                    }
                }
                else
                {
                    NextRoom = roomsamples[ran()]; // index�� �������� �̾Ƽ� ���� ������ ����
                }

                if (visited.Contains(NextRoom) == false) //�� �濡 �湮���� �ʾҴ�
                {
                    visited.Add(NextRoom);
                    Hitdoor.connected = NextRoom.roomdoors[(Hitdoor.direction + 2) % 4]; //���� �� ����
                    NextRoom.roomdoors[(Hitdoor.direction + 2) % 4].connected = Hitdoor; //���� �� ����
                    break; //Ż��
                }
            }
        }
    }
    void Awake()
    {
        Instance = this;
    }
}