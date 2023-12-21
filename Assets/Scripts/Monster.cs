using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public static Monster Instance;
    public GameObject monster;
    float max_hp = 100;
    public float now_hp;
    public float atk_dmg = 5;
    public int vision = 30;
    public int speed = 4;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        now_hp = max_hp;
    }
    // Update is called once per frame
    void Update()
    {
        if(now_hp <= 0)
        {
            if(return_random(Hero1.Instance.luck))
            {
                int item_idx = Random.Range(0, Item_placement.Instance.item.Length);

                Instantiate(Item_placement.Instance.item[item_idx], transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
    bool return_random(float range)
    {
        float random = Random.Range(0, 1f - range);
        float prob = Random.Range(0, 1f);

        Debug.Log(random + " " + prob);

        if (random <= prob && prob < random + range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
