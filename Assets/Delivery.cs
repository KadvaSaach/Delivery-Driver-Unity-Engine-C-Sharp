using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    // Debug.Debug.Log("Collision bolte");
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32  hasPackageColor = new Color32 (1,1,1,1);
    [SerializeField] Color32  noPackageColor = new Color32 (1,1,1,1);

    // reference variables
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        // Debug.Log("Collision bolte");
        Debug.Log("Ouch!!!");

    }

    void OnTriggerEnter2D(Collider2D other) {

        //Debug.Log("Trigger bolte");

        if(other.tag == "Package" && !hasPackage )
        {
            //Debug.Log("Package bolte");

            Debug.Log("Package Picked up");
            hasPackage  = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);

        }
        if( other.tag == "Customer" && hasPackage)
        {
            //Debug.Log("Customer bolte");

            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
