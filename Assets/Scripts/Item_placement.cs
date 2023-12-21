using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_placement : MonoBehaviour
{
    public static Item_placement Instance;

    void Awake()
    {
        Instance = this;
    }

    public GameObject[] item;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}