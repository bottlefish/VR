using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

    public Animator animator;
    public bool keyOne;
    public bool keyTwo;
    public bool keyThree;
    private int nowState = 0;
    //0: 开场
    //1：1门前
    //2：2门前
    //3：3门前
    //4：结束

    void Update() {
        if (Input.GetKey(KeyCode.Alpha1)) {
            animator.SetBool("walking", true);
        }
        else {
            animator.SetBool("walking", false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            animator.SetBool("shouldJump", true);
        }
        else {
            animator.SetBool("shouldJump", false);
        }

    }

    void CheckBool() {
        switch (nowState) {
            case 0:
                //look,start
                
                //ienum
                //nowState +
                break;
            case 1:
                if (keyOne) {
                    //ienum 
                }
                else {
                    //daiji
                }
                break;
            case 2:
                if (keyTwo) {
                    //ienum
                }
                else {
                    //daiji
                }
                break;
            case 3:
                if (keyThree) {
                    //ienum
                }
                else {
                    //daiji
                }
                break;
            case 4:
                //ienum
                break;
        }
    }

    IEnumerator GoToDoorOne() {
        animator.SetBool("walking", true);
        yield return new WaitForFixedUpdate();
    }
}
