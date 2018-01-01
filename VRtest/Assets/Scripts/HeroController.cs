using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HeroController : MonoBehaviour {

    public Animator animator;
    


    public bool doorOneOpen = false;
    public bool doorTwoOpen = false;
    public bool doorThreeOpen = false;
    private int nowState = 0;
    //0: 开场
    //1：1门前
    //2：2门前
    //3：3门前
    //4：结束

    void Start()
    {
        animator.SetBool("walking", false);
    }

    void Update() {

        if(doorOneOpen && doorTwoOpen && doorThreeOpen)
        {
            animator.SetBool("walking", true);
            this.GetComponent<DOTweenPath>().DOPlay();
        }

    }



    public void OpenDoorReaction(int doorID)
    {
        switch (doorID){
            case 1:
                doorOneOpen = true;
                break;
            case 2:
                doorTwoOpen = true;
                break;
            case 3:
                doorThreeOpen = true;
                break;
        }
        print(doorOneOpen);
        print(doorTwoOpen);
        print(doorThreeOpen);
    }

    public void ToNextState()
    {
        nowState += 1;
    }
}
