using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class BoneTransform
{
    public string boneName = "";
    public Vector3 position = new Vector3();
    public Quaternion rotation = new Quaternion();


    public BoneTransform(string name, Vector3 pos, Quaternion rot)
    {
        boneName = name;
        position = pos;
        rotation = rot;
    }
}

