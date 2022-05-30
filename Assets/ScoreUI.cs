using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI text;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameManager.levitation.ToString() + "\n \n+5\n \n-5";
    }
}
