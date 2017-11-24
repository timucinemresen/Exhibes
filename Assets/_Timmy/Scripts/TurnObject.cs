using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObject : MonoBehaviour
{
    public bool IsUpping;

    private void Start()
    {
        IsUpping = true;
    }

    void Update () {
        ObjectRotater();
    }

    private void ObjectRotater()
    {
        if (this.gameObject.CompareTag("DonenTop"))
        {
            this.transform.Rotate(Vector3.forward * Time.deltaTime * 15f);
            if (IsUpping)
            {
                this.transform.position += new Vector3(0, Time.deltaTime *0.5f, 0);
            }
            else
            {
                this.transform.position -= new Vector3(0, Time.deltaTime*0.5f, 0);
            }

            if (this.transform.localPosition.y > 1.6f)
            {
                IsUpping = false;
            } 
            else if (this.transform.localPosition.y < 1f)
            {
                IsUpping = true;
            }
        }
        else if (this.gameObject.CompareTag("DonenHalkaBuyuk"))
        {
            this.transform.Rotate(Vector3.up * Time.deltaTime * 20);
        }
        else if (this.gameObject.CompareTag("DonenHalkaKucuk"))
        {
            this.transform.Rotate(Vector3.up * Time.deltaTime * 30);
        }
        else
        {
            Debug.LogError("Tag bulunamadı.");
        }
    }
}
