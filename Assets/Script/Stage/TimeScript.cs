using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour
{
    private Text timeText;
    private float timeNumber;

    /// <summary>
    /// タイム演算、UIに記入
    /// </summary>
    public void TimeUpdate(bool ballStart)
    {
        if (!ballStart)
        {
            timeNumber += Time.deltaTime;
            timeText.text = "Time:" + timeNumber.ToString("F1");
        }
    }
    /// <summary>
    /// タイム演算リセット
    /// </summary>
    public void TimeReset()
    {
        timeNumber = 0;
    }
    /// <summary>
    /// タイムUI取得
    /// </summary>
    public void SetTimeText()
    {
        timeText = GameObject.FindWithTag("Time").GetComponent<Text>();
    }
    /// <summary>
    /// 現在のタイム取得
    /// </summary>
    /// <returns>float timeNumber</returns>
    public float GetTimeNumber()
    {
        return timeNumber;
    }
}
