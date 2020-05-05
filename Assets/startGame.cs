using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startGame : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject btnStart;

    
    void Start()
    {
        GameObject btnStart = GameObject.Find("Canvas/Button");
        Button btn = (Button)btnStart.GetComponent<Button>();
        btn.onClick.AddListener(start);

    }

    // Update is called once per frame
    void Update()
    {


    }

    void start()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);

    }


}
