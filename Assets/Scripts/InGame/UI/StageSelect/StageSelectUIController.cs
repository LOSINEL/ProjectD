using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.InGame.UI.StageSelect
{
    public class StageSelectUIController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _stageSelectUI;

        [SerializeField]
        private Image _stagePreviewImage;
        [SerializeField]
        private Text _stageInformationText;

        [SerializeField]
        private List<StageMetadata> _stageMetadataList;

        private StageEnum _selectStageName;

        public bool IsStageSelectUIOpen
        {
            get { return _stageSelectUI.activeSelf; }
        }

        void Start() 
        {
        }

        public void OpenStageSelectUI()
        {
            _stageSelectUI.SetActive(true);
        }

        public void CloseStageSelectUI()
        {
            _stageSelectUI.SetActive(false);
        }

        public void SelectStage(StageEnum stageName)
        {
            _selectStageName = stageName;
            ShowStagePreviewImage();
            ShowStageInformation();
        }

        private void ShowStagePreviewImage()
        {
            _stagePreviewImage.sprite = GetSelectedStagePreviewImage();
        }

        private Sprite GetSelectedStagePreviewImage()
        {
            return _stageMetadataList.Find(x => x.stageName == _selectStageName).previewImage;
        }

        private void ShowStageInformation()
        {
            _stageInformationText.text = GetSelectedStageInformation();
        }

        private string GetSelectedStageInformation()
        {
            return _stageMetadataList.Find(x => x.stageName == _selectStageName).information;
        }

        public void ChangeSceneToSelectedStage() { }
    }
}
