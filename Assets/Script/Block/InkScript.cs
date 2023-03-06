using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkScript : MonoBehaviour
{
    private bool fadeout;
    private float transparency = 750;
    //Fixed0.02•b‚Éˆê‰ñ
    void FixedUpdate()
    {
        transparency -= 3f;
        if (transparency <= 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            transparency = 255;
            this.gameObject.SetActive(false);
        }
        if (fadeout && transparency <= 255)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, transparency / 255f);
        }
    }
    private void OnEnable()
    {
        fadeout = true;
    }
    private void OnDisable()
    {
        fadeout = false;
        transparency = 750;
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }
}
