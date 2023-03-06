using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageareaScript : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            GameObject.FindWithTag("HPBar").GetComponent<HPScript>().CauseDamage(damage);
        }
    }
}
