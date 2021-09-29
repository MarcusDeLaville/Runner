using System;
using Coins;
using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _amount;
    [SerializeField] private ParticleSystem _pickUpParticle;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private MeshRenderer _model;
    
    private CoinsCounter _coinsCounter;
    private bool _collected = false;
    
    private void OnTriggerEnter(Collider other)
    {
        PickUp();
    }

    private void PickUp()
    {
        if (_collected == false)
        {
            _pickUpParticle.Play(true);
            _audioSource.Play();
            _coinsCounter.AddCoins?.Invoke(_amount);
            _collected = true;
            _model.enabled = false;
            Destroy(gameObject, 1f);
        }
    }

    public void SetCoinCounter(CoinsCounter counter)
    {
        _coinsCounter = counter;
    }

}
