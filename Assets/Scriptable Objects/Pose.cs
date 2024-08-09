using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pose", menuName = "ScriptableObjects/Pose", order = 1)]
public class Pose : ScriptableObject
{
    public string identifier;
    public List<Vector2> joints;
}
