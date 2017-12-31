using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    public int num = 0; //cube编号
    private MeshRenderer render;
    public Material highLightMat;
    //public float factor = 1.5f; //上升速率
    Vector3 ControllerOldPos;
    Vector3 ControllerNewPos;
    private Material originMat;
    public bool isTriggerMe = false;
    private GameObject rightController;    
    public CubeParent parent;
    [HideInInspector]
    public Vector3 rayPoint = Vector3.zero; //射线检查点

    void Awake()
    {
        //transform.localScale = Vector3.one;
        rightController = GameObject.FindWithTag("RightController");
        render = GetComponent<MeshRenderer>();
        originMat = render.material;
        parent = GetComponentInParent<CubeParent>();
        parent.cube.Add(this);

        rayPoint = new Vector3(0,-parent.length, 0);
    }


    void Update()
    {      
        ControllerNewPos = rightController.transform.position;
        if (ControllerOldPos != null)
        {
            if (isTriggerMe)
            {
                //if (parent.transform.position.y > parent.originPos.y + parent.originCount * parent.length)
                //    return;
                float x = transform.parent.position.x;
                float z = transform.parent.position.z;
                float y = transform.parent.position.y;
                float scale = 1;
                //transform.parent.position = Vector3.Lerp(transform.parent.position, new Vector3(x, y + (ControllerNewPos.y - ControllerOldPos.y) * factor, z), Time.deltaTime * 40);
                //transform.parent.position = new Vector3(x, y + (ControllerNewPos.y - ControllerOldPos.y) * factor, z);
                if ((ControllerNewPos.y - ControllerOldPos.y) > 0)
                {
                    scale = 1;
                }
                else {
                    scale = -1;
                }
                transform.parent.Translate(transform.up*scale * Time.deltaTime * 0.1f);
            
            }
            else
            {
                RaycastDown();                
            }
        }

        ControllerOldPos = rightController.transform.position;
    }

    public void HighLightToNormal()
    {

        render.material = originMat;
    }

    public void NormalToHighLight()
    {

        render.material = highLightMat;
    }


   public bool RaycastDown() { //向下检测
        Ray ray = new Ray(transform.position ,-transform.up);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 8))
        {
            if (hitInfo.collider.tag == parent.LayerTag)
            {
                parent.nowCount = num;
                //特效
                return true;
            }
       
        }
        return false;

    }

   public int RaycastUp() //向上检测
   {
       Ray ray = new Ray(transform.position  , transform.up);
       RaycastHit hitInfo;
       if (Physics.Raycast(ray, out hitInfo, 8)) //第八层 Ground
       {
           if (hitInfo.collider.tag == parent.LayerTag)
           {
               return num;
           }

       }
       return 0;

   }

}

