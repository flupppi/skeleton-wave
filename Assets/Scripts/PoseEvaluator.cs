using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseEvaluator : MonoBehaviour
{
    public Transform rootBoneTransform = null;
    public Transform musterBeispielRootBone = null;
    public Transform musterBeispielParent = null;

    public List<PoseEvaluationResult> outcomes;
    public List<float> thresholds;

    private float vorlageCooldown = -1f;
    // Start is called before the first frame update
    void Start()
    {
        musterBeispielParent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (vorlageCooldown >= 0)
        {
            vorlageCooldown -= Time.deltaTime;
            if (vorlageCooldown < 0)
            {
                musterBeispielParent.gameObject.SetActive(false);
            }
        }
    }

    public PoseEvaluationResult evaluatePose(Pose vorlage)
    {
        displayVorlage(vorlage);
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

    private void displayVorlage(Pose vorlage)
    {
        //Debug.Log("loading Pose");
        foreach (Transform t in musterBeispielRootBone.GetComponentsInChildren<Transform>())
        {
            BoneTransform currentBoneTransform = vorlage.joints.Find(b => b.boneName == t.name);
            t.localPosition = currentBoneTransform.position;
            t.localRotation = currentBoneTransform.rotation;
        }
        vorlageCooldown = 0.5f;
        musterBeispielParent.gameObject.SetActive(true);

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
