using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBarP2 : MonoBehaviour
{

    public Slider FuelBar;

    private float maxFuel = 100;
    public float currentFuel;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static FuelBarP2 P2;

    private void Awake()
    {
        P2 = this;
    }
    void Start()
    {
        GetFuelP1();
    }

    public void GetFuelP1()
    {
        currentFuel = maxFuel;

        FuelBar.maxValue = maxFuel;
        FuelBar.value = maxFuel;
    }

    public void UseFuel(float amount)
    {
        if(currentFuel - amount >= 0)
        {
            currentFuel -=amount;
            FuelBar.value = currentFuel;

            if(regen != null )
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenFuel());
        }
    }

    private IEnumerator RegenFuel()
    {
        yield return new WaitForSeconds(2);

        while(currentFuel < maxFuel) 
        {
            currentFuel += maxFuel / 100;
            FuelBar.value = currentFuel;
            yield return regenTick;
        }
        regen = null;
    }
}
