using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private LivesDisplay livesDisplay;

    private void Start()
    {   
        FindGameManager();
    }

    public void StartGame()
    {   
        _gameManager.LoadNextLevel();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    private void FindGameManager()
    {
        if (_gameManager != null) return;
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnQuit(InputValue value)
    {
        if (!value.isPressed) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
        else
        {
            Debug.Log("Start!");
            StartGame();
        }
    }

}



