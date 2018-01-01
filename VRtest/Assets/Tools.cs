using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour {

    public float smooth = 2;//平滑度移动
    public float factor = 1.5f; //上升速率
    Vector3 ControllerOldPos;
    Vector3 ControllerNewPos;
    public bool isTriggerMe = false;
    private GameObject leftController;

    //YJW
    public GameObject targetDoor;

    void Awake()
    {
        leftController = GameObject.FindWithTag("LeftController");
    }

    void Update()
    {
        ControllerNewPos = leftController.transform.position;
        if (ControllerOldPos != null)
        {
            if (isTriggerMe)
            {
                print("123");
                float x = transform.position.x;
                float z = transform.position.z;
                float y = transform.position.y;
                //transform.position = new Vector3(x, y + (ControllerNewPos.y - ControllerOldPos.y) * factor, z);
                transform.position += new Vector3((ControllerNewPos.x - ControllerOldPos.x), (ControllerNewPos.y - ControllerOldPos.y), (ControllerNewPos.z - ControllerOldPos.z))*factor;

            }

            ControllerOldPos = leftController.transform.position;
        }
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.tag == "Door")
        {
            //transform.position = Vector3.Lerp(transform.position, col.transform.position, smooth * Time.deltaTime);
            ////TODO：后续界面操作
            //if (Vector3.Distance(transform.position, col.transform.position) < 0.03f)
            //{
            //    Destroy(gameObject);
            //}
            if(col.name == targetDoor.name)
            {
                col.gameObject.GetComponent<DoorController>().OpenDoorAnim();
                col.gameObject.GetComponent<DoorController>().HeroDoorOpen();
            }
            Destroy(gameObject);

        }
    }


}
