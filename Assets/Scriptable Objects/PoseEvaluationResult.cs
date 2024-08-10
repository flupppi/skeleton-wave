using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pose Evaluation Result", menuName = "ScriptableObjects/PoseEvaluationResult", order = 1)]

public class PoseEvaluationResult : ScriptableObject
{
    public string identifier;
    public Color color;
    public Sprite sprite;
    public AudioClip sound;
}
