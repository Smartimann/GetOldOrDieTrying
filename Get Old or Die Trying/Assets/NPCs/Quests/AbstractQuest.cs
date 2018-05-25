using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AbstractQuest : MonoBehaviour
{
    public abstract void StartQuest();
    public abstract void CheckIfFullfilled();
    public abstract bool GetStatus();
    public abstract string GetName();
    public abstract string GetText();


}
