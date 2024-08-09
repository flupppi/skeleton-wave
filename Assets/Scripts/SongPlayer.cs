using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SongPlayer : MonoBehaviour
{
    public PoseDisplay poseDisplayPrefab;
    public Song cSong;
    public Transform displaysNode;
    public List<PoseDisplay> poseDisplays;
    public UnityEvent bigBeat;
    public UnityEvent smallBeat;

    private bool isPlaying = false;
    private float timer;
    private float bigBeatcountDown;
    private float smallBeatcountDown;

    
    void Start()
    {
        prepareSong();
        startSong();
    }


    void Update()
    {
        if (!isPlaying) return;


        timer += Time.deltaTime;
        bigBeatcountDown -= Time.deltaTime;
        smallBeatcountDown -= Time.deltaTime;
        if (bigBeatcountDown <= 0)
        {
            bigBeat.Invoke();
            bigBeatcountDown = cSong.taktung;
        }
        if (smallBeatcountDown <= 0)
        {
            smallBeat.Invoke();
            smallBeatcountDown = cSong.taktung;
        }

        for (int i=0;i<poseDisplays.Count;i++)
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
            nPoseDisplay.transform.localPosition = new Vector3(0, 0, 0);
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
        isPlaying = false;
    }

    public void resumeSong()
    {
        isPlaying = true;
    }


}
