using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneway2 : MonoBehaviour
{//Unityメモ、「Componentをスクリプトから操作」～「タグ」参照
    public onewayentry entry;
    public onewayexit exit;
    private BoxCollider2D barrier;
    // Start is called before the first frame update
    void Start()
    {
        barrier = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //もし入口にプレイヤーがいたら
        if (entry.playerHere)
        {
            barrier.enabled = false;
        }
        //もし出口にプレイヤーがいたら
        if (exit.playerHere)
        {
            barrier.enabled = true;
        }
    }
    
}
