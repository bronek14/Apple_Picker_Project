using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // had to add because im using TextMesh for gui

public class HighScore : MonoBehaviour
{
    static private Text _UI_TEXT;
    static private TextMeshProUGUI _UI_TMP_TEXT; 
    static private int _SCORE = 0;

    void Awake()
    {
        
        _UI_TEXT = GetComponent<Text>();

        
        _UI_TMP_TEXT = GetComponent<TextMeshProUGUI>();

        if (_UI_TEXT == null && _UI_TMP_TEXT == null)
        {
            Debug.LogError("Neither Text nor TextMeshProUGUI component found on HighScore GameObject!");
        }

        // Load the high score 
        if (PlayerPrefs.HasKey("HighScore"))
        {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }

        // Save the high score 
        PlayerPrefs.SetInt("HighScore", SCORE);
    }

    static public int SCORE
    {
        get { return _SCORE; }
        private set
        {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);

           
            if (_UI_TEXT != null)
            {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
            else if (_UI_TMP_TEXT != null)
            {
                _UI_TMP_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry)
    {
        if (scoreToTry <= SCORE) return; 
        SCORE = scoreToTry; 
    }

    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    private void OnDrawGizmos()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 0); // Resets high score
            Debug.LogWarning("PlayerPrefs HighScore reset to 0");
        }
    }
}

