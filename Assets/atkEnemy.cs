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
    private GameObject hero;
    public GameObject aimIcon;
    //public GameObject hero;
    public float component = 0f;

    public Slider mainSlider;
    public Slider componentSlider;
    public Slider transSlider;
    //public Slider transSlider;

    public Text levelText;
    

    float damage = 2f;


    float your_damage;

    float atk_time = 1f;
    float hero_life = 10f;
    float best_time = 0f;

    public Text endTime;

    float cd = 0f;


    float end = 0f;

    float ability_cd = 0f;


    float atk_speed;
    

    void Start()
    {
        hero = GameObject.Find("heroBody");

        //print(hero.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        levelText.GetComponent<Text>().text = "Level: " + transSlider.value.ToString();

        if (transSlider.value >= 3)
        {
            your_damage = 2f;
        }
		else{
            your_damage = 1f;
        }

        if(transSlider.value >= 2)
		{
            atk_speed = 0.4f;
		}
		else
		{
            atk_speed = 0.8f;

        }


        Vector3 objPos = transform.localPosition;

        /*if (Vector3.Distance(hero.transform.position, objPos) > 25)
        {
            transform.position = Vector3.MoveTowards(objPos, hero.transform.position, 0.5f);

		}*/
		


        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePositionOnScreen = Input.mousePosition;
        mousePositionOnScreen.z = screenPosition.z;
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
        //print("Obj Pos");
        //print(this.transform.localPosition);

        //print("Mouse Pos");
        //print(mousePositionInWorld);

        cd += Time.deltaTime;
        

        
            if (cd > atk_speed)
            {
                if (Input.GetMouseButtonDown(0))
                {
				if ((Vector3.Distance(mousePositionInWorld, hero.transform.position) < 200 + transSlider.value*75))
				{
                    if ((Vector3.Distance(mousePositionInWorld, objPos) < 10))
                    {


                        life -= your_damage;

                        endTime.GetComponent<Text>().text = ("");
                        cd = 0;
                    }
				}
				else
				{
                    endTime.GetComponent<Text>().text = ("Not in attack range!\nPress Z to check range");

                }



			}
			else
			{
                

            }
            



            
            }
        aimIcon.GetComponent<SpriteRenderer>().color = Color.white;

        if (life <= 0)
        {
            //Destroy(gameObject);
            gameObject.transform.position = new Vector3(10000000, 10000000, 1000000);
            //component += 1;
            
            //GameObject.Find("Canvas/Text2").GetComponent<Text>().text = "Component: " + component.ToString();
            //print(component);
            life = 10000f;
            componentSlider.value += 1;


        }
        //print(componentSlider.maxValue);

        if(transSlider.value == 0)
		{
            componentSlider.maxValue = 5;

        }else if(transSlider.value == 1)
		{
            componentSlider.maxValue = 7;

            

            
            //create text (Transformed)
		}
		else if(transSlider.value == 2)
		{
            componentSlider.maxValue = 10;
            
            
        }
		else if(transSlider.value == 3)
		{

            componentSlider.value = componentSlider.maxValue;
        }




        if(componentSlider.value == componentSlider.maxValue && transSlider.value != transSlider.maxValue)
		{
            transSlider.value += 1;
            componentSlider.value = 0;

        }

		


        //endTime.GetComponent<Text>().text = "Time: " + timer.ToString();
            if (Vector3.Distance(this.transform.position, hero.transform.position) < 30)
        {

            atk_time -= Time.deltaTime;
            if (atk_time < 0)
            {
                hero_life -= damage;
                
                print(hero.transform.position);
                mainSlider.value -= 2;

                
                print(mainSlider.value);
                

                //hero.GetComponent<MeshRenderer>().sharedMaterial.color = Color.red;

                atk_time = 2f;

            }



        }
        else
        {
            

            
        }


        



        if (mainSlider.value <= 0)
        {
            //Destroy(capsuleObj);
            //Destroy(moveObj);
            
            Time.timeScale = 0;
            //print(end);
            //endTime.GetComponent<Text>().text = "Your Best Time: " + end.ToString();
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);


        }






    }

    void FixedUpdate()
	{
        Vector3 objPos = transform.localPosition;

        if (Vector3.Distance(hero.transform.position, objPos) > 25)
        {
            transform.position = Vector3.MoveTowards(objPos, hero.transform.position, 0.5f);

        }
    }

    void shield()
	{

	}

    

    

}