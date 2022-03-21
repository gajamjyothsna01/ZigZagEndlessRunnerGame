using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 direction;
    public float playerSpeed;
   // public static bool GetMouseButton()
    // Start is called before  first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            //If player is moving forward make him to move left  or else move right.
            if(direction == Vector3.forward )
            {
                direction = Vector3.left;
            }
            else
                direction = Vector3.forward;
        }
        transform.Translate(direction * playerSpeed * Time.deltaTime);

    }
  


}
