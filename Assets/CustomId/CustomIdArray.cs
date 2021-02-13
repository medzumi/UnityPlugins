using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CustomIdArray : ScriptableObject
{
    [SerializeField]
    private string[] availableIds;

    public string[] AvailableIds => availableIds;
}
