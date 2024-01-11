using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class GameManager : MonoBehaviour
{

    [SerializeField] BrushController touchControls;
    [SerializeField] MouseControls mouseControls;

    public UnityAction<bool> toggleShooting;

    private float counter;

    private bool gameStarted;



    // Start is called before the first frame update
    void Start()
    {
        toggleShooting?.Invoke(false);
        gameStarted = false;
        counter = 120;
    } 

    private void StartGame() {
        counter = 120;
            toggleShooting?.Invoke(true);
            gameStarted = true;
    } 

    public string GetTimer() {
        int time = (int)counter;
        return time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameStarted) {
            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                
                //Start touch
                if (touch.phase == TouchPhase.Began){
                    StartGame();
                }
            } else if(Input.GetMouseButtonDown(0)){
                StartGame();
            }
        } else {
            counter -= Time.deltaTime;
            if(counter <= 0) {
                toggleShooting?.Invoke(false);
                counter = 0;
            }
        }
    }
}
