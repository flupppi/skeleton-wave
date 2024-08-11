using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;



public class SongPlayer : MonoBehaviour
{
    public PoseDisplay poseDisplayPrefab;
    public AudioSource songAudio;
    public Song cSong;
    public PoseEvaluator evaluator;
    public EndScreenDisplay endScreen;
    public Transform displaysNode;
    public List<PoseDisplay> poseDisplays;
    public UnityEvent bigBeat;
    public UnityEvent smallBeat;

    private bool isPlaying = false;
    private float timer;
    private float bigBeatcountDown;
    private float smallBeatcountDown;
    private int nextPoseIndex = 0;
    private GameStats gameStats;

    
    void Start()
    {
        gameStats = new GameStats(cSong);
        loadSong();
        prepareSong();
        startSong();
    }


    void Update()
    {
        if (!isPlaying) return;
        if (timer >= cSong.taktung * cSong.poses.Count + cSong.endDelay)
        {
            finishSong();
        }


        timer += Time.deltaTime;
        bigBeatcountDown -= Time.deltaTime;
        smallBeatcountDown -= Time.deltaTime;
        if (bigBeatcountDown <= 0)
        {
            bigBeat.Invoke();
            bigBeatcountDown = cSong.taktung;
            smallBeatcountDown = cSong.unterTaktung;
            doEvaluation();
        }
        if (smallBeatcountDown <= 0)
        {
            smallBeat.Invoke();
            smallBeatcountDown = cSong.unterTaktung;
        }

        for (int i=0;i<poseDisplays.Count;i++)
        {
            PoseDisplay poseDisplay = poseDisplays[i];
            poseDisplay.setHorizontalPosition((i - (timer / cSong.taktung)));
        }

    }

    public void loadSong()
    {
        cSong.poseCollection = GameManager.Instance.GetDanceDifficulty();
        cSong.soundFile = GameManager.Instance.GetSongDifficulty();
    }

    public void restart()
    {
        gameStats = new GameStats(cSong);
        songAudio.Stop();
        smallBeatcountDown = 0;
        Debug.Log("loading Pose");
        foreach (Transform t in evaluator.rootBoneTransform.GetComponentsInChildren<Transform>())
        {
            BoneTransform currentBoneTransform = cSong.poses[0].joints.Find(b => b.boneName == t.name);
            t.localPosition = currentBoneTransform.position;
            t.localRotation = currentBoneTransform.rotation;
        }

        foreach(PoseDisplay poseDisplay in poseDisplays) {
            poseDisplay.reset();
        }
        nextPoseIndex = 0;

        startSong();
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void doEvaluation()
    {
        if (nextPoseIndex >= cSong.poses.Count) return;
        PoseEvaluationResult result = evaluator.evaluatePose(cSong.poses[nextPoseIndex]);
        poseDisplays[nextPoseIndex].setEvaluation(result);
        gameStats.score += result.score;
        gameStats.countUpEvaluation(result.identifier);
        nextPoseIndex++;
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
            bigBeat.AddListener(nPoseDisplay.OnBigBeat);
            nPoseDisplay.setPose(pose);
            poseDisplays.Add(nPoseDisplay);
        }
        songAudio.clip = cSong.soundFile;

        Debug.Log("loading Pose");
        foreach (Transform t in evaluator.rootBoneTransform.GetComponentsInChildren<Transform>())
        {
            BoneTransform currentBoneTransform = cSong.poses[0].joints.Find(b => b.boneName == t.name);
            t.localPosition = currentBoneTransform.position;
            t.localRotation = currentBoneTransform.rotation;
        }
    }

    public void startSong()
    {
        isPlaying = true;
        timer = -cSong.startDelay;
        bigBeatcountDown = cSong.startDelay;
        songAudio.Play();
        endScreen.hide();
    }

    public void interruptSong()
    {
        isPlaying = false;
        songAudio.Pause();
    }

    public void resumeSong()
    {
        isPlaying = true;
        songAudio.UnPause();

    }

    public void finishSong()
    {
        isPlaying = false;
        //show endscreen
        endScreen.show(gameStats);
    }


}
