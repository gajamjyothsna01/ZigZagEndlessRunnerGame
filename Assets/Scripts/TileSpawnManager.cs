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
    Stack<GameObject> rightTileStack = new Stack<GameObject>();
    Stack<GameObject> forwardTileStack = new Stack<GameObject>();

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
        //SpawnTile();
        for (int i = 0; i < 10; i++)
        {
            SpawnTile();
        }
        //CreateTile(20);
    }
    
    public void SpawnTile()
    {
        /*int index = Random.Range(0, 10);
        if(index == 2)
        {
            currentTile.transform.GetChild(3).gameObject.SetActive(true);
        }
        int k = Random.Range(0, 2);
        currentTile = Instantiate(tilesPrefabs[k], currentTile.transform.GetChild(k).position, Quaternion.identity);*/

        if(rightTileStack.Count ==0 || forwardTileStack.Count ==0)
        {
            CreateTile(20);
        }
        int k = Random.Range(0, 2);
        if (k == 0 )
        {
           GameObject tempTile = forwardTileStack.Pop();
            tempTile.SetActive(true);
            tempTile.transform.position = currentTile.transform.GetChild(Random.Range(0,2)).position;
            currentTile = tempTile;
        }
        else if (k==1)
        {
            GameObject tempTile = rightTileStack.Pop();
            tempTile.SetActive(true);
            tempTile.transform.position = currentTile.transform.GetChild(Random.Range(0,2)). position;
            currentTile= tempTile;

        }
       
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
    public void CreateTile(int value)
    {
        for (int i = 0; i < value; i++)
        {
            
            //SpawnTile();
            //CreateTile();
            rightTileStack.Push(Instantiate(tilesPrefabs[1]));
            tilesPrefabs[1].SetActive(false);

            forwardTileStack.Push(Instantiate(tilesPrefabs[0]));
            tilesPrefabs[0].SetActive(false);

        }
        

    }
    public void BackToRightPool(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        rightTileStack.Push(obj);
        rightTileStack.Peek().SetActive(false);
        //obj.SetActive(false);

    }
    public void BackToForwardPool(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        forwardTileStack.Push(obj);
        forwardTileStack.Peek().SetActive(false);
        //obj.SetActive(false);

    }

}
