using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveClub : MonoBehaviour
{
    [SerializeField]
    GameObject largeClub;
    [SerializeField]
    GameObject smallClub;
    [SerializeField]
    GameObject mediumClub;

    public void setLargeClub()
    {
        largeClub.SetActive(true);
        smallClub.SetActive(false);
        mediumClub.SetActive(false);
    }

    public void setSmallClub()
    {
        largeClub.SetActive(false);
        smallClub.SetActive(true);
        mediumClub.SetActive(false);
    }

    public void setMediumClub()
    {
        largeClub.SetActive(false);
        smallClub.SetActive(false);
        mediumClub.SetActive(true);
    }

    public void setClub(int club)
    {
        if (club == 0)
        {
            setLargeClub();
        }
        else if (club == 1)
        {
            setMediumClub();
        }
        else {
            setSmallClub();
        }
    }
}
