using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathBarPlayerScript : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float maxHeath = 5;
    [SerializeField] private float damageMin = 0.5f;
    [SerializeField] private float damageMax = 1.5f;
    private float currentHealth;

   
    void Start()
    {
        currentHealth = maxHeath;
        healthBar.UpdateHealthBar(maxHeath, currentHealth);
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("mouse button pressed");
            currentHealth -= Random.Range(damageMin, damageMax);
           // currentHeath -= 0.3f;

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                healthBar.UpdateHealthBar(maxHeath, currentHealth);
            }
        }
    }
    //private void OnMouseDown()
    //{
    //    Debug.Log("mouse button pressed");
    //    currentHeath -= Random.Range(0.5f, 1.5f);

    //    if(currentHeath <= 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        healthBar.UpdateHealthBar(maxHeath, currentHeath);
    //    }
    //}



}
