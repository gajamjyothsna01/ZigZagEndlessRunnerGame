using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 direction;
    public float playerSpeed;
    public GameObject tempObj;
    TileSpawnManager spawnManager;
   // public static bool GetMouseButton()
    // Start is called before  first frame update
    void Start()
    {
        spawnManager = GameObject.Find("TileSpawnManager").GetComponent<TileSpawnManager>();
        for(int i = 0;i<10;i++)
        {
            TileSpawnManager.Instance.SpawnTile();

        }


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
        //SpawnTile();
        transform.Translate(direction * playerSpeed * Time.deltaTime);

    }
   public void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag=="RTile")
        {
            //Destroy(gameObject, 3f);
            TileSpawnManager.Instance.BackToRightPool(collision.gameObject);
            tempObj = collision.gameObject;
            //StartCoroutine("RightPool");
        }
        if (collision.gameObject.tag == "FTile")
        {
            //Destroy(gameObject, 3f);
            TileSpawnManager.Instance.BackToForwardPool(collision.gameObject);
            tempObj = collision.gameObject;
            //StartCoroutine("ForwardPool");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        spawnManager.SpawnTile();
        //spawnManager.SpawnTile();
        
        //if(other.gameObject.tag =="Player")
        //{
        TileSpawnManager.Instance.SpawnTile();
            
        //}
        /*if(other.gameObject.tag == "RTile")
        {
            tempObj = other.gameObject;
            tempObj.GetComponentInParent<Rigidbody>().isKinematic = false;
            //tempObj.GetComponent<Rigidbody>().isKinematic = false;
            StartCoroutine("RightPool");
        }
        else if (other.gameObject.tag == "FTile")
        {
            tempObj = other.gameObject;
            tempObj.GetComponentInParent<Rigidbody>().isKinematic=false;
                //
                                         //GetComponent<Rigidbody>().isKinematic = false;
            StartCoroutine("ForwardPool");
        }*/
    }
    
    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag =="Coin")
        {

           // ScoreManagerScript.Score(10);
            GameObject.Find("ScoreManager").GetComponent<ScoreManagerScript>().Score(10);
            

        }
    }

    IEnumerator RightPool()
    {
        yield return new WaitForSeconds(0.5f);
       // Debug.Log()

        //TileSpawnManager.Instance.BackToForwardPool(tempObj);
        TileSpawnManager.Instance.BackToRightPool(tempObj);

    }
    IEnumerator ForwardPool()
    {
        yield return new WaitForSeconds(0.5f);
       // Debug.Log()

        TileSpawnManager.Instance.BackToForwardPool(tempObj);
        //TileSpawnManager.Instance.BackToRightPool(tempObj);

    }



}
