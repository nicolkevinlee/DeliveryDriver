using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool hasPackage = false;
    SpriteRenderer driverSpriteRenderer;

    [SerializeField] Color32 hasPackageColor = new Color32(37,255,0,255);
    [SerializeField] Color32 noPackageColor = new Color32(255,255,255,255);
    [SerializeField] float destroyDelay = 1.0f;

    void Start()
    {
        driverSpriteRenderer = GetComponent<SpriteRenderer>();
        driverSpriteRenderer.color = noPackageColor;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Wah!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Pickup Package");
            hasPackage = true;
            driverSpriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }
        else if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            driverSpriteRenderer.color = noPackageColor;
        }
    }
}
