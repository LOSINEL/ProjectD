using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        private StageNumber _selectStageNumber;

        public bool IsStageSelectUIOpen
        {
            get { return _stageSelectUI.activeSelf; }
        }

        private void Start()
        {
            Initialize();
        }

        public void OpenStageSelectUI()
        {
            Initialize();
            _stageSelectUI.SetActive(true);
        }

        private void Initialize()
        {
            SelectStage(StageNumber.Stage1);
        }

        public void CloseStageSelectUI()
        {
            _stageSelectUI.SetActive(false);
        }

        public void SelectStage(StageNumber stageNumber)
        {
            _selectStageNumber = stageNumber;
            ShowStagePreviewImage();
            ShowStageInformation();
        }

        private void ShowStagePreviewImage()
        {
            _stagePreviewImage.sprite = GetSelectedStagePreviewImage();
        }

        private Sprite GetSelectedStagePreviewImage()
        {
            return _stageMetadataList.Find(x => x.stageNumber == _selectStageNumber).previewImage;
        }

        private void ShowStageInformation()
        {
            _stageInformationText.text = GetSelectedStageInformation();
        }

        private string GetSelectedStageInformation()
        {
            return _stageMetadataList.Find(x => x.stageNumber == _selectStageNumber).information;
        }

        public void LoadSceneToSelectedStage()
        {
            SceneManager.LoadScene(GetSelectedStageSceneName());
        }

        private string GetSelectedStageSceneName()
        {
            return _stageMetadataList.Find(x => x.stageNumber == _selectStageNumber).stageSceneName;
        }
    }
}
