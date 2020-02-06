using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface FarmElement
{
    void DoTask();
}

public enum FarmItem
{
   Water,
   Harvest,
   Plough,
   Seed,
   Food,
   Pesticide,
}