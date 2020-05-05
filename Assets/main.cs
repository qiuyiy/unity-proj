using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject enemy;

    
    float best_time = 0f;
    
    

    private Color TempColor = Color.white;

    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
        best_time += Time.deltaTime;


    }
    
    
}
