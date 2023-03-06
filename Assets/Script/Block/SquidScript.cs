using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class SquidScript : MonoBehaviour
{
    private GameObject[] ink;
    private void Awake()
    {
        ink = GameObject.FindGameObjectsWithTag("Ink");
        for (int i = 0; i < ink.Length; i++)
        {
            ink[i].SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            this.gameObject.SetActive(false);
            for (int i = 0; i < ink.Length; i++)
            {
                if (Regex.Replace(ink[i].name, @"[^0-9]", "") == Regex.Replace(this.gameObject.name, @"[^0-9]", ""))
                {
                    ink[i].SetActive(true);
                }
            }
        }
    }
}
