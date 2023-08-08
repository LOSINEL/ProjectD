using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InGame.UI.StageSelect
{
    [SerializeField]
    public enum StageNumber
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
        public StageNumber stageNumber;
        public Sprite previewImage;
        public string information;
        public string stageSceneName;
    }
}
