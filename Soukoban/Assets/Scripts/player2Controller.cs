using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Controller : MonoBehaviour
{
    
    private Rigidbody2D rb2d;
    float speed = 5.0f; 
    float estimateTime = 0f;
    bool UpMoving = false;
    bool DownMoving = false;
    bool RightMoving = false;
    bool LeftMoving = false;
    Vector3 targetPosition = Vector3.zero;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {       
        if (Input.GetKey(KeyCode.UpArrow)&&!DownMoving&&!RightMoving&&!LeftMoving)
        {
            UpMoving = true;
            rb2d.velocity = Vector3.up *speed;            
        }
        if (Input.GetKey(KeyCode.DownArrow)&&!UpMoving&&!RightMoving&&!LeftMoving)
        {
            DownMoving = true;
            rb2d.velocity = Vector3.down *speed;            
        }
        if (Input.GetKey(KeyCode.RightArrow)&&!DownMoving&&!UpMoving&&!LeftMoving)
        {
            RightMoving = true;
            rb2d.velocity = Vector3.right *speed;            
        }
        if (Input.GetKey(KeyCode.LeftArrow)&&!DownMoving&&!RightMoving&&!UpMoving)
        {
            LeftMoving = true;
            rb2d.velocity = Vector3.left *speed;            
        }  
        if (Input.GetKeyUp(KeyCode.UpArrow)&&!DownMoving&&!RightMoving&&!LeftMoving)
        {
            StartCoroutine(Up());          
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)&&!UpMoving&&!RightMoving&&!LeftMoving)
        {
            StartCoroutine(Down());        
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)&&!DownMoving&&!UpMoving&&!LeftMoving)
        {
            StartCoroutine(Right());        
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)&&!DownMoving&&!RightMoving&&!UpMoving)
        {
            StartCoroutine(Left());           
        }          
    }
    void FixedUpdate()
    {
        
    }
    private IEnumerator Up()
    {
        while(DownMoving||RightMoving||LeftMoving)
        {
            yield return null;
        }
        float gap = Mathf.Ceil(transform.position.y)-transform.position.y;
        if (gap <= 0.9f)
        {
            targetPosition = new Vector3 (transform.position.x, Mathf.Ceil(transform.position.y), transform.position.z);
            estimateTime = gap/speed;
        }
        else
        {
            targetPosition = new Vector3 (transform.position.x, Mathf.Floor(transform.position.y), transform.position.z);
            estimateTime = 0f;
        }
        
        
        float elapsedTime = 0f;
        while(estimateTime >= elapsedTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        UpMoving = false;
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector3(Mathf.Round(targetPosition.x),Mathf.Round(targetPosition.y),Mathf.Round(targetPosition.z));
    }
    private IEnumerator Down()
    {
        while(UpMoving||RightMoving||LeftMoving)
        {
            yield return null;
        }
        float gap = -Mathf.Floor(transform.position.y)+transform.position.y;
        if (gap <= 0.9f)
        {
            targetPosition = new Vector3 (transform.position.x, Mathf.Floor(transform.position.y), transform.position.z);
            estimateTime = gap/speed;
        }
        else
        {
            targetPosition = new Vector3 (transform.position.x, Mathf.Ceil(transform.position.y), transform.position.z);
            estimateTime = 0f;
        }
        
        float elapsedTime = 0f;
        while(estimateTime >= elapsedTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        DownMoving = false;
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector3(Mathf.Round(targetPosition.x),Mathf.Round(targetPosition.y),Mathf.Round(targetPosition.z));
    }
    private IEnumerator Right()
    {
        while(DownMoving||UpMoving||LeftMoving)
        {
            yield return null;
        }
        float gap = Mathf.Ceil(transform.position.x)-transform.position.x;
        if (gap <= 0.9f)
        {
            targetPosition = new Vector3 (Mathf.Ceil(transform.position.x), transform.position.y, transform.position.z);
            estimateTime = gap/speed;
        }
        else
        {
            targetPosition = new Vector3 (Mathf.Floor(transform.position.x), transform.position.y, transform.position.z);
            estimateTime = 0f;
        }
        
        float elapsedTime = 0f;
        while(estimateTime >= elapsedTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        RightMoving = false;
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector3(Mathf.Round(targetPosition.x),Mathf.Round(targetPosition.y),Mathf.Round(targetPosition.z));
    }
    private IEnumerator Left()
    {
        while(DownMoving||RightMoving||UpMoving)
        {
            yield return null;
        }
        float gap = -Mathf.Floor(transform.position.x)+transform.position.x;
        if (gap <= 0.9f)
        {
            targetPosition = new Vector3 (Mathf.Floor(transform.position.x), transform.position.y, transform.position.z);
            estimateTime = gap/speed;
        }
        else
        {
            targetPosition = new Vector3 (Mathf.Ceil(transform.position.x), transform.position.y, transform.position.z);
            estimateTime = 0f;
        }
        
        float elapsedTime = 0f;
        while(estimateTime >= elapsedTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        LeftMoving = false;
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector3(Mathf.Round(targetPosition.x),Mathf.Round(targetPosition.y),Mathf.Round(targetPosition.z));
    }
}