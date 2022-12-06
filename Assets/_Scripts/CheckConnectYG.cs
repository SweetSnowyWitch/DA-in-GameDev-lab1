using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using TMPro;
using System.Text;

public class CheckConnectYG : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += CheckSDK;
    private void OnDisable() => YandexGame.GetDataEvent -= CheckSDK;
    private TextMeshProUGUI scoreBest;
    private TextMeshProUGUI achieveList;
    // Start is called before the first frame update
    void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            CheckSDK();
        }
    }

    // Update is called once per frame
    public void CheckSDK()
    {
        if (YandexGame.auth)
        {
            Debug.Log("User authorization ok");
        }
        else
        {
            Debug.Log("User is not authorized");
            YandexGame.AuthDialog();
        }
        var scoreBO = GameObject.Find("BestScore");
        scoreBest = scoreBO.GetComponent<TextMeshProUGUI>();
        scoreBest.text = "Best Score: " + YandexGame.savesData.bestScore.ToString();
        var achieveBO = GameObject.Find("AchieveList");
        achieveList = achieveBO.GetComponent<TextMeshProUGUI>();
        var achieveText = new StringBuilder();
        foreach (var achievement in YandexGame.savesData.achievements)
        {
            achieveText.Append("\n");
            achieveText.Append(achievement);
        }
        achieveList.text = achieveText.ToString();
    }
}
