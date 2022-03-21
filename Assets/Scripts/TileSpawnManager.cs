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
    void Start()
    {
        
       // Instantiate(rightTile,currentTile.transform.GetChild(1).position,Quaternion.identity);
       for(int i = 0; i < 20; i++)
        {
            int k = Random.Range(0, 2);
            currentTile = Instantiate(tilesPrefabs[k], currentTile.transform.GetChild(k).position, Quaternion.identity);

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
}
