using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using TMPro;

public class DragonPicker : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += GetLoadSave;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoadSave;
    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3;
    public float energyShieldBottomY = -6f;
    public float energyShieldRadius = 1.5f;
    public TextMeshProUGUI scoreGT;
    public TextMeshProUGUI playerName;
    public List<GameObject> shieldList;

    void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            GetLoadSave();
        }
        shieldList = new List<GameObject>();
        var scoreGO = GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();

        for (var i = 1; i <= numEnergyShield; i++)
        {
            var tShieldGo = Instantiate<GameObject>(energyShieldPrefab);
            tShieldGo.transform.position = new Vector3(0, energyShieldBottomY, 0);
            tShieldGo.transform.localScale = new Vector3(i, i, i);
            shieldList.Add(tShieldGo);
        }
    }

    void Update()
    {

    }

    public void DragonEggDestroyed()
    {
        var tDragonEggArray = GameObject.FindGameObjectsWithTag("Dragon Egg");
        foreach (var tGO in tDragonEggArray)
        {
            Destroy(tGO);
        }
        var shieldIndex = shieldList.Count - 1;
        var tShieldGo = shieldList[shieldIndex];
        shieldList.RemoveAt(shieldIndex);
        Destroy(tShieldGo);

        if (shieldList.Count == 0)
        {
            var scoreGO = GameObject.Find("Score");
            scoreGT = scoreGT.GetComponent<TextMeshProUGUI>();
            UserSave(int.Parse(scoreGT.text), "Береги щиты!");
            YandexGame.NewLeaderboardScores("TopPlayerScores", int.Parse(scoreGT.text));
            SceneManager.LoadScene("_0Scene");
            GetLoadSave();
        }
    }

    public void GetLoadSave()
    {
        Debug.Log(YandexGame.savesData.score);
        var playerNamePrefabGUI = GameObject.Find("PlayerName");
        playerName = playerNamePrefabGUI.GetComponent<TextMeshProUGUI>();
        playerName.text = YandexGame.playerName;
    }

    public void UserSave(int currentScore, string achievement)
    {
        YandexGame.savesData.score = currentScore;
        if (currentScore > YandexGame.savesData.bestScore)
        {
            YandexGame.savesData.bestScore = currentScore;
        }
        if (!YandexGame.savesData.achievements.Contains(achievement))
        {
            YandexGame.savesData.achievements.Add(achievement);
        }
        YandexGame.SaveProgress();
    }
}
