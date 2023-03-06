using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private int a = 0;
    private int b = 0;
    public void GameStart()
    {
        bool[] clearChecker = GameManager.instance.GetComponent<MissionScript>().GetClearChecker();
        //clearCheckerの初期設定
        clearChecker[0] = true;
        //クリア数カウント
        foreach (bool i in clearChecker)
        {
            b++;
            if (i)
            {
                a++;
            }
        }
        GameManager.instance.SetOneCall();
        if (a == b)
        {
            SceneManager.LoadScene(a - 1 + "StageScene");
        }
        else
        {
            SceneManager.LoadScene(a + "StageScene");
        }
    }
    public void ReStart()
    {
        int stageNumber = GameManager.instance.GetComponent<StageNumberScript>().GetStageNumber();
        SceneManager.LoadScene(stageNumber + "StageScene");
        GameManager.instance.SetOneCall();
    }
    public void NextStage()
    {
        int stageNumber = GameManager.instance.GetComponent<StageNumberScript>().GetStageNumber();
        stageNumber++;
        GameManager.instance.SetOneCall();
        if (stageNumber == GameManager.instance.GetComponent<MissionScript>().GetClearChecker().Length)
        {
            SceneManager.LoadScene("LevelSelectionScene");
        }
        else
        {
            SceneManager.LoadScene(stageNumber + "StageScene");
        }
    }
    public void LevelSelection()
    {
        SceneManager.LoadScene("LevelSelectionScene");
    }
    public void ReturnToStart()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void TermsOfService()
    {
        SceneManager.LoadScene("TermsOfServiceScene");
    }
}
