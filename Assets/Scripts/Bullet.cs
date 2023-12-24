using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed;
    public GameObject target;

    private void OnTriggerEnter2D(Collider2D other_obj)
    {
        if (other_obj.gameObject.tag == "Player")
        {
            //Debug.Log("ÃÑ¾Ë»èÁ¦");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        speed = 10f;
        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Vector3 v = target.transform.position - transform.position;
        transform.position += v.normalized * speed * Time.deltaTime;
    }
}
