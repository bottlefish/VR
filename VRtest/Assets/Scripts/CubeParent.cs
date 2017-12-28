using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeParent : MonoBehaviour {
    public int childCount = 3;//有几个子物体
    public int originCount = 0;//默认初始0层
    public  int nowCount = 0; //现在状态
    public Vector3 originPos; //初始位置
    /*
     * 4
     * 3
     * 2
     * 1
     * 0  //默认状态
     * -1 //特殊情况
     * -2 //特殊情况
     * -3 //特殊情况
     * -4 //特殊情况
     */
    [HideInInspector]
    public  List<Cube> cube = new List<Cube>(); 
    public float length = 1; //压缩的scale大小
    public string LayerTag;
    private int privateNowCount = 0; //做转换用

    void Awake() {
        privateNowCount = originCount;
        nowCount = originCount;
        originPos = transform.position;
        transform.position += new Vector3(0, originCount * length, 0);
    }




    public void Update()
    {
        if (nowCount != privateNowCount)
        {
            //震动一下
            privateNowCount = nowCount;

        }

        if (transform.position.y > (originPos.y + childCount * length)){
            
            //震动一下
            transform.position = originPos + new Vector3(0,childCount * length,0);
    
        }
        else if (transform.position.y < (originPos.y))
        {
            //震动一下
            transform.position = originPos;
        }

        foreach (var a in cube)
        {
            if (a.isTriggerMe)
                return;
            if (a.RaycastUp() == 1)
            {
                nowCount = 0;
            }
            //transform.position = originPos + new Vector3(0, (nowCount ) * length, 0);
            
        }
        transform.position = Vector3.Lerp(transform.position,(originPos + new Vector3(0, (nowCount ) * length,0)), 10*Time.deltaTime);
    }
}
