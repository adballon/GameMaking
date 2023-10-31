using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    GameObject player;
    public static Monster Instance;

    float player_atk;

    string enemyname;
    float maxhp;
    public float nowhp;
    int atkdmg;
    int atkspeed;
    int atkrange;
    public int speed = 1;
    public float fieldOfVision;

    void Awake()
    {
        Instance = this;
    }

    private void SetEnemyStatus(string t_enemyname, float t_maxhp, int t_atkdmg, int t_atkspeed, int t_atkrange, float t_fieldOfVision)
    {
        enemyname = t_enemyname;
        maxhp = t_maxhp;
        nowhp = maxhp;
        atkdmg = t_atkdmg;
        atkspeed = t_atkspeed;
        atkrange = t_atkrange;
        fieldOfVision = t_fieldOfVision;
    }

    void hp_ctr()
    {
        if(nowhp <= 0)
        {
            //Debug.Log("»èÁ¦");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetEnemyStatus("monster1", 30f, 10, 1, 5, 7f);
        player = GameObject.Find("hero");
    }

    // Update is called once per frame
    void Update()
    {
        player_atk = player.GetComponent<Hero1>().attack;
        hp_ctr();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            nowhp -= player_atk;
            //Debug.Log(nowhp);
        }
    }
}
