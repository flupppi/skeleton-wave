using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPoseCollection", menuName = "Pose Collection", order = 1)]
public class PoseCollection : ScriptableObject
{

    public List<Pose> poses = new List<Pose>();

}
