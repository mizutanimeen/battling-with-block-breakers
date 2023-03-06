using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateScript : MonoBehaviour
{
    int[,] saveMissionList = new int[10, 2];
    private int[] saveStageList = new int[11];
    //[1ステージ,2ステージ・・・]
    private bool[,] missionClearChecker;
    //[0ステージ,1ステージ・・・]
    private bool[] clearChecker;

    private void Start()
    {
        if (this.gameObject.tag == "Date")
        {
            SaveAndLoadDate();
        }
    }

    public void SaveAndLoadDate()
    {
        SetChecker();
        SaveDate();
        LoadDate();
    }

    private void SetChecker()
    {
        missionClearChecker = GameObject.FindWithTag("GameManager").GetComponent<MissionScript>().GetMissionClearChecker();
        clearChecker = GameObject.FindWithTag("GameManager").GetComponent<MissionScript>().GetClearChecker();
    }

    private void SaveDate()
    {
        for (int i = 0; i < clearChecker.Length; i++)
        {
            if (clearChecker[i])
            {
                PlayerPrefs.SetInt("Stage_Key" + i, 1);
            }
        }
        for (int i = 0; i < missionClearChecker.GetLength(0); i++)
        {
            for (int a = 0; a < 2; a++)
            {
                if (missionClearChecker[i, a])
                {
                    PlayerPrefs.SetInt("Mission_Key" + i + a, 1);
                }
            }
        }
    }

    private void LoadDate()
    {
        for (int i = 0; i < saveStageList.Length; i++)
        {
            saveStageList[i] = PlayerPrefs.GetInt("Stage_Key" + i);
            if (saveStageList[i] == 1)
            {
                clearChecker[i] = true;
            }
        }
        for (int i = 0; i < missionClearChecker.GetLength(0); i++)
        {
            for (int a = 0; a < 2; a++)
            {
                saveMissionList[i, a] = PlayerPrefs.GetInt("Mission_Key" + i + a);
                if (saveMissionList[i, a] == 1)
                {
                    missionClearChecker[i, a] = true;
                }
            }
        }
    }
}
