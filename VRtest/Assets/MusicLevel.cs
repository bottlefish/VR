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
    public LevelManager LM;
    public GameObject[] musicLogo;


 


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
            LM.happened(4);
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
        //else
        //{
        //    LM.happened(4);
        //}


    }



    public void Startsound()
    {

        StartCoroutine("PlaySound");
    }

    IEnumerator PlaySound()
    {
        for (int i = 0; i < sound.Length; i++)
        {
            
            yield return new WaitForSeconds(1);
            musicLogo[i].SetActive(true);
            AudioSource.PlayClipAtPoint(sound[i], transforms[i].position);
            // TODO : dotween动画 播放音符
            yield return new WaitForSeconds(0.5f);
            musicLogo[i].SetActive(false);
        }

    }


}
