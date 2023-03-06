using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    public float speedX = 10f;
    public float speedY = 10f;
    private Vector2 startSpeed;
    private float addSpeedX = 1f;
    private float addSpeedY = 1f;
    private Vector2 addSpeed;
    private float addSpeedCount;
    private Vector2 startPos;
    private bool ballStart;

    void Start()
    {
        myRigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        startSpeed = new Vector2(speedX, speedY);
        addSpeed = new Vector2(addSpeedX, addSpeedY);
        myRigidBody.velocity = Vector2.zero;
    }
    void Update()
    {
        ballStart = GameManager.instance.ballStart;
        if (Input.GetMouseButtonDown(0) && ballStart)
        {
            startPos = Input.mousePosition;
        } 
        else if (Input.GetMouseButtonUp(0) && ballStart)
        {
            Vector2 endPos = Input.mousePosition;
            Vector2 startDirection = -1 * (endPos - startPos).normalized;
            if ((endPos - startPos).magnitude >= 60f)
            {
                myRigidBody.AddForce(startDirection * startSpeed);
                GameManager.instance.OffBallStart();
            }
        }
        myRigidBody.velocity = myRigidBody.velocity.normalized * (startSpeed + addSpeed * addSpeedCount);
        //y移動がすくない時移動角度を変える
        if (myRigidBody.velocity.y <= 1 && myRigidBody.velocity.y >= -1 && !ballStart)
        {
            PlusVelocity();
        }

        //ボールが3秒動かないなら力を加える
        if ((myRigidBody.velocity.x == 0 || myRigidBody.velocity.y == 0) && !ballStart)
        {
            //Invoke("ReStartBall", 3f);
        }
        GameOver();
    }
    /// <summary>
    ///y移動がすくない時移動角度を変える
    /// </summary>
    private void PlusVelocity()
    {
        float x = myRigidBody.velocity.x;
        float y = myRigidBody.velocity.y;
        if ((x >= 0 && y >= 0) || (x <= 0 && y <= 0))
        {
            myRigidBody.velocity = Quaternion.Euler(0, 0, 0.1f) * myRigidBody.velocity;
        }
        else if ((x <= 0 && y >= 0) || (x >= 0 && y <= 0))
        {
            myRigidBody.velocity = Quaternion.Euler(0, 0, -0.1f) * myRigidBody.velocity;
        }
    }

    /// <summary>
    /// Ballが下に行ったらGameOver
    /// </summary>
    private void GameOver()
    {
        if (myRigidBody.position.y < -5)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverScene");
        }
    }
    /// <summary>
    /// スピードUP
    /// </summary>
    public void SpeedUp(int i)
    {
        if (i == 0) return;
        addSpeedCount += i;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("ColorOff", 1.5f);
    }
    /// <summary>
    /// 色を白に戻す
    /// </summary>
    void ColorOff()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    /// <summary>
    /// 角度調整 ボールのXの大きさを０→angle * 40度にする
    /// </summary>
    public void Rotate(float angle)
    {
        myRigidBody.velocity = new Vector2(0, myRigidBody.velocity.y + 0.01f);
        myRigidBody.velocity = Quaternion.Euler(0, 0, angle * 40) * myRigidBody.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopPrevention(collision);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        StopPrevention(collision);
    }

    /// <summary>
    /// 壁張り付き防止
    /// </summary>
    private void StopPrevention(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("wall_top") && myRigidBody.velocity.y == 0)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, -1);
        }
        if (collision.gameObject.name.Contains("wall_left") && myRigidBody.velocity.x == 0)
        {
            myRigidBody.velocity = new Vector2(1, myRigidBody.velocity.y);
        }
        if (collision.gameObject.name.Contains("wall_right") && myRigidBody.velocity.x == 0)
        {
            myRigidBody.velocity = new Vector2(-1, myRigidBody.velocity.y);
        }
    }
    /// <summary>
    ///　何かしらの原因で完全停止した場合の簡易処置
    /// </summary>
    private void ReStartBall()
    {
        if (myRigidBody.velocity.x == 0 || myRigidBody.velocity.y == 0)
        {
            myRigidBody.velocity = Vector2.zero;
            myRigidBody.AddForce(startSpeed);
        }
    }
}
