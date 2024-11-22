using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrowingPetri : MonoBehaviour
{
    
    
    public Player myPlayer;
    public float TimeLeft;
    public bool TimerOn = false;

    //public TextMeshPro TimerTxt;
    
    public Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>(); 
        
    }

    void OnMouseDown()
   {

        var state = myAnim.GetFloat("state");
        
        if(myPlayer.cells_stored > 0) {

            if(state <= 1) { 
                myPlayer.cells_stored--;
                myAnim.SetFloat("state", 1.0f); 
                TimeLeft = 3;
                TimerOn = true;
                
            }
            
        }
        if(state > 2) {
                myPlayer.cells += 20;
                myAnim.SetFloat("state", 0f); 
            }
       // Code here is called when the GameObject is clicked on.
   }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            myAnim.SetFloat("state", 1.0f);
        }

        if(TimerOn) {
            if(TimeLeft > 0) {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);

            } else {
                var state = myAnim.GetFloat("state");
                if(state < 2) {
                    myAnim.SetFloat("state", state + 1.0f);
                    TimeLeft = 10;
                } else if(state <3) {
                    myAnim.SetFloat("state", state + 1.0f);
                    TimerOn = false;
                }else {
                    TimeLeft = 0;
                    TimerOn = false;

                }
            }
        }
    }

    void updateTimer(float currentTime) {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime/60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
    }
}
