using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnColor : MonoBehaviour
{
    private float timer = 0.18f;
    private Light lighting;
    private Color mainColor = Color.white;

    private void Start()
    {
        lighting = this.GetComponent<Light>();
    }

    private void Update()
    {
        lighting.color = mainColor;
        mainColor = Color.Lerp(Color.white, Color.blue, Mathf.PingPong(Time.time * timer, 1));
    }
}
