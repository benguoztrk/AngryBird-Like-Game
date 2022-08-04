using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] float launchForce= 500f;

    Vector2 _startPosition;
    Rigidbody2D myRb;
    SpriteRenderer mySprite;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        _startPosition = myRb.position;
        myRb.isKinematic = true;
    }


    void OnMouseDown()
    {
        mySprite.color = Color.red;

    }

    void OnMouseUp()
    {
        Vector2 currentPosition = myRb.position;
        Vector2 direction = _startPosition - currentPosition; 
        direction.Normalize();

        myRb.isKinematic = false;
        myRb.AddForce(direction * launchForce);
        mySprite.color = Color.white; 
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }


  
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(DelayReset());
       
    }
    IEnumerator DelayReset()
    {
        yield return new WaitForSeconds(2);
        myRb.position = _startPosition;
        myRb.isKinematic = true;
        myRb.velocity = Vector2.zero;
    }
}
