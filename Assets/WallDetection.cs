using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class WallDetection : MonoBehaviour
{
    public Text textBox;

    public String hittingWall;
    public String clearedWall;

    private void Start()
    {
        textBox.text = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<WallIdentifier>())
            textBox.text = hittingWall;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<WallIdentifier>())
        {
            textBox.text = clearedWall;
            ClearText();
        }
    }

    async void ClearText()
    {
        await Task.Delay(1800);
        if (textBox.text == clearedWall && textBox != null)
        {
            textBox.text = null;
        }
    }
}
