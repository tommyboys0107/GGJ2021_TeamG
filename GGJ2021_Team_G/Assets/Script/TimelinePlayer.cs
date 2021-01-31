using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public static class TimelinePlayer
{
    static bool hasChangeDimension = false;

    public static void PlayEntry()
    {
        PlayableDirector playableDirector = GameObject.Find("EntryTimeline").GetComponent<PlayableDirector>();
        playableDirector.Play();
    }

    public static void PlayDimension()
    {
        PlayableDirector playableDirector = GameObject.Find("DimensionTimeline").GetComponent<PlayableDirector>();
        playableDirector.Play();
        hasChangeDimension = true;
    }

    public static void PlayFocus()
    {
        if (!hasChangeDimension)
            return;

        PlayableDirector playableDirector = GameObject.Find("FocusTimeline").GetComponent<PlayableDirector>();
        playableDirector.Play();
    }

    public static void PlayReturnNormal()
    {
        if (!hasChangeDimension)
            return;

        PlayableDirector playableDirector = GameObject.Find("ReturnNormalTimeline").GetComponent<PlayableDirector>();
        playableDirector.Play();
    }
}
