using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotKeyCycle<T> : MonoBehaviour
{
    T[] obj;
    int index;
    int prev;
    int next;

    // Use this for initialization
    public HotKeyCycle(T[] list)
    {
        obj = list;
        index = 0;
        next = index + 1;
        prev = list.Length - 1 <= 0 ? next : list.Length - 1;
    }

    public void Next()
    {
        index = next;
        next = index + 1 > obj.Length - 1 ? 0 : next + 1;
        prev = prev + 1 > obj.Length - 1 ? 0 : prev + 1;
    }
    public void Prev()
    {
        index = prev;
        next = next - 1 < 0 ? obj.Length - 1 : next - 1;
        prev = index == 0 ? obj.Length - 1 : prev - 1;
    }
    public T Current()
    {
        return obj[index];
    }
    public int GetIndex()
    {
        return index;
    }
    public void SetIndex(int i)
    {
        index = i;
        next = index + 1 > obj.Length - 1 ? 0 : index + 1;
        prev = index == 0 ? obj.Length - 1 : index - 1;
    }

}