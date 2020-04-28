using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3;
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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        DrawLS(gameObject, Input.mousePosition);

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if ((Vector3.Distance(gameObject.transform.position, ob1.transform.position) > 3) || (Vector3.Distance(gameObject.transform.position, ob2.transform.position) > 3))
        {
            Move(h, v);
		}
		else
		{
            float x = (gameObject.transform.position.x - ob1.transform.position.x) / System.Math.Abs(gameObject.transform.position.x - ob1.transform.position.x);
            float y = (gameObject.transform.position.y - ob1.transform.position.y) / System.Math.Abs(gameObject.transform.position.y - ob1.transform.position.y);
            Vector3 r = new Vector3((0.2f*x), (0.2f*y), 0f);
            transform.position = transform.position + r;
        }


        if ((Vector3.Distance(gameObject.transform.position, ob6.transform.position) > 3) || (Vector3.Distance(gameObject.transform.position, ob7.transform.position) > 3))
        {
            Move(h, v);
        }
        else
        {
            
            float x1 = (gameObject.transform.position.x - ob6.transform.position.x) / System.Math.Abs(gameObject.transform.position.x - ob6.transform.position.x);
            float y1 = (gameObject.transform.position.y - ob6.transform.position.y) / System.Math.Abs(gameObject.transform.position.y - ob6.transform.position.y);
            Vector3 r1 = new Vector3((0.2f * x1), (0.2f * y1), 0f);
            transform.position = transform.position + r1;
        }

        
        //TempColor = Color.white;
        //hero.GetComponent<MeshRenderer>().material.color = TempColor;

        


    }
    void Move(float h, float v)
    {
        movement.Set(h, v, 0f);
        movement = movement.normalized * speed * Time.deltaTime;
        //GetComponent<Rigidbody>().MovePosition(movement + transform.position);//当前位置+移动的位置
        gameObject.transform.position = movement + transform.position;//与上一行一样的方法

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
