using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image heatlthBarImg;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        heatlthBarImg.fillAmount = currentHealth / maxHealth;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position); // It makes heath Bar always look towards the camera.
    }
}
