using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AfterHoleMenu : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    public void showAndUpdate(int strokes)
    {
        text.text = "Hole in " + strokes.ToString();
        gameObject.SetActive(true);
        StartCoroutine(passiveMe(5));
    }

    IEnumerator passiveMe(int secs)
    {
        yield return new WaitForSeconds(secs);
        gameObject.SetActive(false);
    }
}
