using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenDisplay : MonoBehaviour
{
    public TMP_Text scoreDisplay;
    public Transform evaluationCountDisplaysParent;
    public List<TMP_Text> evaluationCountDisplays;
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
        evaluationCountDisplays[0].text = "" + stats.evaluationCounts["perfect"];
        evaluationCountDisplays[1].text = "" + stats.evaluationCounts["awesome"];
        evaluationCountDisplays[2].text = "" + stats.evaluationCounts["good"];
        evaluationCountDisplays[3].text = "" + stats.evaluationCounts["okay"];
        evaluationCountDisplays[4].text = "" + stats.evaluationCounts["bad"];
        evaluationCountDisplays[5].text = "" + stats.evaluationCounts["terrible"];

    }


    public void hide()
    {
        gameObject.SetActive(false);
    }
}
