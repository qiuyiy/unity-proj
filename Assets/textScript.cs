using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textScript : MonoBehaviour
{
    // Start is called before the first frame update

    

    /// <summary>
    /// 计时器
    /// </summary>
    private float timer = 0f;


    //private float time = 0.8f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        this.GetComponent<Text>().text = "Best Time:\n" + timer.ToString();
    }

    

}
