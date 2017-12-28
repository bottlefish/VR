using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour {
    private float speed = 10;
	// Use this for initialization
	void Start () {
		
	}
    void OnMouseDrag()
    {
        
        transform.position += Vector3.up * Time.deltaTime * Input.GetAxis("Mouse Y") * speed; ;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
