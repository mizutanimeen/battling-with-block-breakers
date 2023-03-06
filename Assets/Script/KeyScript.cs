using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class KeyScript : MonoBehaviour
{
    private GameObject[] keyhole;
    void Start()
    {
        keyhole = GameObject.FindGameObjectsWithTag("Keyhole");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            for (int i = 0; i < keyhole.Length; i++)
            {
                if (Regex.Replace(keyhole[i].name, @"[^0-9]", "") == Regex.Replace(this.gameObject.name, @"[^0-9]", ""))
                {
                    keyhole[i].SetActive(false);
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}
