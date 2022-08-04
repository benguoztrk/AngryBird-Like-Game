using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
  //  [SerializeField] private UnitType unitType = null;
    [SerializeField] private GameObject helmetObject;
    [SerializeField] private GameObject axeObject;

    private void Awake()
    {
       //GetComponent<Renderer>().material.color = unitType.unitColor;
        //helmetObject = unitType.helmetType;
        
        //axeObject = unitType.axeType;
    }
    void Start()
    {
       // helmetObject = unitType.helmetType;

       // axeObject = unitType.axeType;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
