using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject UIWater;
    public GameObject UILerp;
    public GameObject SmallTree;
    public GameObject BigTree;
    public GameObject music;
    public GameObject[] musicG;
    bool flag = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void happened(int level)
    {
        if(level==1)
        {
            //水流第一关结束，到水流第二关
        }
        if(level==2)
        {
            //水流第二关结束，到了水流第三关
        }
        if(level==3)
        {
            //水流第三个结束，到了音乐
            Debug.Log("OKOK");
            UIWater.gameObject.SetActive(false);
            UILerp.gameObject.SetActive(true);
            SmallTree.gameObject.SetActive(false);
            BigTree.gameObject.SetActive(true);

            music.gameObject.SetActive(true);
            foreach(GameObject a in musicG)
            {
                a.gameObject.SetActive(true);
            }
            
            //水流第三关
        }
        if(level==4&&!flag)
        {
            //音乐关卡结束
            flag = true;
            foreach (GameObject a in musicG)
            {
                a.gameObject.SetActive(false);
                music.gameObject.SetActive(false);
            }
        }
            
    }
}
