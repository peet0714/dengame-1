using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour
{
    public BoxCollider2D door;
    private SpriteRenderer doorSprite;
    public Switch switchButton;
    public bool isBlocked = false;
    float time = 1f;
    float waitingTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<BoxCollider2D>();
        doorSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBlocked == false && switchButton.isPushed == false)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0f;
        }
        if (time>=waitingTime)
        {
            door.isTrigger = false;
            doorSprite.enabled = true;
        }
        if (switchButton.isPushed == true)
        {
            door.isTrigger = true;
            doorSprite.enabled = false;            
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {        
        isBlocked = true;        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isBlocked = false;
        
    }
}
