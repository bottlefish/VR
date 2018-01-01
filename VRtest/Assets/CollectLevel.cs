using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLevel : MonoBehaviour
{

    private bool isWin = false;
    public int nowHave = 0;
    public GameObject runeTotal;

    void Update() {

        if (!isWin) {
            if (nowHave == 3) {
                isWin = true;
                print("Bingo!");
                runeTotal.SetActive(true);
                Rune[] runes = GameObject.FindObjectsOfType<Rune>();
                foreach (var a in runes) {
                    Destroy(a.gameObject);
                }
                //后续,小人移动
                //屏幕闪光
            }
        }
    }
}
