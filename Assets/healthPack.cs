using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthPack : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject hero;

    public Slider slide;

    void Start()
    {
        hero = GameObject.Find("heroBody");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, hero.transform.position) < 30)
		{
            slide.value += 6;
            this.transform.position = new Vector3(0, 0, -1000000);


        }
    }
}
