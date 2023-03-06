using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDamageScript : MonoBehaviour
{
    float i;
    float c = 255;
    bool colorChange;

    private void FixedUpdate()
    {
        i += 0.0015f;
        c -= 6f;
        this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + i);
        if (colorChange)
        {
            this.gameObject.GetComponent<Text>().color = new Color(255f / 255f, 0 / 255f, 0 / 255f, c / 255f);
        }
        else
        {
            this.gameObject.GetComponent<Text>().color = new Color(0 / 255f, 0 / 255f, 255f / 255f, c / 255f);
        }

        if (c <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void ShowDamage(float damage, bool b)
    {
        colorChange = b;
        this.gameObject.GetComponent<Text>().text = damage.ToString();
    }
}
