using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBarPlayer1 : MonoBehaviour
{

    public Slider staminaBar;

    private float maxStamina = 100;
    public float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static StaminaBarPlayer1 P1;

    private void Awake()
    {
        P1 = this;
    }
    void Start()
    {
        GetStaminaP1();
    }

    public void GetStaminaP1()
    {
        currentStamina = maxStamina;

        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void UseStamina(float amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -=amount;
            staminaBar.value = currentStamina;

            if(regen != null )
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina) 
        {
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }
}
