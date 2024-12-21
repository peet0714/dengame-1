using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackScript : MonoBehaviour
{
    public float breakTime = 0f;
    bool willBreak = false;
    public bool Break = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (willBreak)
        {
            breakTime += Time.deltaTime;
        }
        if (breakTime >= 0.1f)
        {
            Break = true;
            willBreak = false;
            breakTime = 0f;
            
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            willBreak = true;
        }
    }
}
