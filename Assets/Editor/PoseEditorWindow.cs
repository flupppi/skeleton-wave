using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseEditorWindow : EditorWindow
{
    private PoseCollection poseCollection;
    private Transform rootBone;

    [MenuItem("Window/Pose Editor")]
    public static void ShowWindow()
    {
        GetWindow<PoseEditorWindow>("Pose Editor");
    }

    private void OnGUI()
    {
        GUILayout.Label("Pose Editor", EditorStyles.boldLabel);

        rootBone = (Transform)EditorGUILayout.ObjectField("Root Bone", rootBone, typeof(Transform), true);
        poseCollection = (PoseCollection)EditorGUILayout.ObjectField("Pose Collection", poseCollection, typeof(PoseCollection), false);

        if (GUILayout.Button("Capture Pose"))
        {
            if (rootBone != null && poseCollection != null)
            {
                CaptureAndSavePose();
            }
            else
            {
                Debug.LogWarning("Root Bone and Pose Collection must be assigned.");
            }
        }

        if (GUILayout.Button("Clear Pose Collection"))
        {
            if (poseCollection != null)
            {
                poseCollection.poses.Clear();
            }
        }

        if (GUILayout.Button("Save"))
        {
            EditorUtility.SetDirty(poseCollection);
            AssetDatabase.SaveAssets();
            Debug.Log("Pose Collection saved.");
        }
    }

    private void CaptureAndSavePose()
    {
        Pose newPose = new Pose();

        foreach (Transform child in rootBone.GetComponentsInChildren<Transform>())
        {
            newPose.joints.Add(new BoneTransform(child.name, child.localPosition, child.localRotation));
        }

        newPose.poseName = "Pose_" + poseCollection.poses.Count;

        poseCollection.poses.Add(newPose);
        Debug.Log("Pose captured and added to collection.");
    }
}
