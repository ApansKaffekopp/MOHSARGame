using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;



public class GameManager : MonoBehaviour
{

    [SerializeField] BrushController touchControls;
    [SerializeField] MouseControls mouseControls;

    public UnityAction<bool> toggleShooting;

    private float counter;

    private bool gameStarted;

    private bool gameFinished;

    GridColorTracker grid;
    [SerializeField] List<Color> solution;
    List<Color> currentGridColors;

    private double score;

    [SerializeField] GameObject scoreContainer;
    [SerializeField] TMP_Text scoreText;

    [SerializeField] GameObject picture;



    // Start is called before the first frame update
    void Start()
    {
        toggleShooting?.Invoke(false);
        gameStarted = false;
        counter = 120;
        //currentGridColors = grid.GetColorGrid();
        score = 0;
        //picture.SetActive(true);
    } 

    public void StartGame() {
        grid = GameObject.Find("Plane(Clone)").gameObject.GetComponent<GridColorTracker>();
        counter = 120;
        toggleShooting?.Invoke(true);
        gameStarted = true;
        gameFinished = false;
        picture.SetActive(false);
    } 

    public string GetTimer() {
        int time = (int)counter;
        return time.ToString();
    }

    private void CheckScore() {
        currentGridColors = grid.GetColorGrid();
        int correctCubes = 0;
        for(int i = 0; i < solution.Count; i++) {
            if(currentGridColors[i] == solution[i]) {
                correctCubes +=1;
            }
        }
        score = (double)correctCubes/solution.Count;
        scoreText.text = (score*100).ToString("#.0") + "%";
        scoreContainer.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(!gameStarted) {
            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                
                //Start touch
                if (touch.phase == TouchPhase.Began){
                    StartGame();
                }
            } else if(Input.GetMouseButtonDown(0)){
                StartGame();
            }
        } else {*/
            if(!gameFinished && gameStarted) {
                counter -= Time.deltaTime;
            }
            if(counter <= 0 && !gameFinished) {
                toggleShooting?.Invoke(false);
                counter = 0;
                CheckScore();
                gameFinished = true;
            }
        //}
    }
}
