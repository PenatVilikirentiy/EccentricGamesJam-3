using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private Text _coinText;
    public int CoinCount;


    private void Start() {

        CoinCount = PlayerPrefs.GetInt("CoinCount");
        CoinCount += 500;
        _coinText.text = (CoinCount + " x ");
        //PlayerPref.DeleteKey("CoinCount")
    }

    public void ChangeValue(int Value) {

        CoinCount = CoinCount + Value;
        _coinText.text = (CoinCount + " x ");
        PlayerPrefs.SetInt("CoinCount", CoinCount);
    }



}
