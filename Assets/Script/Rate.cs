using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RateSO", menuName = "ScriptableObjects/RateSO", order = 1)]
public class Rate : ScriptableObject
{
    public RateInfo setRate;
    [HideInInspector]public RateInfo commonRate;
    [HideInInspector] public RateInfo rareRate;
    [HideInInspector] public RateInfo superRareRate;



}
[System.Serializable]
public class RateInfo
{
    public float common;
    public float rare;
    public float superRare;
}