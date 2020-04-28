using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hero;
    public GameObject enemy;
    

    float best_time = 0f;
    float speed = 0.01f;

    private Color TempColor = Color.white;

    void Start()
    {
        print("Start Game");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(best_time > 60f)
		{
            speed = 0.02f;
		}
        best_time += Time.deltaTime;

        if (Vector3.Distance(hero.transform.position, enemy.transform.position) > 2)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, hero.transform.position, 0.01f);

        }

        

        
    }
}
