using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileFloor : MonoBehaviour
{//Unityメモ、「Componentをスクリプトから操作」～「タグ」参照
    //BoxCollider2Dを取得その1
    //private ???? stopper;
    private BoxCollider2D stopper;
    //SpriteRendererを取得
    public SpriteRenderer floorRenderer;
    //壊れた床のSpriteを取得
    public Sprite broken;
    // Start is called before the first frame update
    void Start()
    {
        //BoxCollider2Dを取得その2
        //stopper = ?????;
        stopper = GetComponent<BoxCollider2D>();
    }

    //プレイヤーがすり抜けて出て行った場合に、すり抜けられなくしてかつ画像を壊れた床に変更
    //void ????(???? other)
    void OnTriggerExit2D(Collider2D other)
    {
        //もし出て行ったgameObjectのタグが”Player”だったら
        //if (????????????)
        if (other.gameObject.tag == "Player")
        {
            //BoxCollider2DのisTriggerをfalseにしてすり抜けられないようにする
            //?????
            stopper.isTrigger = false;
            //SpriteRendererのspriteを壊れた床の画像にする。
            //?????
            floorRenderer.sprite = broken;
        }
    }
}
