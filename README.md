# Разработка игровых сервисов
Отчет по лабораторной работе #4 выполнил(а):
- Городилова Снежана Александровна
- РИ-300001
Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | # | 20 |
| Задание 3 | * | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

## Цель работы
Ознакомиться с основными функциями Unity и взаимодействием с объектами внутри редактора.

## Задание 1
### Используя видео-материалы практических работ 1-5 повторить реализацию приведенного ниже функционала:
### – 1 Практическая работа «Создание анимации объектов на сцене»
### – 2 Практическая работа «Создание стартовой сцены и переключение между ними»
### – 3 Практическая работа «Доработка меню и функционала с остановкой игры»
### – 4 Практическая работа «Добавление звукового сопровождения в игре»
### – 5 Практическая работа «Добавление персонажа и сборка сцены для публикации на web-ресурсе»
Ход работы:
1) Создание новой сцены.
2) Создание объекта облака cloud 2 1, добавление ему анимации и контроллера CloudAnimation.
3) Добавление названия на главный экран и кнопок Play, Option и Quit для главного меню. 
4) Написание скрипта MainMenu:
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
```
5) Подключение медотов скрипта MainMenu к кнопкам Play и Quit.
6) Добавление новой сцены к билду.
8) Создание меню настроек, состоящего из кнопки Back.
9) Добавление надписи Paused.
10) Написание скрипта Pause:
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool paused = false;
    public GameObject panel;

    void Start()
    {
        Time.timeScale = 1;
        paused = false;
        panel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
                panel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                paused = false;
                panel.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
```
11) Добавление музыки в главное меню и игровую сцену.
12) Добавление звука для столкновения яйца с землёй и щитом. 
Для столкновения с землёй модифицирован метод OnTriggerEnter скрипта DragonEgg:
```
private void OnTriggerEnter(Collider other) 
    {
        var ps = GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;
        var rend = GetComponent<Renderer>();
        rend.enabled = false;

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
```
Для столкновения с щитом модифицирован метод OnCollisionEnter скрипта EnergyShield:
```
private void OnCollisionEnter(Collision other) {
        var collided = other.gameObject;
        if (collided.tag == "Dragon Egg")
        {
            Destroy(collided);
        }
        var score = int.Parse(scoreGT.text);
        score += 1;
        scoreGT.text = score.ToString();

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
```
12) Скачивание модели персонажа с анимацией, переименование ассета в Mage1.
13) Размещение Mage1 на сцене, подключение к объекту контроллера MageCTRL с анимацией MageIDLE.
14) Добавление Point Light.

## Задание 2
### Привести описание того, как происходит сборка проекта проекта под другие платформы. Какие могут быть особенности?

## Задание 3
### Добавить в меню Option возможность изменения громкости (от 0 до 100%) фоновой музыки в игре.
Ход работы:
1) Добавление в меню настроек слайдеров EffectSlider и ThemeSlider.
2) Подключение EffectSlider к звукам DragonEgg и EnergyShield.
3) Подкючение игровой темы к Enemy и отключение её у игровой сцены и Enemy в главном меню.
4) Подключение ThemeSlider к звукам MainCamera главного меню и Enemy.

Итоговый результат:
https://yandex.ru/games/app/198395?draft=true&lang=ru


## Выводы

В ходе работы было выполнены задания 1 и 3, добавлены звуки, главное меню, меню настроек и дополнительный персонаж.

| GitHub | [https://github.com/SweetSnowyWitch/DA-in-GameDev-lab1] |

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
