using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private Text _coinText;
    public int CoinCount;

    public static MoneyManager Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }


    private void Start() {

        CoinCount = PlayerPrefs.GetInt("CoinCount");
        CoinCount += 1000;
        _coinText.text = (CoinCount + " x ");
        //PlayerPref.DeleteKey("CoinCount")
    }

    public void ChangeValue(int Value) {

        CoinCount = CoinCount + Value;
        _coinText.text = (CoinCount + " x ");
        PlayerPrefs.SetInt("CoinCount", CoinCount);
    }



}
