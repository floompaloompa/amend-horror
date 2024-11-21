using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{


    [SerializeField] public GameObject petriDish;
    [SerializeField] public GameObject vial;

    public List<Vector3> SpawnPoints; 
    // Start is called before the first frame update
    void Start()
    {

        InitialiseSpawnPoint();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitialiseSpawnPoint()
    {
        var height = Camera.main.orthographicSize * 2f;
        float width = height * Camera.main.aspect;
        //call the function we created
        //Vector3 point = GetRandomSpawnPoint();
        for (int index=0; index < 3; index++) {
            var posX = UnityEngine.Random.Range(-width/2, width/2);
            var posY = UnityEngine.Random.Range(-height/2, height/2);
            Vector3 point = new Vector3(posX, posY, 0);

            //hold the spawn point we create as a reference, you can do stuff with this later or not, it really depends.
            GameObject SpawnPointInstance = Instantiate(petriDish, point, Quaternion.identity);
        }
        for (int index=0; index < 5; index++) {
        var posX = UnityEngine.Random.Range(-width/2, width/2);
            var posY = UnityEngine.Random.Range(-height/2, height/2);
            Vector3 point = new Vector3(posX, posY, 0);

            //hold the spawn point we create as a reference, you can do stuff with this later or not, it really depends.
            GameObject SpawnPointInstance = Instantiate(vial, point, Quaternion.identity);
        }
        
             
    }

 
    /*public Vector3 GetRandomSpawnPoint()
    {
        //if the list isn't initalised for some reason or it has no entries it will default to Vector3.zero
        if (SpawnPoints == null || SpawnPoints.Count == 0)
        {
            return Vector3.zero;
        }

        //otherise this function rolls a random number between 0 and the count of our spawn point list returning whichever random entry it chose
        return SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Count)];
    }*/
}
