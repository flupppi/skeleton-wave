using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenDisplay : MonoBehaviour
{
    public TMP_Text scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void show(GameStats stats)
    {
        scoreDisplay.text = ""+stats.score;
        gameObject.SetActive(true);
    }
}
