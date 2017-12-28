using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testInput : MonoBehaviour {
    WaterControl contorl;
    GameObject select;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
        {
            //从摄像机发出到点击坐标的射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.collider.tag=="cube")
                {
                    select = hitInfo.collider.gameObject;
                }
                //划出射线，只有在scene视图中才能看到
                Debug.DrawLine(ray.origin, hitInfo.point);
                GameObject gameObj = hitInfo.collider.gameObject;
                //Debug.Log("click object name is " + gameObj.name);         
            }
        }

        if (select != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //select.gameObject.transform.DOLocalMoveY(-1f, 0.5f);
                Debug.Log("move Up");
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                //select.gameObject.transform.DOLocalMoveY(1f, 0.5f);
                Debug.Log("move Down");
            }
        }
        

    }
}
