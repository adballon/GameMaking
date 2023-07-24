using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero1 : MonoBehaviour
{
    public GameObject hero;

    public float attack = 5f;
    public float speed = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            HealthySystem.Instance.TakeDamage(5);
            Debug.Log(HealthySystem.Instance.hitPoint);
        }

        if(HealthySystem.Instance.hitPoint == 0)
        {
            Destroy(hero);
        }
    }

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
