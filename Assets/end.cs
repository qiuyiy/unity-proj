using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class end : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject btnStart;

    void Start()
    {
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
        Time.timeScale = 1;

    }
}
