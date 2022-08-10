using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MonsterDOTween : MonoBehaviour
{
   
    void Start()
    {
        transform.DOMoveY(3,5f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

   
    void Update()
    {
        
    }
}
