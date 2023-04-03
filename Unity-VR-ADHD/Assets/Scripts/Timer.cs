using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private static float start = 0.0f;
    private static float time = 0.0f;
    private static float end = 0.0f;
    private static bool isTiming = false;
    public static void StartTime(){
        start = Time.time;
        isTiming = true;
    }

    public static void StopTime(){
        end = Time.time;
        time = Time.time - end;
        isTiming = false;
        Logger log = new Logger("Timer");
        time = end - start;
        log.Log(start.ToString(), end.ToString(), time.ToString());
    }

    public static int GetTime(){
        return (int) time;
    }

    public static bool IsTiming(){
        return isTiming;
    }
}
