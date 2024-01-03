using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    public GameObject title;
    public GameObject method;

    public Button start;
    public Button howto;
    public Button back;
    public string next_scene;

    void gamestart()
    {
        SceneManager.LoadScene(next_scene);
    }

    void howtotplay()
    {
        title.SetActive(false);
        method.SetActive(true);
    }

    void title_back()
    {
        title.SetActive(true);
        method.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        title_back();

        start.onClick.AddListener(gamestart);
        howto.onClick.AddListener(howtotplay);
        back.onClick.AddListener(title_back);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
