using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float playerSpeed = 10;
    private Vector2 targetPos;
    private GameObject leftWall;
    private GameObject rightWall;
    //�{�^�����͒���true
    private bool move;
    private GameObject playerbody;
    private GameObject ballobj;

    private BossScript bossS;
    void Start()
    {
        playerbody = GameObject.FindWithTag("Player");
        leftWall = GameObject.FindWithTag("WallLeft");
        rightWall = GameObject.FindWithTag("WallRight");
        ballobj = GameObject.FindWithTag("Ball");
        if (GameObject.FindWithTag("Boss") != null)
        {
            bossS = GameObject.FindWithTag("Boss").GetComponent<BossScript>();
        }
    }

    void FixedUpdate()
    {
        //�{�[�����X�^�[�g���ĂȂ��Ȃ�I��
        if (GameManager.instance.ballStart)
        {
            return;
        }

        //�}�E�X�p
        if (Input.GetMouseButton(0))
        {
            targetPos = Input.mousePosition;
            targetPos = Camera.main.ScreenToWorldPoint(targetPos);
            //�ړ��ꏊ�̐���
            targetPos = new Vector2(
                            Mathf.Clamp(
                                //�}�E�X�̒l
                                targetPos.x * 1.3f,
                                //�ő�
                                leftWall.transform.position.x - playerbody.GetComponent<Transform>().localScale.x / 7,
                                //�ŏ�
                                rightWall.transform.position.x + playerbody.GetComponent<Transform>().localScale.x / 7),
                            transform.position.y
                        );
            move = true;
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            move = false;
        }
        //�N���b�N���������s
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position,targetPos,playerSpeed);
        }
    }
    //�{�[���̒��˕Ԃ��������
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                float point = playerbody.GetComponent<Transform>().position.x - contact.point.x;
                var rate = point / (playerbody.GetComponent<Transform>().localScale.x * .5f);
                ballobj.GetComponent<BallScript>().Rotate(rate);
            }
            if (bossS != null)
            {
                bool bossFixedTurn = bossS.bossFixedTurn;
                float[] triggerHp = bossS.triggerHpFixedAttac;
                for (int i = 0; i < triggerHp.Length; i++)
                {
                    if (triggerHp[i] == GameObject.FindWithTag("BossHPBar").GetComponent<BossHPScript>().hp && bossFixedTurn)
                    {
                        bossS.GenerateFixedAttack(i);
                        return;
                    }
                }
                bossS.GenerateAttack();
            }
        }
    }
}
