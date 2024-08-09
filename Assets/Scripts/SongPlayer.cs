using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour
{
    public PoseDisplay poseDisplayPrefab;
    public Song cSong;
    public Transform displaysNode;
    public List<PoseDisplay> poseDisplays;

    private bool isPlaying = false;
    private float timer;

    
    void Start()
    {
        prepareSong();
        startSong();
    }


    void Update()
    {
        if (!isPlaying) return;


        timer += Time.deltaTime;

        for(int i=0;i<poseDisplays.Count;i++)
        {
            PoseDisplay poseDisplay = poseDisplays[i];
            poseDisplay.setHorizontalPosition((i - (timer / cSong.taktung)));
        }

    }

    public void setSong(Song song)
    {
        cSong = song;
    }

    public void prepareSong()
    {
        foreach(Pose pose in cSong.poses)
        {
            PoseDisplay nPoseDisplay=Instantiate(poseDisplayPrefab, displaysNode);
            poseDisplays.Add(nPoseDisplay);
        }
    }

    public void startSong()
    {
        isPlaying = true;
        timer = -cSong.startDelay;

    }

    public void interruptSong()
    {

    }


}
