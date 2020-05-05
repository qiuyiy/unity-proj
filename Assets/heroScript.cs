using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heroScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 30f;
    Vector3 movement;
    public GameObject enemy;

    
    public static float lifetime = 0;
    public GameObject ob1;
    public GameObject ob2;
    public GameObject ob3;
    public GameObject ob4;
    public GameObject ob5;
    public GameObject ob6;
    public GameObject ob7;

    public GameObject pack;

    public Slider trans;

    public Sprite spriteA;
    public Sprite spriteB;
    public Sprite spriteC;


    void Start()
    {
        //Tex = Resources.Load("bird2") as Texture2D;
        //spriteA = Sprite.Create(Tex, new Rect(171, 0, 171, 95), new Vector2(transform.position.x, transform.position.x));

    }

    // Update is called once per frame
    void Update()
    {

        if(trans.GetComponent<Slider>().value >= 1)
		{
            speed = 65f;
		}


        if (trans.GetComponent<Slider>().value == 1)
        {
            //spriteA = Sprite.Create(Tex, new Rect(329, 239+40, 126, 126+40), new Vector2(0.5f, 0.5f));

            gameObject.GetComponent<SpriteRenderer>().sprite = spriteC;
        }

        if (trans.GetComponent<Slider>().value == 3)
        {
            //spriteA = Sprite.Create(Tex, new Rect(329, 239+40, 126, 126+40), new Vector2(0.5f, 0.5f));

            gameObject.GetComponent<SpriteRenderer>().sprite = spriteB;
        }


        if (trans.GetComponent<Slider>().value == 2)
        {
            //spriteA = Sprite.Create(Tex, new Rect(329, 239+40, 126, 126+40), new Vector2(0.5f, 0.5f));

            gameObject.GetComponent<SpriteRenderer>().sprite = spriteA;
        }

        if (trans.GetComponent<Slider>().value == 3)
        {
            //spriteA = Sprite.Create(Tex, new Rect(329, 239+40, 126, 126+40), new Vector2(0.5f, 0.5f));

            gameObject.GetComponent<SpriteRenderer>().sprite = spriteB;
        }




        //DrawLS(gameObject, Input.mousePosition);

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if(gameObject.transform.position.x < 210)
		{
            Vector3 right = new Vector3(1, 0, 0);
            transform.position = transform.position + right;

        }

        if (gameObject.transform.position.x > 1272)
        {
            Vector3 left = new Vector3(-1, 0, 0);
            transform.position = transform.position + left;

        }

        if (gameObject.transform.position.y < 0)
        {
            Vector3 up = new Vector3(0, 1, 0);
            transform.position = transform.position + up;

        }

        if (gameObject.transform.position.y > 305)
        {
            Vector3 down = new Vector3(0, -1, 0);
            transform.position = transform.position + down;

        }


        if ((Vector3.Distance(gameObject.transform.position, ob1.transform.position) < 35))
        {
            float x = (gameObject.transform.position.x - ob1.transform.position.x) / System.Math.Abs(gameObject.transform.position.x - ob1.transform.position.x);
            float y = (gameObject.transform.position.y - ob1.transform.position.y) / System.Math.Abs(gameObject.transform.position.y - ob1.transform.position.y);
            Vector3 r = new Vector3((0.2f * x), (0.2f * y), 0f);
            gameObject.transform.position = gameObject.transform.position + r;
        }
		


        else if ((Vector3.Distance(gameObject.transform.position, ob2.transform.position) < 35))
        {
            float x = (gameObject.transform.position.x - ob2.transform.position.x) / System.Math.Abs(gameObject.transform.position.x - ob2.transform.position.x);
            float y = (gameObject.transform.position.y - ob2.transform.position.y) / System.Math.Abs(gameObject.transform.position.y - ob2.transform.position.y);
            Vector3 r = new Vector3((0.2f * x), (0.2f * y), 0f);
            gameObject.transform.position = gameObject.transform.position + r;
        }
        


        else if ((Vector3.Distance(gameObject.transform.position, ob3.transform.position) < 35))
        {
            float x = (gameObject.transform.position.x - ob3.transform.position.x) / System.Math.Abs(gameObject.transform.position.x - ob3.transform.position.x);
            float y = (gameObject.transform.position.y - ob3.transform.position.y) / System.Math.Abs(gameObject.transform.position.y - ob3.transform.position.y);
            Vector3 r = new Vector3((0.2f * x), (0.2f * y), 0f);
            gameObject.transform.position = gameObject.transform.position + r;
        }
        


        else if ((Vector3.Distance(gameObject.transform.position, ob3.transform.position) < 35))
        {

            float x = (gameObject.transform.position.x - ob4.transform.position.x) / System.Math.Abs(gameObject.transform.position.x - ob4.transform.position.x);
            float y = (gameObject.transform.position.y - ob4.transform.position.y) / System.Math.Abs(gameObject.transform.position.y - ob4.transform.position.y);
            Vector3 r = new Vector3((0.2f * x), (0.2f * y), 0f);
            gameObject.transform.position = gameObject.transform.position + r;
		}
		else
		{
            Move(h, v);
		}
        


    }
    void Move(float h, float v)
    {
        movement.Set(h, v, 0f);
        movement = movement * speed * Time.deltaTime;
        //GetComponent<Rigidbody>().MovePosition(movement + transform.position);//当前位置+移动的位置
        gameObject.transform.position = movement + gameObject.transform.position;//与上一行一样的方法

    }

    bool canMove(float x, float y, float obstacle_x, float obstacle_y)
    {
        if (System.Math.Abs(x - obstacle_x) < 1.7 && System.Math.Abs(y - obstacle_y) < 1.7)
        {
            Vector3 r = new Vector3(-0.5f, -0.5f, 0f);
            transform.position = transform.position + r;
            return (false);

        }
        return (true);
    }

    
    void DrawLS(GameObject startP, Vector3 v)
    {
        Vector3 rightPosition = (startP.transform.position + v) / 2;
        Vector3 rightRotation = v - startP.transform.position;
        float HalfLength = Vector3.Distance(startP.transform.position, v) / 2;
        float LThickness = 0.1f;//线的粗细

        //创建圆柱体
        GameObject MyLine = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        MyLine.gameObject.transform.parent = transform;
        MyLine.transform.position = rightPosition;
        MyLine.transform.rotation = Quaternion.FromToRotation(Vector3.up, rightRotation);
        //MyLine.transform.localScale = new Vector3(LThickness, HalfLength, LThickness);

        //这里可以设置材质，具体自己设置
        //MyLine.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
    }



}
