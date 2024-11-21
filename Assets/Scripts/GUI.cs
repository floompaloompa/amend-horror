using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUI : MonoBehaviour
{


    [SerializeField] public Player myPlayer;


    [SerializeField] public TMPro.TextMeshProUGUI Stats;
    // Start is called before the first frame update
    void Start()
    {
        
        var height = Camera.main.orthographicSize * 2f;
        //Debug.Log(height);
        //Stats.transform.position = new Vector3(0, 1, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        Stats.SetText("Petri dishes: " + myPlayer.dishes_stored + 
        ", Cell cultures: " + myPlayer.cells_stored+ 
        ", Cells: " + myPlayer.cells + "/100");
    }
}
