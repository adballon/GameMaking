using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Attack : MonoBehaviour
{
    SpriteRenderer name1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.tag == "Monster")
        //{
        //    MonsterAI.Instance.knockBack_init();
        //    Monster.Instance.now_hp -= Hero1.Instance.attack;
        //    Debug.Log(Monster.Instance.now_hp);
        //}
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    void Update()
    {
        
    }
}
