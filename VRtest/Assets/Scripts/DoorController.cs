using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour {

    public GameObject childTips;
    public GameObject hero;
    public int doorID;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenDoorAnim()
    {
        childTips.SetActive(false);
        this.GetComponentInChildren<DOTweenAnimation>().DOPlay();
        
    }

    public void HeroDoorOpen()
    {
        hero.GetComponent<HeroController>().OpenDoorReaction(doorID);
    }
}
