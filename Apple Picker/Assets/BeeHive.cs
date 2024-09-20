using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class BeeHive : MonoBehaviour
{
    public static float bottomY = -15f; //changed from 20

    void Update()
    {
        // Check if the beeHive has fallen below the bottomY
        if (transform.position.y < bottomY)
        {
            // Destroy the beeHive object without affecting the baskets
            Destroy(this.gameObject);
        }
    }

    }

    
