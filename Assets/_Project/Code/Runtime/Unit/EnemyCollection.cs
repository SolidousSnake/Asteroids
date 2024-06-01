using System.Collections.Generic;
using _Project.Code.Runtime.Unit.Enemy.Asteroid;
using UnityEngine;

namespace _Project.Code.Runtime.Unit
{
    public sealed class EnemyCollection
    {
        private readonly List<Asteroid> _enemyList = new();

        public void Add(Asteroid enemy) => _enemyList.Add(enemy);

        public void CleanUp()
        {
            foreach (var enemy in _enemyList)
                if(enemy != null)
                    Object.Destroy(enemy.gameObject);
            
            _enemyList.Clear();
        }
    }
}