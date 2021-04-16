using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMoarCats : MonoBehaviour
{
    public GameObject someCats;
    public GameObject moreCats;
    public GameObject allTheCats;


    public void ChangeBox(TMP_Dropdown catBox)
    {
        someCats.SetActive(catBox.value >= 1);
        moreCats.SetActive(catBox.value >= 2);
        allTheCats.SetActive(catBox.value >= 3);
    }


}
