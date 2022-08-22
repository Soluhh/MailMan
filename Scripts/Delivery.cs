using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color(1, 1, 1, 1);

    [SerializeField] private float destroyTime = 0.5f;
    
    private bool grabbedPackage = false;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" && !grabbedPackage)
        {
            grabbedPackage = true;
            Debug.Log("Package Grabbed!");

            Destroy(other.gameObject, destroyTime);

            spriteRenderer.color = hasPackageColor;
        }

        if(other.tag == "Customer" && grabbedPackage == true)
        {
            Debug.Log("Package Delivered!");
            grabbedPackage = false;

            spriteRenderer.color = noPackageColor;
        }
    }
}
