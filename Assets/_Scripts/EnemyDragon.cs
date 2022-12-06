using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyDragon : MonoBehaviour
{
    public GameObject dragonEggPrefab;
    public TextMeshProUGUI scoreGT;
    public float speed = 1;
    public float timeBetweenEggDrops = 1f;
    public float leftRightDistance = 10f;
    public float chanceDirection = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropEgg", 2f);
        var scoreGO = GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
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

    private void FixedUpdate()
    {
        if (Random.value < chanceDirection)
        {
            speed *= -1;
        }
    }
}
