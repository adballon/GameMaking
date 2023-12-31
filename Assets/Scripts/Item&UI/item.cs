using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public static item Instance;
    public item it;

    public float attack_up = 0; //공격력 증가
    public float mana_up = 0; //마나 증가
    public float hit_up = 0; //체력 증가
    public float defense_up = 0; //방어력 증가
    public float speed_up = 0; //속도 증가
    public float luck_up = 0; //운 증가

    void Awake()
    {
        Instance = this;
    }

    void eat()
    {
        Hero1.Instance.attack += attack_up;
        Hero1.Instance.defend += defense_up;
        Hero1.Instance.speed += speed_up;

        if (Hero1.Instance.hitPoint < Hero1.Instance.maxhitPoint)
        {
            Hero1.Instance.hitPoint += hit_up;

            if (Hero1.Instance.hitPoint >= Hero1.Instance.maxhitPoint)
            {
                Hero1.Instance.hitPoint = Hero1.Instance.maxhitPoint;
            }
        }

        if (Hero1.Instance.manaPoint < Hero1.Instance.maxManaPoint)
        {

            Hero1.Instance.manaPoint += Hero1.Instance.maxManaPoint;

            if(Hero1.Instance.manaPoint >= Hero1.Instance.maxManaPoint)
            {
                Hero1.Instance.manaPoint = Hero1.Instance.maxManaPoint;
            }
        }
        Destroy(gameObject);
    }

    void item_config()
    {
        if (attack_up > 0)
        {
            Interface.Instance.item_cnt[0]++;
        }
        if (mana_up > 0)
        {
            Interface.Instance.item_cnt[1]++;
        }
        if (hit_up > 0)
        {
            Interface.Instance.item_cnt[2]++;
        }
        if (defense_up > 0)
        {
            Interface.Instance.item_cnt[3]++;
        }
        if (speed_up > 0)
        {
            Interface.Instance.item_cnt[4]++;
        }
        if (luck_up > 0)
        {
            Interface.Instance.item_cnt[5]++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            eat();
            item_config();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}