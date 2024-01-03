using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Monster : MonoBehaviour
{
    public static Monster Instance;
    public GameObject monster;
    public float max_hp = 100;
    public float now_hp;
    public float atk_dmg = 5;
    public int vision = 30;
    public int speed = 4;

    Vector3 []pos = new Vector3[4];

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        now_hp = max_hp;

        pos[0] = Vector3.up;
        pos[1] = Vector3.down;
        pos[2] = Vector3.left;
        pos[3] = Vector3.right;
    }
    // Update is called once per frame
    void Update()
    {
        if (now_hp <= 0)
        {
            if (return_random(Hero1.Instance.luck))
            {
                int item_idx = Random.Range(1, Component_management.Instance.item.Length);

                Instantiate(Component_management.Instance.item[item_idx], transform.position + pos[Random.Range(0, 4)], Quaternion.identity);
            }
            
            GameObject a = Instantiate(Component_management.Instance.item[0], transform.position, Quaternion.identity);
            a.GetComponent<Coin>().setValue((int)max_hp / 10);            
            Destroy(gameObject);
        }
    }
    bool return_random(float range)
    {
        float random = Random.Range(0, 1f - range);
        float prob = Random.Range(0, 1f);

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