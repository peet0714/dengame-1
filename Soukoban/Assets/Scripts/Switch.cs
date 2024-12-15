using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool isPushed = false;
    private bool onButton = false;
    public float OpenTime;
    public SpriteRenderer SwitchRenderer;
    public Sprite SwitchOn;
    public Sprite SwitchOff;
    private Switch switchscript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        isPushed = true;
        onButton = true;
        SwitchRenderer.sprite = SwitchOn;
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        onButton = false;        
        StartCoroutine(SwitchPushed(OpenTime));       
    }
    private IEnumerator SwitchPushed(float time)
    {
        float count = 0f;
        while (count <= time)
        {
            count += Time.deltaTime;
            isPushed = true;
            if (onButton)
            {
                yield break;
            }
            yield return null;
        }
        isPushed = false;
        SwitchRenderer.sprite = SwitchOff;
    }

}
