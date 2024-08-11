using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichtManager : MonoBehaviour
{
    public List<SpriteRenderer> lichter;

    public int cIndex=0;

    // Start is called before the first frame update
    void Start()
    {
        foreach(SpriteRenderer licht in lichter)
        {
            licht.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBigBeat()
    {
        int randInt = Random.Range(0, lichter.Count - 1);
        if (randInt >= cIndex) randInt++;
        lichter[cIndex].enabled = false;
        cIndex = randInt;
        lichter[cIndex].enabled = true;
    }
}
