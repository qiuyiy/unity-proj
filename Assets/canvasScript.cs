using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer = 0f;

    private GameObject buttonObjstop;
    private GameObject buttonObjresume;
    private GameObject buttonObjrestart;

    void Start()
    {
        GameObject buttonObjstop = GameObject.Find("Canvas/stopButton");
        Button btn1 = (Button)buttonObjstop.GetComponent<Button>();
        btn1.onClick.AddListener(stop);

        GameObject buttonObjresume = GameObject.Find("Canvas/resumeButton");
        Button btn2 = (Button)buttonObjresume.GetComponent<Button>();
        btn2.onClick.AddListener(resume);

        GameObject buttonObjrestart = GameObject.Find("Canvas/restartButton");
        Button btn3 = (Button)buttonObjrestart.GetComponent<Button>();
        btn3.onClick.AddListener(restart);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    void stop()
    {
        Time.timeScale = 0;
    
    }

    void resume()
    {
        Time.timeScale = 1;
    }

    void restart()
	{
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }


}
