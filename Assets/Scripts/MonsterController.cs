using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MonsterController : MonoBehaviour
{

    public static MonsterController instance;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float maxHeath = 5;
    [SerializeField] private float damageMin = 0.5f;
    [SerializeField] private float damageMax = 1.5f;
    [SerializeField] Sprite deadSprite;
    [SerializeField] ParticleSystem hitParticle;  
    [SerializeField] public float currentHealth;
    [SerializeField] public bool hasDied;
    public int numOfMonsters;
    public GameObject[] monsters;
    SpriteRenderer mySprite;

    private const string BIRD = "Bird";
    private const string CRATE = "Crate";
    private const string GROUND = "Ground";


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        mySprite = GetComponent<SpriteRenderer>();

    }
    private void OnEnable()
    {
        monsters = GameObject.FindGameObjectsWithTag("Monster");
    }

    void Start()
    {
        currentHealth = maxHeath;
        healthBar.UpdateHealthBar(maxHeath, currentHealth);
        numOfMonsters = monsters.Length;
      
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag(CRATE) || collision.gameObject.CompareTag(BIRD) || collision.gameObject.CompareTag(GROUND))
        {

            // currentHeath -= Random.Range(damageMin, damageMax);
            currentHealth -= damageMin;

            if (hasDied == true)
            {
                if (currentHealth < 0)
                {
                    currentHealth = 0;
                    numOfMonsters--;
                    Debug.Log("number of monsters" + numOfMonsters);
                    StartCoroutine(Die());
                    hasDied = false;
                }
                if (currentHealth == 0 || currentHealth > 0)
                {
                    healthBar.UpdateHealthBar(maxHeath, currentHealth);
                }
            }


        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag(CRATE))
    //    {
    //        // currentHeath -= Random.Range(damageMin, damageMax);
    //        currentHealth -= damageMin;

    //        if (hasDied == true)
    //        {
    //            if (currentHealth < 0)
    //            {
    //                currentHealth = 0;
    //                numOfMonsters--;
    //                Debug.Log("number of monsters" + numOfMonsters);
    //                Die();
    //                hasDied = false;
    //            }
    //            if (currentHealth == 0 || currentHealth > 0)
    //            {
    //                healthBar.UpdateHealthBar(maxHeath, currentHealth);
    //            }
    //        }
    //    }
    //}


     IEnumerator Die()
    {
        hasDied = true;
        mySprite.sprite = deadSprite;
        hitParticle.Play();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
      

    }


    
}
