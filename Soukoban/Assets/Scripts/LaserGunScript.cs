using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunScript : MonoBehaviour
{
    public bool isRight = false;
    public bool isLeft = false;
    public bool isUp = false;
    public bool isDown = false;
    public float interval = 3.0f;
    private float elapsedTime = 1.0f;
    public GameObject laserRight;
    public GameObject laserLeft;
    public GameObject laserUp;
    public GameObject laserDown;
    public GameManager gameManager;
    Vector3 launchPosition;
    private Rigidbody2D rb2d;
    float Movedistance = 1.0f;
    float Moveduration = 0.2f;
    float Movechecktime = 0.15f;
    float InputStay = 1.0f;
    float speed = 5.0f;
    float merge = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;          
        if (elapsedTime > interval)
        {
            elapsedTime = 0f;
            if (isRight)
            {
                Instantiate (laserRight, transform.position, Quaternion.identity);
            }
            else if (isLeft)
            {
                Instantiate (laserLeft, transform.position, Quaternion.identity);
            }
            else if (isUp)
            {
                Instantiate (laserUp, transform.position, Quaternion.identity);
            }
            else if (isDown)
            {
                Instantiate (laserDown, transform.position, Quaternion.identity);
            } 
        }  
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 Distance = transform.position - player.transform.position;
        Vector3 up = Distance - Vector3.up;
        Vector3 down = Distance - Vector3.down;
        Vector3 left = Distance - Vector3.left;
        Vector3 right = Distance - Vector3.right;
        InputStay += Time.deltaTime;
        if (Distance.magnitude < 1.01f)
        {
            rb2d.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
            rb2d.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        }
        else
        {
            rb2d.constraints |= RigidbodyConstraints2D.FreezePositionX;
            rb2d.constraints |= RigidbodyConstraints2D.FreezePositionY;
        }
        if (InputStay > Moveduration && gameManager.isClear == false)
        {
            if (up.magnitude < merge && Input.GetKeyDown(KeyCode.UpArrow))
            {
                StartCoroutine(Move(Vector3.up));
                InputStay = 0f;
            }
            if (down.magnitude < merge && Input.GetKeyDown(KeyCode.DownArrow))
            {
                StartCoroutine(Move(Vector3.down));
                InputStay = 0f;
            }
            if (right.magnitude < merge && Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine(Move(Vector3.right));
                InputStay = 0f;
            }
            if (left.magnitude < merge && Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine(Move(Vector3.left));
                InputStay = 0f;
            }
        }          
    }

    private IEnumerator Move(Vector3 direction)
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + direction * Movedistance;
        float elapsedTime = 0f;
        rb2d.velocity = direction*speed;
        while (elapsedTime < Moveduration)
        {
            
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= Movechecktime)
            {
                Vector3 location = transform.position - startPosition;
                if (location.magnitude >= 0.5f)
                {
                    rb2d.velocity = direction*speed;
                }
                else
                {
                    transform.position = new Vector3(Mathf.Round(startPosition.x),Mathf.Round(startPosition.y),transform.position.z);
                    rb2d.velocity = new Vector3 (0,0,0);
                    yield break;
                }
            }
            yield return null;            
        }
        rb2d.velocity = new Vector3 (0,0,0);
        transform.position = new Vector3(Mathf.Round(targetPosition.x),Mathf.Round(targetPosition.y),transform.position.z);      
    }    
}
