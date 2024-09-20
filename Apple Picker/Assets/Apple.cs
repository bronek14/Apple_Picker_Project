
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    void Update()
    {
        // Check if the apple has fallen below the bottomY
        if (transform.position.y < bottomY)
        {
            // Get a reference to the ApplePicker script attached to the main camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

            // Call the AppleMissed method from the ApplePicker script
            apScript.AppleMissed();

            // Destroy this apple object
            Destroy(this.gameObject);
        }
    }
}