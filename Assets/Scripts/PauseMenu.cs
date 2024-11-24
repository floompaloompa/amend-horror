using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{


    [SerializeField] public Player myPlayer;
    [SerializeField] public int goal;


    [SerializeField] public TMPro.TextMeshProUGUI Stats;
    // Start is called before the first frame update

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }

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

    public void Resume() {
        GameIsPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }
    public void Pause() {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
        

    }
    public void GoToMainMenu() {
        SceneManager.LoadSceneAsync(0);
        

    }
    public void Quit() {
        Application.Quit();
        

    }
}
