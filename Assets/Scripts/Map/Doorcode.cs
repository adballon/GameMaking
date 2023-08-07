using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorcode : MonoBehaviour
{
    GameObject hero;
    GameObject Room;

    public int direction; // 문이 어디에 붙어있는가(0:위쪽, 1:왼쪽, 2:아래쪽, 3:오른쪽)
    public Doorcode connected;  // 이 문을 통과하면 어느 문으로 가는가 (연결된 문)

    Vector3[] dir = { Vector2.up, Vector2.left, Vector2.down, Vector2.right };

    // 플레이어가 문에 닿으면 연결된 문으로 플레이어를 이동시킨다.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.transform.position = connected.transform.position + (dir[direction] * 2f);
            hero.GetComponent<Hero1>().MoveRoom = true;
            Room.GetComponent<RandomMapManager>().NextRoom.isEnter = true; //이동한 방에 대해 방문 완료 표시
        }
    }

    public void Setactive(bool active)
    {
        gameObject.SetActive(active);
    }

    void Start()
    {
        hero = GameObject.Find("hero");
        Room = GameObject.Find("Rooms");
    }
}