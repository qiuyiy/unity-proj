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
        times -= Time.deltaTime;
        if (times < 0)  //倒计时
        {
            //产生物体


            Vector3 Position = new Vector3(Random.Range(-23f, 23f), Random.Range(-2f, 16f), 0);
            GameObject.Instantiate(m_prefab, Position, Quaternion.identity);
            print(Position);
            //obj.transform.position = Vector3.MoveTowards(obj.transform.position, capsuleObj.transform.position, 1.5f);

            

            //重新设置时间为0-10之间的一个随机数   随机时间
            times = 5f;


        }
    }
}
