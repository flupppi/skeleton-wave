using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseDisplay : MonoBehaviour
{
    Pose mPose;

    public void setPose(Pose pose)
    {
        mPose = pose;
    }



    public void setHorizontalPosition(float x)
    {
        transform.position = new Vector3(x*4, 0, 0);
    }

}
