﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterControl : MonoBehaviour
{

    //public GameObject[] cubes;
    public List<GameObject> cubes = new List<GameObject>();
    private GameObject[] codeCubes;
    public float waterTotalNum = 1.0f;
    public GameObject waterStart;


    private float watersum = 1;
    private float waterNum = 0.0f;
    private float waterHeigh = 0.0f;
    private bool flag1 = true;
    private bool flag2 = true;
    private float lastTime;
    private float curTime;
    private int minC = 100;
    private int maxC = -100;
    private List<GameObject> temp = new List<GameObject>();
    List<int> tempDate = new List<int>();
    private int[,] cubeData = new int[5, 5];
    private int[,] visited = new int[3, 3];
    private int[,] step = new int[2, 4]
    {
    { 1, -1, 0, 0 },
    {0,0,1,-1}
    };

    struct Pos
    {
        public int x;
        public int y;
    };
    void checkceng()
    {
        minC = 100;
        maxC = -100;
        foreach (GameObject cube in cubes)
        {
            minC = Mathf.Min(minC, cube.GetComponent<CubeParent>().nowCount);
            maxC = Mathf.Max(maxC, cube.GetComponent<CubeParent>().nowCount);

        }

        Debug.Log("min" + minC);
        Debug.Log("max" + maxC);
    }
    void UpDateData()
    {
        for (int i = 0; i <= 4; i++)
        {
            cubeData[0, i] = 12;
            cubeData[4, i] = 12;
            cubeData[i, 0] = 12;
            cubeData[i, 4] = 12;
        }
        for (int i = 1; i <= 3; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                cubeData[i, j] = cubes[(i - 1) * 3 + j-1].GetComponent<CubeParent>().nowCount;
            }
        }

    }

    void Clear()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                visited[i, j] = 0;
            }
        }
    }
    void BFS()
    {
        Clear();
        Queue<Pos> Q = new Queue<Pos>();
        Pos start;
        Pos tempN;
        Pos tempNM;
        start.x = 1;
        start.y = 1;
        Q.Enqueue(start);
        visited[start.x - 1, start.y - 1] = -1;
        while (Q.Count != 0)
        {
            tempN = Q.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                tempNM.x = tempN.x + step[0, i];
                tempNM.y = tempN.y + step[1, i];
               // Debug.Log("目标方块" + cubeData[tempNM.x, tempNM.y] + " " + "当前方块" + cubeData[tempN.x, tempN.y] + " " + " 是否访问" + " " + visited[tempNM.x - 1, tempNM.y - 1]);
                if (cubeData[tempNM.x, tempNM.y] <= cubeData[tempN.x, tempN.y] && visited[tempNM.x - 1, tempNM.y - 1] != -1)
                {
                    Q.Enqueue(tempNM);
                    visited[tempNM.x - 1, tempNM.y - 1] = -1;
                    //Debug.Log(tempNM.x + " " + tempNM.y);
                }
            }
        }
        for(int i=1;i<=3;i++)
        {
            for (int j = 1; j <=3; j++)
            {
                if (cubeData[i,j] > cubeData[1,1])
                {
                    visited[i-1, j-1] = -1;
                }
            }
        }
        Debug.Log("第四个层数" + cubeData[2, 1] + "第四个可不可有水流" + visited[1, 0]);
        //foreach (int a in visited)
        //{
        //    Debug.Log(a);
        //}
    }
    void checkDelete()
    {
        tempDate.Clear();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (visited[i, j] != -1)
                {
                    tempDate.Add(i * 3 + j);
                }
            }
        }
    }
    // Use this for initialization
    void Start()
    {
        //Clear();
    }
    void checkCube(int water, int min, int max)
    {
        //用二维数组记录层数
        UpDateData();
        //遍历走一遍
        BFS();
        //看看有哪些点走不到
        checkDelete();
        watersum = waterTotalNum;
        //num记录每一个层级的方块数量  temp存储这些方块
        for (int i = min; i <= max; i++)
        {
            // Debug.Log("当前水量为" + waterTotalNum);
            temp.Clear();
            int num = 0;
            for (int k = 0; k < 9; k++)
            {
                bool flag = false;
                foreach (int a in tempDate)
                {
                    if (k == a)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    continue;
                }
                else
                {
                    if (cubes[k].GetComponent<CubeParent>().nowCount == i)
                    {
                        temp.Add(cubes[k]);
                        num++;
                    }
                }
            }
            //如果还有水就继续填这一层
            if (watersum > 0)
            {
                //Debug.Log("第" + i + "层级的方块数量是" + num);
                //用当前的水来填这一层级，如果能填满留着填更高的层级
                foreach (GameObject watercube in temp)
                {

                  watercube.transform.GetChild(0).GetComponent<Renderer>().material.SetFloat("_Factor", watersum / num);
                        // Debug.Log(child.name + "YES");
                }

                //foreach (Transform child in cubes[3].transform)
                //{
                //    child.GetComponent<Renderer>().material.SetFloat("_Factor", 1);
                //    // Debug.Log(child.name + "YES");
                //}

                Debug.Log("第" + i + "层级的水量为" + watersum / num);
                watersum -= num;
            }
            //如果没有就把这一层全部清空
            else
            {
                if (temp != null)
                    foreach (GameObject watercube in temp)
                    {
                            watercube.transform.GetChild(0).GetComponent<Renderer>().material.SetFloat("_Factor", -0.7f);
                    }
            }
        }

    }



    // Update is called once per frame
    void Update()
    {
        checkceng();
        checkCube(1, minC, maxC);

        //       foreach (GameObject cube in cubes)
        //       {
        //           if (cube.gameObject.transform.position.y <-1)
        //           {
        //               flag2 = true;
        //               if(flag2)
        //               {
        //                   waterNum++;
        //                   flag2 = false;
        //               }   
        //               foreach (Transform child in cube.transform)
        //               {
        //                   //StartCoroutine(changewater(child));
        //                   child.GetComponent<Renderer>().material.SetFloat("_Factor", 1f);

        //                   Debug.Log(child.name + "YES");
        //               }
        //               Debug.Log("water come !");
        //               //cube.GetComponentInChildren<Renderer>().material.SetFloat("_Factor",0.5f);
        //           }
        //           if (cube.gameObject.transform.position.y >0)
        //           {
        //               flag1 = true;
        //               if(flag2)
        //               {
        //                   waterNum--;
        //                   flag2 = !flag2;
        //               }

        //               foreach (Transform child in cube.transform)
        //               {
        //                   child.GetComponent<Renderer>().material.SetFloat("_Factor",-0.6f);

        //               }
        //           }
        //       }

    }
}
