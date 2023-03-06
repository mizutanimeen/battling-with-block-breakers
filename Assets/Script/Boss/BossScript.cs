using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float receivDamage = 500;
    private int r;
    private bool oneTime = true;
    private GameObject bossObj;
    public float[] attackPatternChangeHp;
    private bool attackPatternDecision;
    private GameObject[] attackBox;
    private GameObject[][] attackPatternBox;
    public GameObject[] fixedAttack;
    public bool[] repeatedFixedAttack;
    public float[] triggerHpFixedAttac;
    private bool bossTurn;
    public bool bossFixedTurn;
    public GameObject blockObj;

    public Sprite[] appearance;

    void Start()
    {
        bossObj = this.gameObject;
        attackPatternBox = new GameObject[attackPatternChangeHp.Length][];
        for (int i = 0; i < attackPatternChangeHp.Length; i++)
        {
            int j = i + 1;
            attackPatternBox[i] = GameObject.FindGameObjectsWithTag("BossAttack" + j);
        }
        ResetAttackAndWarning();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Ball") return;
        if (oneTime)
        {
            oneTime = false;
            GameObject.FindWithTag("BossHPBar").GetComponent<BossHPScript>().BattleStart();
        }
        else
        {
            GameObject.FindWithTag("BossHPBar").GetComponent<BossHPScript>().ReceivDamage(receivDamage);
        }
        for (int i = 0; i < triggerHpFixedAttac.Length; i++)
        {
            if (triggerHpFixedAttac[i] == GameObject.FindWithTag("BossHPBar").GetComponent<BossHPScript>().hp)
            {
                GenerateFixedWarning(i);
                return;
            }
        }
        GenerateWarning();
    }
    /// <summary>
    /// �U���ƌx���S����\���ɂ���
    /// </summary>
    private void ResetAttackAndWarning()
    {
        for (int a = 0; a < attackPatternBox.Length; a++)
        {
            for (int b = 0; b < attackPatternBox[a].Length; b++)
            {
                attackPatternBox[a][b].SetActive(false);
            }
        }
        for (int a = 0; a < fixedAttack.Length; a++)
        {
            fixedAttack[a].SetActive(false);
        }
    }
    /// <summary>
    /// �ʏ�s���x��
    /// </summary>
    public void GenerateWarning()
    {
        bossTurn = true;
        ResetAttackAndWarning();
        attackPatternDecision = true;
        for (int i = 0; i < attackPatternChangeHp.Length; i++)
        {
            if (attackPatternChangeHp[i] <= GameObject.FindWithTag("BossHPBar").GetComponent<BossHPScript>().hp && attackPatternDecision)
            {
                attackBox = attackPatternBox[i];
                attackPatternDecision = false;
            }
        }
        r = Random.Range(0, attackBox.Length);
        attackBox[r].SetActive(true);
        AttackAndWarningChange(attackBox[r], true);
        BossImageCollisionChange(false);
    }
    /// <summary>
    /// �ʏ�s������
    /// </summary>
    public void GenerateAttack()
    {
        if (bossTurn)
        {
            bossTurn = false;
            AttackAndWarningChange(attackBox[r], false);
            BossImageCollisionChange(true);
        }
    }
    /// <summary>
    /// �Œ�s���x��
    /// </summary>
    public void GenerateFixedWarning(int i)
    {
        bossFixedTurn = true;
        ResetAttackAndWarning();
        fixedAttack[i].SetActive(true);
        AttackAndWarningChange(fixedAttack[i], true);
        BossImageCollisionChange(false);
    }
    /// <summary>
    /// �Œ�s������
    /// </summary>
    public void GenerateFixedAttack(int i)
    {
        if (bossFixedTurn)
        {
            bossFixedTurn = false;
            AttackAndWarningChange(fixedAttack[i], false);
            BossImageCollisionChange(true);
        }
    }
    /// <summary>
    /// �x���A�s���؂�ւ��B�U���p�^�[�������Btrue�Ōx���\���Afalse�ōs��
    /// </summary>
    private void AttackAndWarningChange(GameObject attack, bool warning)
    {
        foreach (Transform childTransform in attack.transform)
        {
            if (childTransform.gameObject.tag == "Notice")
            {
                childTransform.gameObject.SetActive(warning);
            }
            else if (childTransform.gameObject.tag == "Ink")
            {
                childTransform.gameObject.SetActive(false);
            }
            else if (childTransform.gameObject.tag == "BlockPos" && !warning)
            {
                GameObject obj = Instantiate(blockObj, childTransform.gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                childTransform.gameObject.SetActive(!warning);
            }
        }
        if (warning)
        {
            GameObject[] blocks = GameObject.FindGameObjectsWithTag("AttackBlock");
            for (int i = 0; i < blocks.Length; i++)
            {
                Destroy(blocks[i]);
            }
        }
    }
    /// <summary>
    /// �{�X�̌����ځA�����蔻���ON�AOFF�ς���BTrue��ON�AFalse��OFF
    /// </summary>
    private void BossImageCollisionChange(bool i)
    {
        if (i)
        {
            bossObj.GetComponent<Collider2D>().enabled = true;
            bossObj.GetComponent<SpriteRenderer>().sprite = appearance[0];
        } 
        else
        {
            bossObj.GetComponent<Collider2D>().enabled = false;
            bossObj.GetComponent<SpriteRenderer>().sprite = appearance[1];
        }

    }
}
