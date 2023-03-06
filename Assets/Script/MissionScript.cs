using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionScript : MonoBehaviour
{
    private GameObject missionMark;
    private Text missionText;
    //DateScript,LevelSelectionScriptが参照中
    //ステージ増やす度に追加左、クエスト増やす度に追加右
    //[0ステージ,1ステージ・・・]
    public static bool[] clearChecker = new bool[11];
    //[1ステージ,2ステージ・・・]
    public static bool[,] missionClearChecker = new bool[10, 2];
    private int[] missionHpArray = { 1000, 1000, 1000, 1000, 800, 1000, 600, 1000, 1000, 700 };
    private int[] missionTimeArray = { 5, 8, 2, 8, 15, 5, 6, 4, 6, 20 };
    private string[,] missionTextArray = { 
                                           { "Hp1000以上", "Time5秒以下", "ステージ1-3" }, 
                                           { "Hp1000以上", "Time8秒以下", "ステージ2-3" },
                                           { "Hp1000以上", "Time2秒以下", "ステージ3-3" },
                                           { "Hp1000以上", "Time8秒以下", "ステージ4-3" },
                                           { "Hp800以上", "Time15秒以下", "ステージ5-3" },
                                           { "Hp1000以上", "Time5秒以下", "ステージ6-3" },
                                           { "Hp600以上", "Time6秒以下", "ステージ7-3" },
                                           { "Hp1000以上", "Time4秒以下", "ステージ8-3" },
                                           { "Hp1000以上", "Time6秒以下", "ステージ9-3" },
                                           { "Hp700以上", "Time20秒以下", "ステージ10-3" }
                                         };


    /// <summary>
    /// スコアミッションのクリア判定
    /// </summary>
    public void MissionHpCheck(float hpNum)
    {
        int stageNumber = GameObject.FindWithTag("GameManager").GetComponent<StageNumberScript>().GetStageNumber();
        int missionHp = missionHpArray[stageNumber - 1];

        if (missionHp <= hpNum)
        {
            missionMark = GameObject.FindWithTag("Mission1Mark");
            missionMark.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            missionClearChecker[stageNumber - 1, 0] = true;
        }
    }
    /// <summary>
    /// タイムミッションのクリア判定
    /// </summary>
    /// <param name="timeNum">float クリアタイム</param>
    public void MissionTimeCheck(float timeNum)
    {
        int stageNumber = GameObject.FindWithTag("GameManager").GetComponent<StageNumberScript>().GetStageNumber();
        int missionTime = missionTimeArray[stageNumber - 1];
        if (timeNum <= missionTime + 0.1)
        {
            missionMark = GameObject.FindWithTag("Mission2Mark");
            missionMark.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            missionClearChecker[stageNumber - 1, 1] = true;
        }
    }
    /// <summary>
    /// ミッションテキスト記入
    /// </summary>
    public void MissionTextInput()
    {
        int stageNumber = GameObject.FindWithTag("GameManager").GetComponent<StageNumberScript>().GetStageNumber();
        missionText = GameObject.FindWithTag("1MissionText").GetComponent<Text>();
        missionText.text = missionTextArray[stageNumber - 1, 0];
        missionText = GameObject.FindWithTag("2MissionText").GetComponent<Text>();
        missionText.text = missionTextArray[stageNumber - 1, 1];
    }
    /// <summary>
    /// ステージをクリアしたと記録
    /// </summary>
    public void TrueClearChecker()
    {
        int stageNumber = GameObject.FindWithTag("GameManager").GetComponent<StageNumberScript>().GetStageNumber();
        clearChecker[stageNumber] = true;
    }
    /// <summary>
    /// クリアステージの取得
    /// </summary>
    /// <returns>bool clearChecker[0ステージ,1ステージ・・・]</returns>
    public bool[] GetClearChecker()
    {
        return clearChecker;
    }
    /// <summary>
    /// クリアクエストの取得
    /// </summary>
    /// <returns>bool missionClearChecker[1ステージ,1クエスト],[1ステージ,2クエスト],[2ステージ,1クエスト]</returns>
    public bool[,] GetMissionClearChecker()
    {
        return missionClearChecker;
    }
}
