//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;  //same as HighScore 

//public class ScoreCounter : MonoBehaviour
//{
//    private TextMeshProUGUI uiText;  
//    [Header("Dynamic")]  
//    public int score = 0; 

//    void Start()
//    {
//        uiText = GetComponent<TextMeshProUGUI>();  
//        if (uiText == null)
//        {
//            Debug.LogError("TextMeshProUGUI component not found on ScoreCounter GameObject!");
//        }
//    }

//    void Update()
//    {
//        uiText.text = score.ToString("#,0");
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Include if using TextMeshPro

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;
    public int currentRound = 1;  // Start with Round 1

    private Text uiText;  // Regular Unity Text
    private TextMeshProUGUI uiTextTMP;  // TextMeshPro Text (optional)
    public Text roundText;  // Reference for regular Unity Text Round
    public TextMeshProUGUI roundTextTMP;  // Reference for TextMeshPro Round Text (optional)

    void Start()
    {
        // Fetch the score text component (UI Text or TextMeshPro)
        uiText = GetComponent<Text>();
        uiTextTMP = GetComponent<TextMeshProUGUI>();

        // Find the RoundText object and set the text reference
        GameObject roundTextGO = GameObject.Find("RoundText");
        roundText = roundTextGO.GetComponent<Text>();
        roundTextTMP = roundTextGO.GetComponent<TextMeshProUGUI>();

        if (uiText == null && uiTextTMP == null)
        {
            Debug.LogError("Neither Text nor TextMeshProUGUI component found on ScoreCounter!");
        }

        // Initialize round display
        UpdateRoundText();
    }

    void Update()
    {
        // Update score display
        if (uiText != null)
        {
            uiText.text = score.ToString("#,0");
        }
        else if (uiTextTMP != null)
        {
            uiTextTMP.text = score.ToString("#,0");
        }

        // Check if it's time to update the round (every 1000 points)
        UpdateRound();
    }

    void UpdateRound()
    {
        int newRound = (score / 1000) + 1;  // Calculate current round based on score
        if (newRound != currentRound)  // If the round has changed
        {
            currentRound = newRound;  // Update the current round
            UpdateRoundText();  // Update the round display on UI
        }
    }

    void UpdateRoundText()
    {
        string roundTextStr = "Round " + currentRound;

        // Update Round Text based on whether you're using Text or TextMeshPro
        if (roundText != null)
        {
            roundText.text = roundTextStr;
        }
        else if (roundTextTMP != null)
        {
            roundTextTMP.text = roundTextStr;
        }
    }
}