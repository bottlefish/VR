using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject UIWater;
    public GameObject UILerp;
    public GameObject SmallTree;
    public GameObject BigTree;
    public GameObject music;
    public GameObject[] musicG;
    public DOTweenAnimation appleA;
    public DOTweenPath appleP;
    public DOTweenAnimation KeyA;
    public DOTweenPath KeyP;
    public DOTweenAnimation lerp;
    public GameObject UI1;
    public GameObject UI2;
    public GameObject UI3;
    //public GameObject lG;
    bool flag = false;
	// Use this for initialization
	void Start () {
        
	}	
	// Update is called once per frame
	void Update () {
		
	}
    public void end()
    {
        UI2.gameObject.SetActive(true);
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
            //lerp.DOPlay();
            SmallTree.gameObject.SetActive(false);
            BigTree.gameObject.SetActive(true);
            appleP.DOPlay();
            appleA.DOPlay();
            //music.gameObject.SetActive(true);
            //foreach(GameObject a in musicG)
            //{
            //    a.gameObject.SetActive(true);
            //}

            //水流第三关
        }
        if (level == 4 && !flag)
        {
            //音乐关卡结束
            flag = true;
            foreach (GameObject a in musicG)
            {
                a.gameObject.SetActive(false);
                music.gameObject.SetActive(false);
            }
            KeyA.DOPlay();
            KeyP.DOPlay();
            //lerp.DOPlay();
            UI1.gameObject.SetActive(true);

        }

    }
}
