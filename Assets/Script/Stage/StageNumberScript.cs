using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class StageNumberScript : MonoBehaviour
{
    public static int stageNumber;

    public void Start()
    {
        if (this.gameObject.name == "StageNumber")
        {
            this.GetComponent<Text>().text = Regex.Replace(SceneManager.GetActiveScene().name, @"[^0-9]", "") + "Stage";
        }
    }

    public void SetStageNumber()
    {
        stageNumber = int.Parse(Regex.Replace(SceneManager.GetActiveScene().name, @"[^0-9]", ""));
    }
    /// <summary>
    /// �i���߁j���݂̃X�e�[�W�����擾
    /// </summary>
    /// <returns>(int)stageNumber</returns>
    public int GetStageNumber()
    {
        return stageNumber;
    }
}
