using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHPScript : MonoBehaviour
{
    public ClearScript clearS;
    public float hp;
    private bool battleStart;
    private Transform bossHP;
    private float hpBarComingSpeed;
    private bool setUpFinish = false;
    private GameObject BossHPUI;
    public GameObject textObj;
    void Start()
    {
        bossHP = GameObject.FindWithTag("BossHPBar").GetComponent<Transform>();
        hp = bossHP.localScale.y;
        bossHP.localScale = new Vector2(bossHP.localScale.x, 0);
        BossHPUI = GameObject.FindWithTag("BossHPUI");
        BossHPUI.SetActive(false);
    }
    void FixedUpdate()
    {
        if (!battleStart) return;
        AppearanceHPBar();
        if (!setUpFinish) return;

        if (hp <= 0)
        {
            Destroy(GameObject.FindWithTag("Boss"));
        }
        ReflectionHp();
    }
    /// <summary>
    /// 演算用変数（hp）を画面に反映
    /// </summary>
    private void ReflectionHp()
    {
        this.GetComponent<Transform>().localScale = new Vector2(bossHP.localScale.x, hp);
    }
    /// <summary>
    /// hpを渡す変数の分だけ減らす
    /// </summary>
    /// <param name="damage"></param>
    public void ReceivDamage(float damage)
    {
       hp -= damage;
       ShowDamage(damage);
    }
    /// <summary>
    /// ボスの受けたダメージを表示
    /// </summary>
    private void ShowDamage(float damage)
    {
        GameObject obj = Instantiate(textObj, Vector3.zero, Quaternion.identity);
        obj.transform.SetParent(GameObject.FindWithTag("Canvas").transform);
        obj.transform.position = new Vector2(GameObject.FindWithTag("Boss").transform.position.x, GameObject.FindWithTag("Boss").transform.position.y);
        obj.GetComponent<ShowDamageScript>().ShowDamage(damage, false);
    }
    ///<summary>
    ///戦闘開始（hpBar出現）
    ///</summary>
    public void BattleStart()
    {
        battleStart = true;
        BossHPUI.SetActive(true);
    }
    /// <summary>
    /// HPBar伸びてくる
    /// </summary>
    private void AppearanceHPBar()
    {
        if (bossHP.localScale.y < hp && !setUpFinish)
        {
            hpBarComingSpeed += 8f;
            bossHP.localScale = new Vector2(bossHP.localScale.x, hpBarComingSpeed);
            return;
        }
        else if (bossHP.localScale.y >= hp && !setUpFinish)
        {
            setUpFinish = true;
            bossHP.localScale = new Vector2(bossHP.localScale.x, hp);
        }
    }
}
