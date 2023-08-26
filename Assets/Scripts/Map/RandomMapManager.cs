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
    public Roomcode CurrRoom; //���� ��

    public Doorcode Hitdoor;

    int ran()
    {
        return UnityEngine.Random.Range(1, roomsamples.Length - 1);
    }

    //Start is called before the first frame update
    void Start()
    {
        CurrRoom = roomsamples[0];
        NextRoom = roomsamples[ran()];

        visited.Add(CurrRoom);
    }

    //Update is called once per frame
    void Update()
    {
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

        visited.Clear();
    }

    public void randomRoom() //�� �̵� �Լ�
    {
        if(CurrRoom == roomsamples[11]) //���� ���� ������ ���̴�
        {
            CurrRoom.roomdoors[0].connected = roomsamples[0].roomdoors[2]; //ù ��° �� �Ʒ��ʰ� ����

            NextRoom = roomsamples[0];
            for(int i= 0; i<4;i++)
            {
                if (CurrRoom.roomdoors[i] == null)
                {
                    CurrRoom.roomdoors[i].SetActive(false);
                }
            }

            Hitdoor.connected = NextRoom.roomdoors[(Hitdoor.direction + 2) % 4]; //���� �� ����
            NextRoom.roomdoors[(Hitdoor.direction + 2) % 4].connected = Hitdoor; //���� �� ����

            visited.Add(roomsamples[11]);

            return;
        }

        if (Hitdoor.connected == null) //�� ���� ������� ���� ���̴�
        {
            for (;;) //���ѷ���
            {
                if (visited.Count == 10) //��� �濡 �� �湮�ߴ�
                {
                    NextRoom = roomsamples[11]; //������ ������ �̵�

                    break; //���� Ż��
                }

                NextRoom = roomsamples[ran()]; // index�� �������� �̾Ƽ� ���� ������ ����

                if (visited.Contains(NextRoom) == false) //�� �濡 �湮���� �ʾҴ�
                {
                    visited.Add(NextRoom);
                    break; //Ż��
                }
            }

            Hitdoor.connected = NextRoom.roomdoors[(Hitdoor.direction + 2) % 4]; //���� �� ����
            NextRoom.roomdoors[(Hitdoor.direction + 2) % 4].connected = Hitdoor; //���� �� ����

        }
    }
    void Awake()
    {
        Instance = this;
    }
}
//prictyuve