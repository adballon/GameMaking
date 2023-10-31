using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Attack : MonoBehaviour
{
    SpriteRenderer name1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            Monster.Instance.nowhp -= Hero1.Instance.attack;
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
