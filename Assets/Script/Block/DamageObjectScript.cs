using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObjectScript : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            GameObject.FindWithTag("HPBar").GetComponent<HPScript>().CauseDamage(damage);
            if (GameObject.FindWithTag("Boss") != null)
            {
                BossScript bossS = GameObject.FindWithTag("Boss").GetComponent<BossScript>();
                for (int i = 0; i < bossS.triggerHpFixedAttac.Length; i++)
                {
                    if (bossS.triggerHpFixedAttac[i] == GameObject.FindWithTag("BossHPBar").GetComponent<BossHPScript>().hp && bossS.repeatedFixedAttack[i])
                    {
                        bossS.GenerateFixedWarning(i);
                        return;
                    }
                }
                bossS.GenerateWarning();
            }
        }
    }
}
