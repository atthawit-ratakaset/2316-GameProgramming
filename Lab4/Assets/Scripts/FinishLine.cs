using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private const string PlayerTag = "Player";

    private GameManager _gameManager;
    
    // Why are we checking if the player reaches the finish line here? So, we do not
    // have to check for every time the player collides with something for a finish line.
    
    private void Start()
    {
        FindGameManager();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag(PlayerTag)) return;

        FindGameManager();
        _gameManager.LoadNextLevel();
    }

    private void FindGameManager()
    {
        if (_gameManager != null) return;
        _gameManager = FindObjectOfType<GameManager>();
    }
}
