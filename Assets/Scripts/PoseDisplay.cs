using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseDisplay : MonoBehaviour
{
    Pose mPose;
    Animator mAnimator;

    public SpriteRenderer evaluationDisplay;
    public Transform rootBone;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    public void setPose(Pose pose)
    {
        mPose = pose;
        loadPose();
    }

    public void setEvaluation(PoseEvaluationResult evaluation)
    {
        evaluationDisplay.color = evaluation.color;
    }


    public void setHorizontalPosition(float x)
    {
        transform.localPosition = new Vector3(x*4, 0, 0);
        transform.localScale = new Vector3(1, 1, 1)*Mathf.Max(1.0f,(1.5f-Mathf.Abs(x/3)));
    }


    public void OnBigBeat()
    {
        mAnimator.Play("PoseDisplay_Highlight");
    }


    private void loadPose()
    {
        Debug.Log("loading Pose");
        foreach (Transform t in rootBone.GetComponentsInChildren<Transform>())
        {
            BoneTransform currentBoneTransform = mPose.joints.Find(b => b.boneName == t.name);
            t.localPosition = currentBoneTransform.position;
            t.localRotation = currentBoneTransform.rotation;
        }


    }

}
