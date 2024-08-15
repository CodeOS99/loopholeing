using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public float startTimer = 3.0f; // this will be in seconds
    private bool gameStarted = false;

    private int gameState = 0;
    
    public Canvas canvas;
    private Text text;
    public const float maxTextShowTimer = 4.0f;
    [SerializeField]
    private float textShowTimer = maxTextShowTimer;

    // Start is called before the first frame update
    void Start()
    {
        text = canvas.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            startTimer -= Time.deltaTime;
            if (startTimer <= 0)
            {
                gameStarted = true;
            }

            return;
        }

        if (gameState == 0)
        {
            textShowTimer = maxTextShowTimer;
            text.text = "The green circular TRexes have strong jaws...";
            gameState = -1; // this will prevent the text from showing again
        }
        textShowTimer -= Time.deltaTime;
        if (textShowTimer <= 0)
        {
            text.text = "";
        }
    }

    public void AdvanceState()
    {
        gameState++;
    }
}
