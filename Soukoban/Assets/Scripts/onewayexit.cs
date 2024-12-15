using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onewayexit : MonoBehaviour
{//Unityメモ、「Componentをスクリプトから操作」～「タグ」参照
    //出口にプレイヤーがいるかどうか
    public bool playerHere = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        //もし接触した物体のタグが"Player"だったら
        if (other.CompareTag("Player"))
        {
<<<<<<< HEAD
=======
            //二択trueまたはfalse
>>>>>>> upstream/main
            playerHere = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        //もし接触状態から離れた物体のタグが"Player"だったら
        if (other.CompareTag("Player"))
        {
<<<<<<< HEAD
=======
            //二択trueまたはfalse
<<<<<<< HEAD
>>>>>>> upstream/main
            playerHere = true;
=======
            playerHere = false;
>>>>>>> upstream/main
        }
    }
}
