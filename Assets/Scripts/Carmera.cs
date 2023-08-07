using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carmera : MonoBehaviour
{
    GameObject RoomPos;
    GameObject Hero;
    // Start is called before the first frame update
    void Start()
    {
        RoomPos = GameObject.Find("");
        Hero = GameObject.Find("hero");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Hero.GetComponent<Hero1>().transform.position;
    }
}
