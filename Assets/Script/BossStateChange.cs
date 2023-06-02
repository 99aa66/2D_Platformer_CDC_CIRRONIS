using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateChange : MonoBehaviour
{
    private Enemy_Health EH;
    private void Start()
    {
        EH = GetComponentInParent<Enemy_Health>();
    }
    // Update is called once per frame
    void Update()
    {
        if (EH.currentHealth <= EH.healthAmount / 2)
        {
            StartCoroutine(EH.ChangementBoss(2));
            GetComponent<Boss>().enabled = false;
            GetComponent<Boss_Phase2>().enabled = true;
        }
    }
}
