/*
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public static bool isInteracting = false;
    public void Setup (int score){
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isInteracting = true;
    }

    public void RestartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Map_Hosp1", LoadSceneMode.Single);
        print("The button is working");
    }
}
*/

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public static bool isInteracting = false;
    public CharacterController playerController; // Reference to the CharacterController component
    private Vector3 initialPlayerPosition; // Store the initial player position

    private void Awake()
    {
        // Store the initial player position
        initialPlayerPosition = playerController.transform.position;
    }

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isInteracting = true;
    }

    public void RestartGame()
    {
        // Reset the player's position to the initial position
        ResetPlayerPosition();

        // Reload the scene
        SceneManager.LoadScene("Map_Hosp1", LoadSceneMode.Single);

        print("The button is working");
    }

    private void ResetPlayerPosition()
    {
        // Set the player's position to the initial position
        playerController.transform.position = initialPlayerPosition;
    }
}