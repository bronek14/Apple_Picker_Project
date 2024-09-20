using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    public GameObject applePrefab;
    public GameObject beeHivePrefab; // add for beehive

    public float speed = 2f;

    public float leftAndRightEdge = 10f;

    public float changeDirChance = 0.2f;

    public float appleDropDelay = 2f;
    public float beeHiveDropDelay = 10f;// add for beehive
    private float beeHiveDropInterval;// add for beehive


    // Start is called before the first frame update
    void Start()
    {
        //start dropping apples
        Invoke("DropApple", 2f);
        Invoke("DropBeeHive", beeHiveDropDelay);
        beeHiveDropInterval = beeHiveDropDelay;// add for beehive
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);

    }

    void DropBeeHive()
    {
        GameObject beeHive = Instantiate<GameObject>(beeHivePrefab);

        // Set the position directly above the tree
        Vector3 dropPosition = transform.position;
        dropPosition.y += 1.0f; // Adjust the height 
        beeHive.transform.position = dropPosition;

      
        Rigidbody rb = beeHive.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero; // Ensure no initial velocity, fixes my issue of beehives slamming into apples as instantiation 
        }

        Invoke("DropBeeHive", Random.Range(10f, 15f));
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing direction
        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);  //move right
        }
        else if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //move left
        }
        UpdateDropInterval();
    }
     void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1; //change direction
        }
    }

    void UpdateDropInterval()
    {
        int rounds = FindObjectOfType<ScoreCounter>().currentRound; 
        beeHiveDropInterval = Mathf.Max(1f, beeHiveDropDelay - (rounds * 0.5f)); 
    }













































}
