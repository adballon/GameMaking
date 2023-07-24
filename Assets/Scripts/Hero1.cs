using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero1 : MonoBehaviour
{
    public float attack = 5f;
    public float speed = 5f;

    /*float manaPoint = HealthySystem.Instance.manaPoint;
    float maxManaPoint = HealthySystem.Instance.maxManaPoint;

    float hitPoint = HealthySystem.Instance.hitPoint;
    float maxHitPoint = HealthySystem.Instance.maxHitPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            HealthySystem.Instance.TakeDamage(5);
        }

        if(hitPoint == 0)
        {
            Destroy(this);
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(-10, 10, 10);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(10, 10, 10);
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
