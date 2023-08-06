using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.InGame.UI.StageSelect
{
    public class StageButton : MonoBehaviour
    {
        private Image _stageButtonImage;
        private Button _stageButton;
        [SerializeField]
        private StageSelectUIController _stageSelectUIController;
        [SerializeField]
        private StageNumber _stageEnum;

        public void Start()
        {
            _stageButtonImage = GetComponent<Image>();
            _stageButton = GetComponent<Button>();

            _stageButton.onClick.AddListener(() => {
                _stageSelectUIController.SelectStage(_stageEnum);
            });
        }
    }
}
