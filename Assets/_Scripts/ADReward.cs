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
