using UnityEngine;
using UnityEngine.UI;
public class QuitConfirmation : MonoBehaviour
{
    public GameObject confirmationPanel;
    public Button yesButton;
    public Button noButton;
    void Start()
    {
        HideConfirmation();
    }
    void Update()
    {
        if (confirmationPanel.activeSelf) // Check if the confirmation panel is active
        {
            if (Input.GetKeyDown(KeyCode.Return)) // Enter key press
            {
                // Simulate 'Yes' button click
                yesButton.onClick.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.Escape)) // Escape key press
            {
                // Simulate 'No' button click
                noButton.onClick.Invoke();
            }
        }
        else
        {
            // Show confirmation panel when Escape key is pressed
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ShowConfirmation();
                FreezeGame();
            }
        }
    }
    public void ShowConfirmation()
    {
        confirmationPanel.SetActive(true);
    }
    public void HideConfirmation()
    {
        confirmationPanel.SetActive(false);
        UnfreezeGame();
    }
    void FreezeGame()
    {
        Time.timeScale = 0f; // Freezes the game
    }
    void UnfreezeGame()
    {
        Time.timeScale = 1f; // Unfreezes the game
    }
    public void OnClickYes()
    {
        Application.Quit();
    }
    public void OnClickNo()
    {
        HideConfirmation();
    }
}