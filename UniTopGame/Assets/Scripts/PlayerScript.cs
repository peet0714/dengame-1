using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static int  hp = 3;
    public static string gameState;
    bool inDamage = false;

    public float speed = 3.0f;
    int direction = 0;
    float axisH;
    float axisV;
    public float angleZ = -90.0f;
    Rigidbody2D rbody;
    Animator animator;
    bool isMoving = false;

    float GetAngle (Vector2 p1, Vector2 p2)
    {
        float angle;
        if (axisH != 0 || axisV != 0)
        {
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;
            float rad = Mathf.Atan2(dy, dx);
            angle = rad * Mathf.Rad2Deg;
        }
        else
        {
            angle = angleZ;
        }
        return angle;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameState = "playing";
        hp = PlayerPrefs.GetInt("PlayerHP");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState != "playing"||inDamage)
        {
            return;
        }
        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal");
            axisV = Input.GetAxisRaw("Vertical");
        }
        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x+axisH, fromPt.y+axisV);
        angleZ = GetAngle(fromPt, toPt);
        int dir;
        if (angleZ >= -45 && angleZ <= 45)
        {
            dir = 3;
        }
        else if (angleZ > 45 && angleZ < 135)
        {
            dir = 2;
        }
        else if (angleZ > -135 && angleZ < -45)
        {
            dir = 0;
        }
        else
        {
            dir = 1;
        }
        if (dir != direction)
        {
            direction = dir;
            animator.SetInteger("Direction",direction);
        }
        
    }
    void FixedUpdate()
    {
        if (gameState != "playing")
        {
            return;
        }
        if (inDamage)
        {
            float val = Mathf.Sin(Time.time * 50);
            if (val>0)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            return;
        }
        rbody.velocity = new Vector2(axisH,axisV). normalized*speed;
    }
        
    public void SetAxis(float h, float v)
    {
        axisH=h;
        axisV=v;
        if (axisH == 0 && axisV == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GetDamage(collision.gameObject);
        }
    }   
    void GetDamage(GameObject enemy)
    {
        if (gameState == "playing")
        {
            hp--;
            PlayerPrefs.SetInt("PlayerHP",hp);
            if (hp>0)
            {
                rbody.velocity = new Vector2(0,0);
                Vector3 v = (transform.position - enemy.transform.position).normalized;
                rbody.AddForce(new Vector2(v.x*4,v.y*4), ForceMode2D.Impulse);
                inDamage = true;
                Invoke("DamageEnd", 0.25f);
            }
            else
            {
                GameOver();
            }
        }
    }
    void DamageEnd()
    {
        inDamage = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    void GameOver()
    {
        gameState = "gameover";
        GetComponent<CircleCollider2D>().enabled = false;
        rbody.velocity = new Vector2(0,0);
        rbody.gravityScale = 1;
        rbody.AddForce(new Vector2(0,5),ForceMode2D.Impulse);
        animator.SetBool("isDead", true);
        Destroy(gameObject,1.0f);
        SoundManager.soundManager.StopBgm();
        SoundManager.soundManager.SEPlay(SEType.GameOver);
    }
}
