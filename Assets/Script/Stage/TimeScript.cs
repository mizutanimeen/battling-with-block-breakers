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
    /// �^�C�����Z�AUI�ɋL��
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
    /// �^�C�����Z���Z�b�g
    /// </summary>
    public void TimeReset()
    {
        timeNumber = 0;
    }
    /// <summary>
    /// �^�C��UI�擾
    /// </summary>
    public void SetTimeText()
    {
        timeText = GameObject.FindWithTag("Time").GetComponent<Text>();
    }
    /// <summary>
    /// ���݂̃^�C���擾
    /// </summary>
    /// <returns>float timeNumber</returns>
    public float GetTimeNumber()
    {
        return timeNumber;
    }
}
