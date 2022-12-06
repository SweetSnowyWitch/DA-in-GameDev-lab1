# Разработка игровых сервисов
Отчет по лабораторной работе #5 выполнил(а):
- Городилова Снежана Александровна
- РИ-300001
Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | # | 20 |
| Задание 3 | # | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

## Цель работы
Создание интерактивного приложения с рейтинговой системой пользователя и интеграция игровых сервисов в готовое приложение.

## Задание 1
### Используя видео-материалы практических работ 1-5 повторить реализацию приведенного ниже функционала:
###– 1 Практическая работа «Интеграции авторизации с помощью Яндекс SDK»
###– 2 Практическая работа «Сохранение данных пользователя на платформе Яндекс Игры»
###– 3 Практическая работа «Сбор данных об игроке и вывод их в интерфейсе»
###– 4 Практическая работа «Интеграция таблицы лидеров»
###– 5 Практическая работа «Интеграция системы достижений в проект»
Ход работы:
1) Добавление элемента YG на сцену 1.
2) Модификация скрипта SavesYG:
```
using System.Collections.Generic;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Ваши сохранения
        public int score;
        public int bestScore = 0;
        public List<string> achievements = new List<string>();
    }
}
```
3) Создание скрипта CheckConnectYG:
```
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
```
4) Модификация скрипта DragonPicker, с добавлением лидерборда:
```
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
```
5) Настройка лидерборда в Яндекс Консоли.

Итоговый результат:
https://yandex.ru/games/app/198395?draft=true&lang=ru

https://user-images.githubusercontent.com/75910420/205960345-3f333bbd-d25c-4f11-b43b-48b14b12a26e.mp4


## Задание 2
### Описать не менее трех дополнительных функций Яндекс SDK, которые могут быть интегрированы в игру.

## Задание 3
### Доработать стилистическое оформление списка лидеров и системы достижений, реализованных в задании 1

## Выводы

В ходе работы было выполнено задание 1, добавлены лидерборд и достижения.

| GitHub | [https://github.com/SweetSnowyWitch/DA-in-GameDev-lab1] |

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
