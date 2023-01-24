using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatValue
{
    private bool asInt;

    public float Value
    {
        get
        {
            return asInt ? (int)statValue : statValue;
        }

        set
        {
            statValue = value;
        }
    }
    
    private float statValue = 0;
    
    public StatValue(bool asInt)
    {
        this.asInt = asInt;
    }
    
    public static StatValue operator+(StatValue first, StatValue second)
    {
        first.statValue += second.statValue;
        return first;
    }
    
    public static StatValue operator-(StatValue first, StatValue second)
    {
        first.statValue -= second.statValue;
        return first;
    }
    
    public static StatValue operator/(StatValue first, StatValue second)
    {
        first.statValue /= second.statValue;
        return first;
    }
    
    public static StatValue operator*(StatValue first, StatValue second)
    {
        first.statValue *= second.statValue;
        return first;
    }
    
    public static StatValue operator%(StatValue first, StatValue second)
    {
        first.statValue %= second.statValue;
        return first;
    }
    
    public static bool operator<(StatValue first, StatValue second)
    {
        return first.statValue < second.statValue;
    }
    
    public static bool operator>(StatValue first, StatValue second)
    {
        return first.statValue > second.statValue;
    }
}
