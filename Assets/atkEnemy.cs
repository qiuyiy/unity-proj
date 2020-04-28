using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class atkEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 screenPosition;
    Vector3 mousePositionOnScreen;
    Vector3 mousePositionInWorld;
    private float life = 3f;
    private bool alive = true;
    public GameObject hero;
    public float component = 0f;


    float damage = 2f;

    float atk_time = 1f;
    float hero_life = 10f;
    float best_time = 0f;

    float cd = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
        


        best_time += Time.deltaTime;
		if (best_time > 60f)
		{
            damage = 4f;
		}
        Vector3 objPos = this.transform.localPosition;

        if (Vector3.Distance(hero.transform.position, objPos) > 2)
        {
            transform.position = Vector3.MoveTowards(objPos, hero.transform.position, 0.01f);

        }


        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePositionOnScreen = Input.mousePosition;
        mousePositionOnScreen.z = screenPosition.z;
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
        //print("Obj Pos");
        //print(this.transform.localPosition);

        //print("Mouse Pos");
        //print(mousePositionInWorld);

        cd += Time.deltaTime;
        this.GetComponent<MeshRenderer>().material.color = Color.blue;
        if (life <= 1)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }


        if (cd > 1.5f) { 
            if (Input.GetMouseButtonDown(0))
            {
                if ((Vector3.Distance(mousePositionInWorld, objPos) < 1))
                {
                    
					
					
                    this.GetComponent<MeshRenderer>().material.color = Color.red;
                    
                    
                    life -= 1;
                    print("Attack");
                    cd = 0;
                }
				
            }
            
            
            
        }
        if (life <= 0)
        {
            //Destroy(gameObject);
            gameObject.transform.position = new Vector3(10000000, 10000000, 1000000);
            component += 1;
            
            GameObject.Find("Canvas/Text2").GetComponent<Text>().text = "Component: " + component.ToString();
            //print(component);
            life = 10000f;
        }


        if (Vector3.Distance(this.transform.position, hero.transform.position) < 2)
        {

            atk_time -= Time.deltaTime;
            if (atk_time < 0)
            {
                hero_life -= damage;
                print("you are attacked");
                
                hero.GetComponent<MeshRenderer>().sharedMaterial.color = Color.red;
                
                atk_time = 2f;

            }



        }
        else
        {
            hero.GetComponent<MeshRenderer>().sharedMaterial.color = Color.white;

            
        }
        



        if (hero_life <= 0)
        {
            //Destroy(capsuleObj);
            //Destroy(moveObj);
            print("Game Over");

        }




    }

    

}