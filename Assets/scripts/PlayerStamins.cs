using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamins : MonoBehaviour
{
    public int maxStamina = 100;
    public int currentStamina;
    public int damagePlayer;

    public StaminaBar staminaBar;
    public WaitForSeconds regenTime= new WaitForSeconds(0.1f);
    private Coroutine regen;
    private void Start()
    {
        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&(currentStamina>0))
        {
            TakeDamage(40);
     
        }
    }

    void TakeDamage(int damage)
    {
        damagePlayer = damage;
        if(currentStamina - damagePlayer >= 0)
        currentStamina -= damagePlayer;

        staminaBar.SetStamina(currentStamina);

        if (regen != null)
         StopCoroutine(regen);

        regen = StartCoroutine(regenHealth());
    }

    private IEnumerator regenHealth()
    {
        yield return new WaitForSeconds(2f);

        while(currentStamina<maxStamina)
        {
            currentStamina += 5;
            staminaBar.SetStamina(currentStamina);
            yield return regenTime;
        }
        regen = null;
    }
}
