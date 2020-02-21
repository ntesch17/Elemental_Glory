using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyKeyValuePair<KEY,VALUE1,VALUE2> : MonoBehaviour
{
    KEY key;
    VALUE1 value1;
    VALUE2 value2;
        public MyKeyValuePair(KEY k, VALUE1 v1, VALUE2 v2)
        {
        key = k;
        value1 = v1;
        value2 = v2;
        }

    public KEY GetKey()
    {
        return key;
    }
    public VALUE1 GetValue1()
    {
        return value1;
    }
    public VALUE2 GetValue2()
    {
        return value2;
    }
    public void SetValue1(VALUE1 v1)
    {
        value1 = v1;
    }
    public void SetValue2(VALUE2 v1)
    {
        value2 = v1;
    }
}
