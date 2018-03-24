using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

    public float faderTimer;
    private Image fadePanel;
    // Use this for initialization
    void Start ()
    {
        fadePanel = GetComponent<Image>();
        fadePanel.CrossFadeAlpha(0, faderTimer, true);
        Destroy(this.gameObject, faderTimer);
    }
}
