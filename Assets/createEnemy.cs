using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    float times = 5f;
    public GameObject m_prefab;
    public GameObject hero;
    float best_time = 0f;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        best_time += Time.deltaTime;

        if(best_time < 30f)
		{
            times -= Time.deltaTime;
            if (times < 0)  //倒计时
            {


                Vector3 Position = new Vector3(Random.Range(260f, 1270f), Random.Range(-30f, 340f), 0);
                GameObject.Instantiate(m_prefab, Position, Quaternion.identity);

                times = 5f;


            }
        }else if(best_time < 60f)
		{
            times -= Time.deltaTime;
            if (times < 0)  //倒计时
            {


                Vector3 Position = new Vector3(Random.Range(260f, 1270f), Random.Range(-30f, 340f), 0);
                GameObject.Instantiate(m_prefab, Position, Quaternion.identity);

                times = 4f;


            }
        }else
		{
            times -= Time.deltaTime;
            if (times < 0)  //倒计时
            {
                Vector3 Position = new Vector3(Random.Range(260f, 1270f), Random.Range(-30f, 340f), 0);
                GameObject.Instantiate(m_prefab, Position, Quaternion.identity);

                times = 2.5f;


            }
        }



        
    }
}
