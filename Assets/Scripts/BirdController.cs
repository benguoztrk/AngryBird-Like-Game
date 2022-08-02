using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    Vector2 _startPosition;
    Rigidbody2D myRb;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        _startPosition = myRb.position;
        myRb.isKinematic = true;
    }


    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;

    }

    void OnMouseUp()
    {
        var currentPosition =myRb.position;
        Vector2 direction = _startPosition - currentPosition; 
        direction.Normalize();

        myRb.isKinematic = false;
        myRb.AddForce(direction * 500);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    
}
