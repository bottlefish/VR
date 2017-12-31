using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLevel : MonoBehaviour
{

    private int[] number = { 1, 2, 3, 4 }; //谜题答案
    public AudioClip[] sound;
    public Transform[] transforms; //小鸟位置
    public List<CubeParent> parent = new List<CubeParent>();
    private bool isWin = false;

    void Start()
    {
        StartPlaySound();
    }


    void Update()
    {
        if (!isWin)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (parent[i].nowCount != number[i])
                {
                    return; ;
                }
            }
            print("get");
            isWin = true;
            CancelInvoke("Startsound");
            foreach (var a in parent)
            {
                a.isSelfMove = false;
                foreach (var b in a.cube)
                {
                    b.enabled = false;
                }
            }
        }


    }

    public void StartPlaySound()
    {

        InvokeRepeating("Startsound", 0, 10);

    }

    void Startsound()
    {

        StartCoroutine("PlaySound");

    }

    IEnumerator PlaySound()
    {
        for (int i = 0; i < sound.Length; i++)
        {
            yield return new WaitForSeconds(1);
            AudioSource.PlayClipAtPoint(sound[i], transforms[i].position);
            // TODO : dotween动画 播放音符
        }

    }


}
