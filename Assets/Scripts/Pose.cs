using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pose 
{
    public string poseName;
    public List<BoneTransform> joints = new List<BoneTransform>();
}
