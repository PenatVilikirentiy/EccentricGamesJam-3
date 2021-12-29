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
        _coinText.text = ("x" + CoinCount);
        //PlayerPref.DeleteKey("CoinCount")
    }

    public void ChangeValue(int Value) {

        CoinCount = CoinCount + Value;
        _coinText.text = ("x"+ CoinCount);
        PlayerPrefs.SetInt("CoinCount", CoinCount);
    }



}
