using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace GameScene
{
    public abstract class Player : MonoBehaviour
    {
        [NotNull] [SerializeField] internal List<GameButton> gameButton;
        protected List<Perk> _perksList;
        [NotNull] [SerializeField] internal string _name;

        public string Name
        {
            get { return _name; }
        }


        public abstract void GameButtonActivation();

        internal abstract void PerkActivation();
    }
}