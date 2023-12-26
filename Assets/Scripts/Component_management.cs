using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component_management : MonoBehaviour
{
    public static Component_management Instance;

    void Awake()
    {
        Instance = this;
    }

    public GameObject[] item;

    public GameObject[] monster;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}