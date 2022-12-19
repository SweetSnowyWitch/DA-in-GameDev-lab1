# Разработка игровых сервисов
Отчет по лабораторной работе #6 выполнил(а):
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
###– 1 Практическая работа «Интеграция баннерной рекламы»
###– 2 Практическая работа «Интеграция видеорекламы»
###– 3 Практическая работа «Показ видеорекламы пользователю за вознаграждение»
###– 4 Практическая работа «Создание внутриигрового магазина»
###– 5 Практическая работа «Система антиблокировки рекламы»

Ход работы:
1) Создание RTB-блока на сайте Яндекса.
2) Добавление id созданного блока в билд игры.
3) Установка в настройках скрипта Viewing Ads YG для сцены 0 и 1 Pause Type - All и Pause Method - Remember Previous State.
4) Добавление кнопки рекламы на стартовый экран. 
5) Создание скрипта ADReward:
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class ADReward : MonoBehaviour
{
    private void OnEnable() => YandexGame.CloseVideoEvent += Rewarded;
    private void OnDisable() => YandexGame.CloseVideoEvent += Rewarded;

    private void Rewarded(int id)
    {
        switch (id)
        {
            case 1:
                Debug.Log("Пользователь получил награду");
                break;
            default:
                Debug.Log("Пользователь остался без награды");
                break;
        }
    }

    public void OpenAd()
    {
        YandexGame.RewVideoShow(Random.Range(0, 2));
    }
}

```
6) Модификация скрипта DragonPicker:
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
            YandexGame.RewVideoShow(0);
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
7) Добавление на стартовый экран объекта для покупок.
8) Настройка объекта для покупок в консоли Яндекса.

Итоговый результат:
https://yandex.ru/games/app/198395?draft=true&lang=ru


## Задание 2
### Добавить в приложение интерфейс для вывода статуса наличия игрока в сети (онлайн или офлайн).

## Задание 3
### Предложить наиболее подходящий на ваш взгляд способ монетизации игры D.Picker. Дать развернутый ответ с комментариями.

## Выводы

В ходе работы было выполнено задание 1.

| GitHub | [https://github.com/SweetSnowyWitch/DA-in-GameDev-lab1] |

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
