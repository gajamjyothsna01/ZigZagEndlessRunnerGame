using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnManager : MonoBehaviour
{
    public GameObject currentTile;
    public GameObject rightTile;
    public GameObject forwardTile;
    public GameObject[] tilesPrefabs = new GameObject[2];
    float time;
    
    
    // Start is called before the first frame update
    //how to create a singlerton

    private static TileSpawnManager instance; // Declaration of a singleton

    //static TileSpawnManager Instance { get => instance;  }
    /*private void Awake()
    {
        //singleton
        if(instance == null)
        {
            instance = this;
        }
       

    }*/
    public static TileSpawnManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TileSpawnManager>();
            }
            return instance;
        }
        
    }
    void Start()
    {
        
       // Instantiate(rightTile,currentTile.transform.GetChild(1).position,Quaternion.identity);
       for(int i = 0; i < 20; i++)
        {
            SpawnTile();

        }

    }
    
    public void SpawnTile()
    {
        int index = Random.Range(0, 10);
        if(index == 2)
        {
            currentTile.transform.GetChild(3).gameObject.SetActive(true);
        }
        int k = Random.Range(0, 2);
        currentTile = Instantiate(tilesPrefabs[k], currentTile.transform.GetChild(k).position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if(time > 5f)
        {
            Destroy(currentTile);
        }
    }
    
   
}
