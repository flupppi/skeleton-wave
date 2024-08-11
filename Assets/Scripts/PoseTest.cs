using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseTest : MonoBehaviour
{
    public PoseCollection poseCollection;
    public Transform rootBoneTransform = null;
    public int currentPoseIndex = 0;
    public int maxPoseIndex = 0;

    // Start is called before the first frame update
    void Start()
    {

        
    }



    // Update is called once per frame
    void Update()
    {
        maxPoseIndex = poseCollection.poses.Count-1;
        Pose currentPose = CaptureCurrentPose(rootBoneTransform);

        foreach (var predefinedPose in poseCollection.poses)
        {
            if (ArePosesSimilar(currentPose, predefinedPose, 0.1f, 5f))
            {
                Debug.Log("Pose matched: " + predefinedPose.poseName);
                // Trigger any specific actions based on the pose
            }
        }

    }

    private bool ArePosesSimilar(Pose currentPose, Pose predefinedPose, float positionThreshold, float rotationThreshold)
    {
        foreach (var boneTransform in predefinedPose.joints)
        {
            var currentBoneTransform = currentPose.joints.Find(b => b.boneName == boneTransform.boneName);

            if (currentBoneTransform == null)
                return false;

            if (Vector3.Distance(currentBoneTransform.position, boneTransform.position) > positionThreshold)
                return false;

            if (Quaternion.Angle(currentBoneTransform.rotation, boneTransform.rotation) > rotationThreshold)
                return false;
        }

        return true;
    }

    private Pose CaptureCurrentPose(Transform rootBoneTransform)
    {
        Pose currentPose = new Pose();

        foreach (Transform child in rootBoneTransform.GetComponentsInChildren<Transform>())
        {
            currentPose.joints.Add(new BoneTransform(child.name, child.localPosition, child.localRotation));
        }

        return currentPose;
    }
}
