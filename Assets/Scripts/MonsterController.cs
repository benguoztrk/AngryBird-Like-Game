using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
   
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float maxHeath = 5;
    [SerializeField] private float damageMin = 0.5f;
    [SerializeField] private float damageMax = 1.5f;
    [SerializeField] Sprite deadSprite;
    [SerializeField] ParticleSystem hitParticle;
    SpriteRenderer mySprite;
    
   [SerializeField] private float currentHeath;

    private const string BIRD = "Bird";
    private const string CRATE = "Crate";

    private void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        currentHeath = maxHeath;
        healthBar.UpdateHealthBar(maxHeath, currentHeath);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        //if (collision.gameObject.CompareTag(BIRD))
        //{
            
        //    Die();
          
        //}

        if (collision.gameObject.CompareTag(CRATE))
        {
           
               // currentHeath -= Random.Range(damageMin, damageMax);
                currentHeath -= damageMin;

           

            if (currentHeath <= 0)
            {
                currentHeath = 0;
                Debug.Log("current health below zero");
                Die();
            }
            if(currentHeath == 0 || currentHeath > 0)
            {
                healthBar.UpdateHealthBar(maxHeath, currentHeath);
            }
        }
    }



    void Die()
    {
        mySprite.sprite = deadSprite;
        hitParticle.Play();
      
    }


    
}
