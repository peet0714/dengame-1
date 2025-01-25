using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnewayboardScript : MonoBehaviour
{
    public bool isRight;
    public bool isLeft;
    public bool isUp;
    public bool isDown;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        if (isRight)
        {
            gameObject.tag = "OnewayRight";
        }
        else if (isLeft)
        {
            gameObject.tag = "OnewayLeft";
        }
        else if (isUp)
        {
            gameObject.tag = "OnewayUp";
        }
        else if (isDown)
        {
            gameObject.tag = "OnewayDown";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
