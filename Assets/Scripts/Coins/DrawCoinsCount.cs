using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Coins
{
    public class DrawCoinsCount : MonoBehaviour
    {
        [SerializeField] private Text _countCoinsText;
        [SerializeField] private CoinsCounter _coinsCounter;

        private void Start()
        {
            DrawCoins();
        }

        private void OnEnable()
        {
            _coinsCounter.CoinCountUpdated += DrawCoins;
        }

        private void OnDisable()
        {
            _coinsCounter.CoinCountUpdated -= DrawCoins;
        }

        private void DrawCoins()
        {
            _countCoinsText.DOText(_coinsCounter.CoinsCount.ToString(), 0.5f, true, ScrambleMode.Numerals);
        }
    }
}