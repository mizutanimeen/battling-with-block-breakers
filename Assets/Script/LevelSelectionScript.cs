using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class LevelSelectionScript : MonoBehaviour
{
    //[1ステージ,2ステージ・・・]
    private bool[,] missionClearChecker;
    //[0ステージ,1ステージ・・・]
    private bool[] clearChecker;
    //演算用変数
    private int a = 1;
    private int b = 0;
    void Start()
    {
        missionClearChecker = GameObject.FindWithTag("GameManager").GetComponent<MissionScript>().GetMissionClearChecker();
        clearChecker = GameObject.FindWithTag("GameManager").GetComponent<MissionScript>().GetClearChecker();
        clearChecker[0] = true;
        foreach (bool i in clearChecker)
        {
            if (clearChecker.Length <= a) return;
            if (!i)
            {
                transform.Find(a + "StageScene").GetComponent<SpriteRenderer>().color = new Color(60f / 255f, 60f / 255f, 60f / 255f);
            } 
            else if (i)
            {
                transform.Find(a + "StageScene").GetComponent<SpriteRenderer>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
                for (int c = 0; c <= 1; c++)
                {
                    if (missionClearChecker[b, c])
                    {
                        transform.Find(a + "StageScene/" + c + "").GetComponent<SpriteRenderer>().color = new Color(255f / 255f, 255f / 255f, 0f / 255f);
                    }
                }
            }
            a++;
            b++;
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            if (!hit) return;
            if(clearChecker[int.Parse(Regex.Replace(hit.collider.gameObject.name, @"[^0-9]", "")) - 1])
            {
                SceneManager.LoadScene(hit.collider.gameObject.name);
                GameManager.instance.SetOneCall();
            }
        }
    }
}
