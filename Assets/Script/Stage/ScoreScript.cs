using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text scoreText;
    public static float scoreNum = 0;


    /// <summary>
    /// ���Z�p�X�R�A(scoreNum)���Z�b�g
    /// </summary>
    public void ScoreReset()
    {
        scoreNum = 0;
    }
    /// <summary>
    /// �X�R�A(Text)�擾
    /// </summary>
    public void ScoreSet()
    {
        scoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
    }
    /// <summary>
    /// �X�R�A�����X�V
    /// </summary>
    public void ScoreUpdate()
    {
        scoreText.text = "Score:" + scoreNum;
    }
    /// <summary>
    /// �X�R�A����(float i * 100)
    /// </summary>
    public void ScoreUp(float i)
    {
        scoreNum += i * 100;
    }
    /// <summary>
    /// ���Z�p�X�R�A(scoreNum)�擾
    /// </summary>
    /// <returns>float scoreNum</returns>
    public float GetScoreNum()
    {
        return scoreNum;
    }
}
