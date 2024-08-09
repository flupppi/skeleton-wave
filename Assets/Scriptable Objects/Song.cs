using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Song", menuName = "ScriptableObjects/Song", order = 1)]
public class Song : ScriptableObject
{
    public string identifier;
    public string displayName;
    public AudioClip soundFile;
    public float startDelay;
    public float taktung;   //Zeit zwischen zwei Posen
    public float endDelay;
    public List<Pose> poses;

}
