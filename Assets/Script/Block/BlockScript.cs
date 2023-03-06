using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public ItemScript itemS;
    public ScoreScript scoreS;
    public int requiredTime = 1;
    public int addSpeedCount = 0;
    //衝突した回数カウント用
    private int i = 0;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprite;
    public bool itemCreate;

    void Start()
    {
        spriteRenderer.sprite = sprite[requiredTime - 1];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            //衝突回数カウント
            i += 1;
            if (requiredTime != i)
            {
                spriteRenderer.sprite = sprite[requiredTime - i - 1];
            } else { 
                Destroy(gameObject);
                Vector3 blockPosition = this.gameObject.transform.position;
                if (itemCreate)
                {
                    itemS.CreateItem(blockPosition);
                }
            }
            scoreS.ScoreUp(1);
            collision.gameObject.GetComponent<BallScript>().SpeedUp(addSpeedCount);
        }
    }
}
