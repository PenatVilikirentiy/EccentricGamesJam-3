using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTurrets : MonoBehaviour
{
    public void DeleteAllTurrets() {
        PlayerPrefs.DeleteAll();
    }
}
