using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionScript : MonoBehaviour
{
    private GameObject missionMark;
    private Text missionText;
    //DateScript,LevelSelectionScript���Q�ƒ�
    //�X�e�[�W���₷�x�ɒǉ����A�N�G�X�g���₷�x�ɒǉ��E
    //[0�X�e�[�W,1�X�e�[�W�E�E�E]
    public static bool[] clearChecker = new bool[11];
    //[1�X�e�[�W,2�X�e�[�W�E�E�E]
    public static bool[,] missionClearChecker = new bool[10, 2];
    private int[] missionHpArray = { 1000, 1000, 1000, 1000, 800, 1000, 600, 1000, 1000, 700 };
    private int[] missionTimeArray = { 5, 8, 2, 8, 15, 5, 6, 4, 6, 20 };
    private string[,] missionTextArray = { 
                                           { "Hp1000�ȏ�", "Time5�b�ȉ�", "�X�e�[�W1-3" }, 
                                           { "Hp1000�ȏ�", "Time8�b�ȉ�", "�X�e�[�W2-3" },
                                           { "Hp1000�ȏ�", "Time2�b�ȉ�", "�X�e�[�W3-3" },
                                           { "Hp1000�ȏ�", "Time8�b�ȉ�", "�X�e�[�W4-3" },
                                           { "Hp800�ȏ�", "Time15�b�ȉ�", "�X�e�[�W5-3" },
                                           { "Hp1000�ȏ�", "Time5�b�ȉ�", "�X�e�[�W6-3" },
                                           { "Hp600�ȏ�", "Time6�b�ȉ�", "�X�e�[�W7-3" },
                                           { "Hp1000�ȏ�", "Time4�b�ȉ�", "�X�e�[�W8-3" },
                                           { "Hp1000�ȏ�", "Time6�b�ȉ�", "�X�e�[�W9-3" },
                                           { "Hp700�ȏ�", "Time20�b�ȉ�", "�X�e�[�W10-3" }
                                         };


    /// <summary>
    /// �X�R�A�~�b�V�����̃N���A����
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
    /// �^�C���~�b�V�����̃N���A����
    /// </summary>
    /// <param name="timeNum">float �N���A�^�C��</param>
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
    /// �~�b�V�����e�L�X�g�L��
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
    /// �X�e�[�W���N���A�����ƋL�^
    /// </summary>
    public void TrueClearChecker()
    {
        int stageNumber = GameObject.FindWithTag("GameManager").GetComponent<StageNumberScript>().GetStageNumber();
        clearChecker[stageNumber] = true;
    }
    /// <summary>
    /// �N���A�X�e�[�W�̎擾
    /// </summary>
    /// <returns>bool clearChecker[0�X�e�[�W,1�X�e�[�W�E�E�E]</returns>
    public bool[] GetClearChecker()
    {
        return clearChecker;
    }
    /// <summary>
    /// �N���A�N�G�X�g�̎擾
    /// </summary>
    /// <returns>bool missionClearChecker[1�X�e�[�W,1�N�G�X�g],[1�X�e�[�W,2�N�G�X�g],[2�X�e�[�W,1�N�G�X�g]</returns>
    public bool[,] GetMissionClearChecker()
    {
        return missionClearChecker;
    }
}
