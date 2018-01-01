using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rune : MonoBehaviour
{

    public Transform targetPos;
    private CollectLevel level;
    public DOTweenPath ipath;
    public DOTweenAnimation v;
 
    //public Vector3[] pathV;

    /// <summary>
    /// 注意：设置左手标签
    /// 设置 CollectLevel游戏物体 ，玩家player标签的设置
    /// </summary>
    void Awake()
    {
        level = GameObject.Find("CollectLevel").GetComponent<CollectLevel>();
    }

    public void FindRune()
    {

        level.nowHave++;
    }

    public void MoveToTarget()
    {
        //动画变大变小
        //transform.DOMove(targetPos.position, 2);
        ipath.DOPlay();
        transform.DOScale(new Vector3(2, 2, 2), 5);
        v.DOPlay();



        FindRune();
    }

    
}
