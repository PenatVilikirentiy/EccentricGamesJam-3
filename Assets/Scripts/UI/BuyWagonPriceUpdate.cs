using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyWagonPriceUpdate : MonoBehaviour
{
    public Text CurrentWagonprice;
    void Start()
    {
        CurrentWagonprice.text = ("" + Train.Instance.TrainWagonsNumber * Train.Instance.TrainWagonPrice);
    }

    public void UpdateCurrentWagonprice() {
        CurrentWagonprice.text = ("" + Train.Instance.TrainWagonsNumber * Train.Instance.TrainWagonPrice);
    }

}
