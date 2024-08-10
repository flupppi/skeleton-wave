using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseEvaluator : MonoBehaviour
{
    public Transform rootBoneTransform = null;

    public List<PoseEvaluationResult> outcomes;
    public List<float> thresholds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PoseEvaluationResult evaluatePose(Pose vorlage)
    {
        Pose playerPose = CaptureCurrentPose(rootBoneTransform);

        //best result comes first
        for (int i = 0; i < thresholds.Count; i++)
        {
            if(ArePosesSimilar(playerPose, vorlage, 5, thresholds[i]))
            {
                Debug.Log("Evaluation Result: " + outcomes[i].identifier);
                return outcomes[i];
            }
        }

        return outcomes[outcomes.Count - 1];
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
