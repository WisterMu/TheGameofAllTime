using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class Director : MonoBehaviour
{

    public PlayableDirector timeline;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to timeline events
        timeline.stopped += OnTimelineStopped;
        timeline.played += OnTimelinePlayed;

        // Start timeline
        timeline.Play();
    }

    void OnTimelinePlayed(PlayableDirector director)
    {
        // Actions to perform when the timeline starts
    }

    void OnTimelineStopped(PlayableDirector director)
    {
        // Example scene change based on timeline end
        ChangeScene("SampleScene 1");
    }

    public void ChangeScene(string sceneName)
    {
        // Unload current scene and load the new one
        StartCoroutine(LoadScene(sceneName));
    }

    System.Collections.IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
