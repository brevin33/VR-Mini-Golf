using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuStrokes : MonoBehaviour
{
    public Transform head;
    public float spawnDist = 2;
    public GameObject menu;
    [SerializeField]
    List<TextMeshProUGUI> strokesUIsetup;

    static List<TextMeshProUGUI> strokesUI;

    [SerializeField]
    Button resetButton;

    private void Awake()
    {
        strokesUI = strokesUIsetup; 
        strokesUIsetup = null;
    }

    private void Update()
    {
        menu.transform.position = head.position + new Vector3(head.forward.x,0,head.forward.z).normalized*spawnDist;
        menu.transform.LookAt(new Vector3(head.position.x,menu.transform.position.y,head.position.z));
        menu.transform.forward *= -1;
    }
    public static void updateStrokes(List<int> strokes)
    {
        int total = 0;
        for (int i = 0; i < strokes.Count; i++)
        {
            strokesUI[i].text = strokes[i].ToString();
            total += strokes[i];
        }
        strokesUI[strokes.Count].text = total.ToString();
    }

}
