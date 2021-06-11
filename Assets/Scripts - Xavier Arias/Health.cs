using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    private TextMeshProUGUI tm;

    private void Start()
    {
        tm = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Face towards the camera
        transform.forward = Camera.main.transform.forward;
    }

    public int Current()
    {
        return tm.text.Length;
    }

    public void Decrease()
    {
        if (Current() > 1)
            tm.text = tm.text.Remove((tm.text.Length - 1));
        else
            Destroy(transform.parent.gameObject);
    }
}
