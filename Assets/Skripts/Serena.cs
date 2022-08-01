using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Serena : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maximumVolume;
    [SerializeField] private float _minimunVolume;

    private AudioSource _audioSource;
    private Coroutine _fadeInJob;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minimunVolume;
        _audioSource.Play();
    }

    public void PlaySerena()
    {
        if (_fadeInJob != null)
        {
            StopCoroutine(_fadeInJob);
        }
        _fadeInJob = StartCoroutine(FadeIn(_maximumVolume));
    }

    public void StopSerena()
    {
        StopCoroutine(_fadeInJob);
        _fadeInJob = StartCoroutine(FadeIn(_minimunVolume));
    }

    private IEnumerator FadeIn(float target)
    {
        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _speed * Time.deltaTime);
            yield return null;
        }
    }
}

