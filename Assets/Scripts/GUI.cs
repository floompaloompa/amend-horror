using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GUI : MonoBehaviour
{


    [SerializeField] public Player myPlayer;
    [SerializeField] public int goal;


    [SerializeField] public TMPro.TextMeshProUGUI Stats;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.transform.position);
        Debug.Log(Stats.transform.position);
        Vector3 cameraPosition = Camera.main.ScreenToViewportPoint(new Vector3 (0, Camera.main.pixelHeight, 0));
        Stats.transform.position = cameraPosition;
        

        Debug.Log(this.transform.position);
        Debug.Log(Stats.transform.position);
        
        var height = Camera.main.orthographicSize * 2f;
        //Debug.Log(height);
        //Stats.transform.position = new Vector3(0, 1, 0);
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (myPlayer.cells >= goal) {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
            if(currentScene > 2) {
                SceneManager.LoadScene("InitScene");
            } else {
                SceneManager.LoadScene(currentScene + 1);
            }
        
        
        }
            
        Stats.SetText("Petri dishes: " + myPlayer.dishes_stored + 
        ", Cell cultures: " + myPlayer.cells_stored+ 
        ", Cells: " + myPlayer.cells + "/" + goal);
    }
}
