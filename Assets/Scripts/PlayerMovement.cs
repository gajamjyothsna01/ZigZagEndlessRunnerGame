using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 direction;
    public float playerSpeed;
    //TileSpawnManager spawnManager;
   // public static bool GetMouseButton()
    // Start is called before  first frame update
    void Start()
    {
        //spawnManager = GameObject.Find("TileSpawnManager").GetComponent<TileSpawnManager>();
      

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
    private void OnTriggerExit(Collider other)
    {
        //spawnManager.SpawnTile();
        
        //if(other.gameObject.tag =="Player")
        //{
            TileSpawnManager.Instance.SpawnTile();
        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Coin")
        {

           // ScoreManagerScript.Score(10);
            GameObject.Find("ScoreManager").GetComponent<ScoreManagerScript>().Score(10);
            

        }
    }




}
