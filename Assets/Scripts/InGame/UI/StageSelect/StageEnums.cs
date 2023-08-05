using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InGame.UI.StageSelect
{
    [SerializeField]
    public enum StageEnum
    {
        Stage1,
        Stage2,
        Stage3,
        Stage4,
        Stage5
    }

    [Serializable]
    public struct StageMetadata
    {
        public StageEnum stageName;
        public Sprite previewImage;
        public string information;
    }
}
