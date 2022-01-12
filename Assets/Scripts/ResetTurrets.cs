using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTurrets : MonoBehaviour
{
    [ContextMenu("DeleteAllTurrets")]
    public void DeleteAllTurrets() {
        PlayerPrefs.DeleteAll();

    }
}
