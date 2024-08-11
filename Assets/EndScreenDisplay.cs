using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenDisplay : MonoBehaviour
{
    public TMP_Text scoreDisplay;
    public Transform evaluationCountDisplaysParent;
    public Transform schildGeist;
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


        schildGeist.gameObject.SetActive(true);
        if(2*(stats.evaluationCounts["bad"]+ stats.evaluationCounts["terrible"])>=stats.totalPoses)
        {
            schildGeist.Find("youre really bad").gameObject.SetActive(true);
        } else if(3* stats.evaluationCounts["perfect"]>= stats.totalPoses)
        {
            schildGeist.Find("deadly moves").gameObject.SetActive(true);
        }
        else if (2 * (stats.evaluationCounts["perfect"] + stats.evaluationCounts["awesome"]) >= stats.totalPoses)
        {
            schildGeist.Find("youre great").gameObject.SetActive(true);
        }
        else if (2 * (stats.evaluationCounts["perfect"] + stats.evaluationCounts["awesome"]+ stats.evaluationCounts["good"]) >= stats.totalPoses)
        {
            schildGeist.Find("spooky moves").gameObject.SetActive(true);
        }
        else if (2 * (stats.evaluationCounts["perfect"] + stats.evaluationCounts["awesome"]+ stats.evaluationCounts["good"] + stats.evaluationCounts["okay"]) >= stats.totalPoses)
        {
            schildGeist.Find("cracking moves").gameObject.SetActive(true);
        }
    }


    public void hide()
    {
        gameObject.SetActive(false);
        schildGeist.gameObject.SetActive(false);
        schildGeist.Find("cracking moves").gameObject.SetActive(false);
        schildGeist.Find("spooky moves").gameObject.SetActive(false);
        schildGeist.Find("deadly moves").gameObject.SetActive(false);
        schildGeist.Find("youre great").gameObject.SetActive(false);
        schildGeist.Find("youre really bad").gameObject.SetActive(false);

    }
}
