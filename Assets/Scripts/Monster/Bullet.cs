using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed, atk;
    public GameObject target;

    private void OnTriggerEnter2D(Collider2D other_obj)
    {
        if (other_obj.gameObject.tag == "Player")
        {
            Hero1.Instance.TakeDamage(atk);
            Destroy(gameObject);
        }
    }
    void Start()
    {
        speed = 10f;
        atk = 5f;
        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Vector3 v = target.transform.position - transform.position;
        transform.position += v.normalized * speed * Time.deltaTime;
    }
}
