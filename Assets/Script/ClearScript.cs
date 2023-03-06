using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearScript : MonoBehaviour
{
    private bool oneCallClear = true;
    public MissionScript missionS;
    public TimeScript timeS;
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "ClearScene")
        {
            if (oneCallClear)
            {
                oneCallClear = false;
                missionS.MissionTextInput();
                float hpNum = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().hpNum;
                missionS.MissionHpCheck(hpNum);
                float timeNum = timeS.GetTimeNumber();
                missionS.MissionTimeCheck(timeNum);
                missionS.TrueClearChecker();
                this.gameObject.GetComponent<DateScript>().SaveAndLoadDate();
                GameObject.FindWithTag("ClearHPText").GetComponent<Text>().text = "ClearHP�F" + hpNum;
                GameObject.FindWithTag("Time").GetComponent<Text>().text = "ClearTime�F" + timeNum.ToString("F1");
            }
        }
    }
    /// <summary>
    ///�����sON�iClearScene�j 
    /// </summary>
    public void TrueOneCallClear()
    {
        oneCallClear = true;
    }
}
