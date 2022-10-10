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
