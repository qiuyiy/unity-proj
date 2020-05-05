using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rayScript : MonoBehaviour
{
    // Start is called before the first frame update

    
    private GameObject clone;
    private LineRenderer line;
    Vector3 screenPosition;
    Vector3 mousePositionOnScreen;
    Vector3 mousePositionInWorld;


    LineRenderer circle;
    Vector3 v;                   //圆心，Vector2是2D,当然也可以换Vector3
    float R;					//半径
    int positionCount;			//完成一个圆的总点数，
    float angle;				//转角，三个点形成的两段线之间的夹角
    Quaternion q;				//Quaternion四元数

    public Slider transSlider;
    


    //带有LineRender物体
    public GameObject target;
    public int layerOrder = 0;
    

    void Start()
    {

        //sliderT = GameObject.Find("Canvas/SliderTrans1");

        //v = new Vector2(722, 10);
        R = 200;
        positionCount = 180;
        angle = 360f / (positionCount - 1);
        circle = GetComponent<LineRenderer>();
        circle.positionCount = positionCount;



    }

    // Update is called once per frame
    void Update()
    {


        R = 200 + 75 * transSlider.value;

        //实例化对象
        v = target.transform.position;
        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePositionOnScreen = Input.mousePosition;
        mousePositionOnScreen.z = screenPosition.z;
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
        //获得该物体上的LineRender组件
        line = target.GetComponent<LineRenderer>();
            //设置起始和结束的颜色
        line.SetColors(Color.red, Color.blue);
            //设置起始和结束的宽度
        line.SetWidth(1f, 1f);
        //计数
        //line.material = new Material(Shader.Find("Particles/Additive"));
        if (Input.GetMouseButton(0)) {
            line.SetColors(Color.green, Color.green);
        }


        if (Vector3.Distance(Camera.main.ScreenToWorldPoint((mousePositionOnScreen)), target.transform.position) < R)
		{
            
            line.SetPosition(0, Camera.main.ScreenToWorldPoint((mousePositionOnScreen)));
            line.SetPosition(1, target.transform.position);
		}
		else
		{

            Vector3 l1 = new Vector3(-10000, -10000, -100000);
            Vector3 l2 = new Vector3(-10001, -10000, -100000);
            line.SetPosition(0, l1);
            line.SetPosition(1, l2);
        }

       

        if (Input.GetKey(KeyCode.Z))
		{
            DrawCircle();
		}
		else{
            hideCircle();

		}

        




    }

    void DrawCircle()
    {
        
        for (int i = 0; i < positionCount; i++)
        {
            if (i != 0)
            {
                q = Quaternion.Euler(q.eulerAngles.x, q.eulerAngles.y, q.eulerAngles.z + angle);
            }
            Vector3 forwardPosition = (Vector3)v + q * Vector3.down * R;
            circle.SetPosition(i, forwardPosition);
        }
    }

    void hideCircle()
	{
        Vector3 hide = new Vector3(0, 0, -100000000);
        for (int i = 0; i < positionCount; i++)
        {
            if (i != 0)
            {
                q = Quaternion.Euler(q.eulerAngles.x, q.eulerAngles.y, q.eulerAngles.z + angle);
            }
            Vector3 forwardPosition = (Vector3)v + q * Vector3.down * R;
            circle.SetPosition(i, hide);
        }
    }




}
