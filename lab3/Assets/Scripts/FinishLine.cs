using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{   
    private GameManager _gameManager;

    private void Start()
    {
        FindGameManager();   
    }

    private void FindGameManager()
    {
        if(_gameManager == null)
        {
            _gameManager = FindObjectOfType<GameManager>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!other.CompareTag("Player")) return;

        FindGameManager();
        _gameManager.TriggerNextScene();

    }
}
