using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InGame.UI.GameSettings
{
    public abstract class AbstractGameSettingController : MonoBehaviour
    {
        [SerializeField]
        protected Enums.GAME_SETTING_TYPE _settingType;

        protected void Start()
        {
            AddListener();
            Initialize();
        }

        protected abstract void AddListener();

        protected abstract void Initialize();

        public Enums.GAME_SETTING_TYPE GetGameSettingType()
        {
            return this._settingType;
        }
    }
}
