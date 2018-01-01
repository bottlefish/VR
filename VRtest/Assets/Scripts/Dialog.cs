using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour {

    int State = 0;
    public GameObject text1;
    public GameObject text2;

	// Use this for initialization
	void Start () {
        text1.SetActive(true);
        text2.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		switch (State){
            case 0:
                break;
            case 1:
                text1.SetActive(false);
                text2.SetActive(true);
                break;
            case 2:
                Destroy(this.gameObject);
                break;
        }
	}
    
    public void AddState()
    {
        State += 1;
    }
    
}
