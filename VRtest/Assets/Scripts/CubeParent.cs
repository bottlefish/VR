using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeParent : MonoBehaviour {
    public int childCount = 3;//有几个子物体
    public int originCount = 0;//默认初始0层
    public  int nowCount = 0; //现在状态
    private Vector3 originPos; //初始位置
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
    public float length = 1; //默认高度大小

    void Awake() {
        originPos = transform.position;
        transform.position = originPos + new Vector3(0,originCount * length);
    }

    public void Update()
    {
 
        foreach (var a in cube) {
            if (a.isTriggerMe) 
                return;
            if (a.RaycastUp() == 1) {
                nowCount = 0;
            }
        }
        transform.position = originPos + new Vector3(0, nowCount * length,0);
    }
}
