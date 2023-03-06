using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text scoreText;
    public static float scoreNum = 0;


    /// <summary>
    /// 演算用スコア(scoreNum)リセット
    /// </summary>
    public void ScoreReset()
    {
        scoreNum = 0;
    }
    /// <summary>
    /// スコア(Text)取得
    /// </summary>
    public void ScoreSet()
    {
        scoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
    }
    /// <summary>
    /// スコア随時更新
    /// </summary>
    public void ScoreUpdate()
    {
        scoreText.text = "Score:" + scoreNum;
    }
    /// <summary>
    /// スコア増加(float i * 100)
    /// </summary>
    public void ScoreUp(float i)
    {
        scoreNum += i * 100;
    }
    /// <summary>
    /// 演算用スコア(scoreNum)取得
    /// </summary>
    /// <returns>float scoreNum</returns>
    public float GetScoreNum()
    {
        return scoreNum;
    }
}
