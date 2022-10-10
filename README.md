# Разработка игровых сервисов
Отчет по лабораторной работе #2 выполнил(а):
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

Структура отчета

- Данные о работе: название работы, фио, группа, выполненные задания.
- Цель работы.
- Задание 1.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 2.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 3.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Выводы.
- ✨Magic ✨

## Цель работы
Ознакомиться с основными функциями Unity и взаимодействием с объектами внутри редактора.

## Задание 1
### По теме видео практических работ 1-5 повторить реализацию игры на Unity. Привести описание выполненных действий.
Ход работы:
1) Создание проекта 3D - Core
2) Скачивание ассетов Dragon for Boss Monster: PBR и Fire & Spell Effects
3) Добавление на поле одного из ассетных драконов
4) Создание контроллера для анимаций дракона, добавление IDLE анимации полёта
5) Написание скрипта EnemyDragon для описания поведения дракона:
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragon : MonoBehaviour
{
    public GameObject dragonEggPrefab;
    public float speed = 1;
    public float timeBetweenEggDrops = 1f;
    public float leftRightDistance = 10f;
    public float chanceDirection = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropEgg", 2f);

    }

    void DropEgg()
    {
        var myVector = new Vector3(0f, 5f, 0f);
        var egg = Instantiate<GameObject>(dragonEggPrefab);
        egg.transform.position = transform.position + myVector;
        Invoke("DropEgg", timeBetweenEggDrops);
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftRightDistance)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftRightDistance)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate() {
        if (Random.value < chanceDirection)
        {
            speed *= -1;
        }
    }
}
```
6) Создание объекта DragonEgg и материала для него, присвоение объекту кастомного тега Dragon Egg
7) Создание скрипта DragonEgg для уничтожения при столкновении с поверхностью и появлению при этом эффекта огня:
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEgg : MonoBehaviour
{
    public static float bottomY = -30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        var ps = GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;
        var rend = GetComponent<Renderer>();
        rend.enabled = false;
    }
}
```
8) Создание объекта EnergyShield с полупрозрачным материалом
9) Создания объекта Ground с ассетным материалом
10) Создание скрипта DragonPicker для Ground:
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPicker : MonoBehaviour
{
    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3;
    public float energyShieldBottomY = -6f;
    public float energyShieldRadius = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        for (var i = 1; i <= numEnergyShield; i++)
        {
            var tShieldGo = Instantiate<GameObject>(energyShieldPrefab);
            tShieldGo.transform.position = new Vector3(0, energyShieldBottomY, 0);
            tShieldGo.transform.localScale = new Vector3(i, i, i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
```


https://user-images.githubusercontent.com/75910420/194908278-d8bc7445-27e7-40a6-8e4c-53cc66398b45.mp4



## Задание 2
### В проект, выполненный в предыдущем задании, добавить систему проверки того, что SDK подключен (доступен в режиме онлайн и отвечает на запросы);

## Задание 3
### 1. Произвести сравнительный анализ игровых сервисов Яндекс Игры и VK Game;
### 2. Дать сравнительную характеристику сервисов, описать функционал;
### 3. Описать их методы интеграции с Unity;
### 4. Произвести сравнение, сделать выводы;
### 5. Подготовить реферат по результатам выполнения пунктов 1-4 .

## Выводы

В ходе работы было выполнено задание 1, разобран принцип работы с ассетами.

| GitHub | [https://github.com/SweetSnowyWitch/DA-in-GameDev-lab1] |

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
