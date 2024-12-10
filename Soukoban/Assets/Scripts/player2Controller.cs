using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Controller : MonoBehaviour
{
    
    private Rigidbody2D rb2d;
    float speed = 5.0f; 
    
    bool UpMoving = false;
    bool DownMoving = false;
    bool RightMoving = false;
    bool LeftMoving = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb2d.velocity = Vector3.up *speed;            
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb2d.velocity = Vector3.down *speed;            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.velocity = Vector3.right *speed;            
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.velocity = Vector3.left *speed;            
        }
         
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            StartCoroutine(Up());
          
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            StartCoroutine(Down());
        
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            StartCoroutine(Right());
        
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StartCoroutine(Left());
           
        }          
    }
    private IEnumerator Up()
    {
        while(DownMoving||RightMoving||LeftMoving)
        {
            yield return null;
        }
        UpMoving = true;
        Vector3 targetPosition = new Vector3 (transform.position.x, Mathf.Ceil(transform.position.y), transform.position.z);
        float gap = Mathf.Ceil(transform.position.y)-transform.position.y;
        float estimateTime = gap/speed;
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
        DownMoving = true;
        Vector3 targetPosition = new Vector3 (transform.position.x, Mathf.Floor(transform.position.y), transform.position.z);
        float gap = -Mathf.Floor(transform.position.y)+transform.position.y;
        float estimateTime = gap/speed;
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
        RightMoving = true;
        Vector3 targetPosition = new Vector3 (Mathf.Ceil(transform.position.x), transform.position.y, transform.position.z);
        float gap = Mathf.Ceil(transform.position.x)-transform.position.x;
        float estimateTime = gap/speed;
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
        LeftMoving = true;
        Vector3 targetPosition = new Vector3 (Mathf.Floor(transform.position.x), transform.position.y, transform.position.z);
        float gap = -Mathf.Floor(transform.position.x)+transform.position.x;
        float estimateTime = gap/speed;
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