using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int startingHealth = 5;
    private int currentHealth;

    // Start is called before the first frame update
    private void onEnable()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
