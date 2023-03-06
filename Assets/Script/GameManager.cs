using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    #region 変数
    public static GameManager instance;
    private bool oneCall = true;
    public bool ballStart = true;
    private GameObject[] tagBlock;
    private GameObject[] tagBoss;
    public ScoreScript scoreS;
    public TimeScript timeS;
    public StageNumberScript stageNumberS;
    public ClearScript clearS;
    public float hpNum;
    #endregion

    #region GameManager初期設定
    private void Awake()
    {
        //GameManager唯一無二
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    void Update()
    {
        if (SceneManager.GetActiveScene().name.Contains("Stage"))
        {
            if (oneCall)
            {
                oneCall = false;
                ballStart = true;
                timeS.SetTimeText();
                scoreS.ScoreSet();
                timeS.TimeReset();
                scoreS.ScoreReset();
                stageNumberS.SetStageNumber();
            }
            scoreS.ScoreUpdate();
            timeS.TimeUpdate(ballStart);
            CheckClear();
        }
    }
    /// <summary>
    /// 一回だけ実行ON(StageScene)
    /// </summary>
    public void SetOneCall()
    {
        oneCall = true;
    }
    /// <summary>
    /// ボールはもうスタートしたとする
    /// </summary>
    public void OffBallStart()
    {
        ballStart = false;
    }
    /// <summary>
    /// Clear判定（ブロック全破壊時）
    /// </summary>
    private void CheckClear()
    {
        tagBlock = GameObject.FindGameObjectsWithTag("Block");
        tagBoss = GameObject.FindGameObjectsWithTag("Boss");
        if (tagBlock.Length <= 0 && tagBoss.Length <= 0)
        {
            hpNum = GameObject.FindGameObjectWithTag("HPBar").GetComponent<HPScript>().GetHpNum();
            clearS.TrueOneCallClear();
            SceneManager.LoadScene("ClearScene");
        }
    }
}
