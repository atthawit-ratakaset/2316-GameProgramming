using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesText;

    public void UpdateLives(int lives)
    {   
        livesText.text = $"Lives: {lives}";
    }
}
