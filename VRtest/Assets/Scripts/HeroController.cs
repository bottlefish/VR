using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

    public Animator animator;

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
}
