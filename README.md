# Разработка игровых сервисов
Отчет по лабораторной работе #1 выполнил(а):
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
### В разделе «ход работы» пошагово выполнить каждый пункт с описанием и примера реализации задач по теме видео самостоятельной работы.
Ход работы:
1) Создать новый проект из шаблона 3D – Core;
2) Проверить, что настроена интеграция редактора Unity и Visual Studio Code (пункты 8-10 введения);
3) Создать объект Plane;
4) Создать объект Cube;
5) Создать объект Sphere;
6) Установить компонент Sphere Collider для объекта Sphere;
7) Объект куб перекрасить в красный цвет;
8) Добавить кубу симуляцию физики, при этом куб не должен проваливаться под Plane;
9) Написать скрипт, который будет выводить в консоль сообщение о том, что объект Sphere столкнулся с объектом Cube;
```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Произошло столкновение с " + other.gameObject.name);
        other.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("Завершено столкновение с " + other.gameObject.name);
        other.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
}

```

10) Написать скрипт, чтобы при столкновении Cube менял свой цвет на зелёный, а при завершении столкновения обратно на красный.
```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Equals("Cube"))
        {
            other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name.Equals("Cube"))
        {
            other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
    }
}
```

![image](https://user-images.githubusercontent.com/75910420/192097284-af60dde6-af4b-414c-821c-eb85b3f60ae4.png)
![image](https://user-images.githubusercontent.com/75910420/192097291-66428c85-3a19-44d7-8d8c-7ee18f930330.png)

## Задание 2
### Продемонстрируйте на сцене в Unity следующее:
- Что произойдёт с координатами объекта, если он перестанет быть дочерним?
- Создайте три различных примера работы компонента RigidBody.

## Задание 3
### Реализуйте на сцене генерацию n кубиков. Число n вводится пользователем после старта сцены.
Ход работы:
1) Создать объект Empty с названием CubePoint;
2) Создать объект Cube с названием SpawnCube;
3) Присвоить SpawnCube красный цвет;
4) Сделать SpawnCube ассетом и убрать со сцены;
5) Создать скрипт SpawnCubes и добавить его к CubePoint;

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject spawnCube;
    public int cubeCount = 0;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (counter < cubeCount)
        {
            Instantiate(spawnCube);
            counter++;
        }
    }
}
```

6) При изменении переменной Cube Count в большую сторону, количество кубов на сцене увеличится, иначе – останется неизменным.
![image](https://user-images.githubusercontent.com/75910420/192097416-3a820c6c-fe37-48b5-8871-ffb2bb21861b.png)
![image](https://user-images.githubusercontent.com/75910420/192097435-311c40b4-ba97-49ae-9d0e-d1319fb59eae.png)

## Выводы

В ходе работы были выполнены задания 1 и 3: сделаны несколько скриптов (смена цвета куба при столкновении с шаром, а также разрушение шара при столкновении с платформой), изучены компоненты Collider и Rigitbody, а также материал красного цвета.

| GitHub | [https://github.com/SweetSnowyWitch/DA-in-GameDev-lab1] |

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
