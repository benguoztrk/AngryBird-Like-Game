using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
   
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float maxHeath = 5;
    [SerializeField] private float damageMin = 0.5f;
    [SerializeField] private float damageMax = 1.5f;
    private float currentHeath;

    private const string BIRD = "Bird";
    private const string CRATE = "Crate";


    void Start()
    {
        currentHeath = maxHeath;
        healthBar.UpdateHealthBar(maxHeath, currentHeath);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.CompareTag(BIRD))
        {
            Debug.Log("bird collide with monster");
            Die();
          
        }

        if (collision.gameObject.CompareTag(CRATE))
        {
            currentHeath -= Random.Range(damageMin, damageMax);


            if (currentHeath <= 0)
            {
                Die();
            }
            else
            {
                healthBar.UpdateHealthBar(maxHeath, currentHeath);
            }
        }
    }



    void Die()
    {
        gameObject.SetActive(false);
    }

}
