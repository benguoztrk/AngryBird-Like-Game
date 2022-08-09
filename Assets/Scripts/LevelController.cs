using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelController : MonoBehaviour
{
    [SerializeField] string nextLevelName;
    [SerializeField] GameObject levelFinishCanvas;
    public GameObject[] monsters;
    public int numOfMonsters;

    public static LevelController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnEnable()
    {
        monsters = GameObject.FindGameObjectsWithTag("Monster");
    }

    void Start()
    {

       
        numOfMonsters = monsters.Length;


    }

   
    void Update()
    {
       StartCoroutine(ActivateCanvas());
           
    }

    public void GoToNextLevel()
    {
        Debug.Log("next level" + nextLevelName);
        SceneManager.LoadScene(nextLevelName);
    }
    private bool IsMonstersAllDead()
    {

        foreach(var monster in monsters)
        {
            if (monster.gameObject.activeSelf)
                return false;
        }

        

        return true;

    }




    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       // ResumeGame();


    }

    IEnumerator ActivateCanvas()
    {

        if (IsMonstersAllDead())
        {
            yield return new WaitForSeconds(1.3f);
            levelFinishCanvas.SetActive(true);
        }
    }

}
