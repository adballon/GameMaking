using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMapManager : MonoBehaviour
{
    public Roomcode[] roomsamples;

    public Roomcode NextRoom; //�̵� �� ��
    public Roomcode CurrRoom; //���� ��
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
        if (CurrRoom == roomsamples[11]) //���� ���� ������ ���̴�
        {
            CurrRoom.roomdoors[0].connected = roomsamples[0].roomdoors[2]; //ù ��° �� �Ʒ��ʰ� ����
            for (int i = 1; i < 4; i++)//���� ���� ������ �� ������
            {
                CurrRoom.roomdoors[i].Setactive(false);
            }

            for (int i = 1; i < roomsamples.Length; i++) //������ �濡 ���� �湮 ǥ�� ����
            {
                roomsamples[i].isEnter = false;
            }
            NextRoom = roomsamples[0];

            return;
        }

        for (; ; ) //���ѷ���
        {
            if (cnt == 10) //��� �濡 �� �湮�ߴ�
            {
                break; //���� Ż��
            }

            ran = Random.Range(1, roomsamples.Length - 1); //index�� �������� �̾Ƽ�
            NextRoom = roomsamples[ran]; //�� index�� �ش��ϴ� ����

            if (NextRoom.isEnter == false) //�湮���� �ʾҴ�
            {
                cnt = 0;
                break; //���� Ż��
            }
            cnt++; //�湮 �ߴٸ� �湮 cnt++
        }

        if (cnt == 10) //��� �濡 �湮 �ߴ�
        {
            NextRoom = roomsamples[11];
        }

        for (int i = 0; i < 4; i++)
        {
            CurrRoom.roomdoors[i].connected = NextRoom.roomdoors[(NextRoom.roomdoors[i].direction + 2) % 4]; //���� ��� ���� ���� ����
        }
    }
}