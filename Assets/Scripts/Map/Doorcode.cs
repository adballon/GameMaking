using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Doorcode : MonoBehaviour
{
    public static Doorcode Instance;


    GameObject sp;

    public int direction; // 문이 어디에 붙어있는가(0:위쪽, 1:왼쪽, 2:아래쪽, 3:오른쪽)
    public Doorcode connected;  // 이 문을 통과하면 어느 문으로 가는가 (연결된 문)
    public Roomcode inroom; //이 문이 달려있는 방
    public bool all_visit = false;

    Vector3[] dir = { Vector2.up, Vector2.left, Vector2.down, Vector2.right };

    // 플레이어가 문에 닿으면 연결된 문으로 플레이어를 이동시킨다.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RandomMapManager.Instance.Hitdoor = this;
            RandomMapManager.Instance.randomRoom();
            collision.transform.position = connected.transform.position + (dir[direction] * 2f); //다음 방으로 이동

            if (connected.inroom == RandomMapManager.Instance.roomsamples[0])
            {
                if (RandomMapManager.Instance.visited.Count == 12)
                {
                    RandomMapManager.Instance.init();
                    Hero1.Instance.stage++;
                    sp.GetComponent<MonsterMaking>().makeMonster();
                }
            }
        }
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    void Start()
    {
        sp = GameObject.Find("SpawnPoint");
    }
    void Awake()
    {
        Instance = this;
    }
}