using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    [SerializeField] private AudioSource _click;

    public void PlaySound()
    {
        _click.Play();
    }
}
