using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoptime : MonoBehaviour
{
    public void Stopthetime() {
        Time.timeScale = 0f;
    }

    public void Resumethetime() {
        Time.timeScale = 1f;
    }
}
