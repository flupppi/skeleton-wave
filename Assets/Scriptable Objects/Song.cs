using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Song", menuName = "ScriptableObjects/Song", order = 1)]
public class Song : ScriptableObject
{
    public string identifier;
    public string displayName;
    public AudioClip soundFile;
    public float startDelay;    //Zeit bis zur ersten Pose
    public float taktung;       //Zeit zwischen zwei Posen
    public float unterTaktung;  //passend zum Song für Beat-Animationen und dergleichen
    public float endDelay;
    public List<Pose> poses;

}
