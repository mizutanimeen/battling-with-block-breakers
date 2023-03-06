using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPScript : MonoBehaviour
{
    private float hp;
    Animator animator;
    private bool oneCall = true;
    public GameObject textObj;
    void Start()
    {
        hp = this.GetComponent<Transform>().localScale.y;
        animator = GameObject.FindWithTag("Ball").GetComponent<Animator>();
    }
    void Update()
    {
        if (hp <= 0 && oneCall)
        {
            oneCall = false;
            GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            animator.SetTrigger("BallDestroy");
        }
        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "None")
        {
            SceneManager.LoadScene("GameOverScene");
        }
        ReflectionHp();
    }
    private void ReflectionHp()
    {
        this.GetComponent<Transform>().localScale = new Vector2(this.GetComponent<Transform>().localScale.x, hp);
    }
    /// <summary>
    /// hp�������������炷
    /// </summary>
    public void CauseDamage(float damage)
    {
        hp -= damage;
        if (damage != 0)
        {
            ShowDamage(damage);
        }
    }
    /// <summary>
    /// �󂯂��_���[�W��\��
    /// </summary>
    private void ShowDamage(float damage)
    {
        GameObject obj = Instantiate(textObj, Vector3.zero, Quaternion.identity);
        obj.transform.SetParent(GameObject.FindWithTag("Canvas").transform);
        obj.transform.position = new Vector2(GameObject.FindWithTag("Ball").transform.position.x, GameObject.FindWithTag("Ball").transform.position.y);
        obj.GetComponent<ShowDamageScript>().ShowDamage(damage, true);
    }

    /// <summary>
    /// ���݂�hp��Ԃ�
    /// </summary>
    /// <returns>float</returns>
    public float GetHpNum()
    {
        return hp;
    }

}

