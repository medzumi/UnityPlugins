using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CustomId
{
    [SerializeField]
    private string currentId;

    public string CurrentId;

    [SerializeField]
    private CustomIdArray array;
}
