using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            //Debug.Log(Monster.Instance.now_hp);
            collision.gameObject.GetComponent<MonsterAI>().knockBack_init();
            collision.gameObject.GetComponent<MonsterAI>().meet = true;
            collision.gameObject.GetComponent<Monster>().now_hp -= Hero1.Instance.attack;
        }
    }
    // Start is called before the first frame update
    void Start()
    {


    }
    void Update()
    {

    }
}