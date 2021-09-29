using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Coins
{
    public class CoinsCounter : MonoBehaviour
    {
        public Action<int> AddCoins;
        public Action CoinCountUpdated;
        
        [SerializeField] private int _coins;

        [SerializeField] private GameObject _coinsParrent;
        [SerializeField] private List<Coin> _coinsOnLevel;

        public int CoinsCount => _coins;
        
        private void Start()
        {
            TakeCounterToCoins();
        }

        private void OnEnable()
        {
            AddCoins += OnAddCoins;
        }

        private void OnDisable()
        {
            AddCoins -= OnAddCoins;
        }

        private void OnAddCoins(int amount)
        {
            if(amount <= 0)
                throw new ArgumentOutOfRangeException();

            _coins += amount;
            CoinCountUpdated?.Invoke();
        }

        private void TakeCounterToCoins()
        {
            _coinsOnLevel = _coinsParrent.GetComponentsInChildren<Coin>().ToList();
            
            foreach (var coin in _coinsOnLevel)
            {
                coin.SetCoinCounter(this);
            }
        }
    }
}