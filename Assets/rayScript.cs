using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject clone;
    private LineRenderer line;
    Vector3 screenPosition;
    Vector3 mousePositionOnScreen;
    Vector3 mousePositionInWorld;
    
    //带有LineRender物体
    public GameObject target;
    public int layerOrder = 0;
    void Start()
    {
        line.positionCount = (2);
        
    }

    // Update is called once per frame
    void Update()
    {

        //实例化对象

        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePositionOnScreen = Input.mousePosition;
        mousePositionOnScreen.z = screenPosition.z;
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
        //获得该物体上的LineRender组件
        line = target.GetComponent<LineRenderer>();
            //设置起始和结束的颜色
        line.SetColors(Color.red, Color.blue);
            //设置起始和结束的宽度
        line.SetWidth(0.1f, 0.1f);
        //计数
        //line.material = new Material(Shader.Find("Particles/Additive"));
        if (Input.GetMouseButtonDown(0)) {
            line.SetColors(Color.green, Color.green);
        }
        line.SetPosition(0, Camera.main.ScreenToWorldPoint((mousePositionOnScreen)));
        line.SetPosition(1, target.transform.position);
        
        
    }
}
