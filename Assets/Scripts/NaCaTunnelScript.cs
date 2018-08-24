using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaCaTunnelScript : MonoBehaviour
{

    public NatLockScript[] NaScript;
    public CalLockScript[] CalScript;
    public GameObject lowerWall;
    public GameObject upperWall;
    private bool gatheringNat = true;
    public ScoreManagerScript score;


    // Use this for initialization
    void Start()
    {
        /*if(gatheringNat)
            foreach (NatLockScript na in NaScript)
            {
                na.gameObject.SetActive(false);
            }
            */

    }

    // Update is called once per frame
    void Update()
    {
        if (gatheringNat)
        {
            bool isFull = true;
            foreach (NatLockScript na in NaScript)
            {
                isFull = na.locked;
                if (!isFull)
                {
                    return;
                }
            }
            swapMode();
        }
        else
        {
            bool isFull = true;
            foreach (CalLockScript cal in CalScript)
            {
                isFull = cal.locked;
                if (!isFull)
                {
                    return;
                }
            }
            swapMode();
        }
    }

    public void swapMode()
    {
        if (gatheringNat)
        {
            lowerWall.SetActive(false);
            upperWall.SetActive(true);
            foreach (NatLockScript na in NaScript)
            {
                na.Expell(new Vector3(0.0f, 110.0f, 0.0f));
                na.gameObject.SetActive(false);
            }
            foreach (CalLockScript cal in CalScript)
            {
                cal.gameObject.SetActive(true);
            }
        }
        else
        {
            lowerWall.SetActive(false);
            upperWall.SetActive(true);
            foreach (CalLockScript cal in CalScript)
            {
                cal.Expell(new Vector3(0.0f, -110.0f, 0.0f));
                cal.gameObject.SetActive(false);
                lowerWall.SetActive(true);
                upperWall.SetActive(false);
            }
            foreach (NatLockScript na in NaScript)
            {
                na.gameObject.SetActive(true);
            }
        }
        gatheringNat = !gatheringNat;
        score.incrementMultiplier();

    }
}
