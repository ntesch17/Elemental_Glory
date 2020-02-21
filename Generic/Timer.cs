using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float remainingTime;

    public Timer(float time)
    {
        remainingTime = time;
    }

    private void Update()
    {
        
            remainingTime = remainingTime > 0 ? (remainingTime - Time.deltaTime):0;
            print("time remaining " + remainingTime);
    }

    public bool Finished()
    {
        return remainingTime<0;
    }
    public void SetTimer(float time)
    {
        remainingTime = time;
    }
    public float GetRemainingTime()
    {
        return remainingTime;
    }
}
