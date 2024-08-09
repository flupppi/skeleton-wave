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

    public void setEvaluation()
    {

    }


    public void setHorizontalPosition(float x)
    {
        transform.localPosition = new Vector3(x*4, 0, 0);
        transform.localScale = new Vector3(1, 1, 1)*Mathf.Max(1.0f,(1.5f-Mathf.Abs(x/3)));
    }

}
