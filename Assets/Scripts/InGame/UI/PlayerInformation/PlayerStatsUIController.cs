using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUIController : MonoBehaviour
{
    [SerializeField] private Text _atkValue;
    [SerializeField] private Text _healthValue;
    [SerializeField] private Text _defValue;
    [SerializeField] private Text _staminaValue;
    [SerializeField] private Text _atkSpeedValue;
    [SerializeField] private Text _moveSpeedValue;
    [SerializeField] private Text _restoreHealthValue;
    [SerializeField] private Text _restoreStaminaValue;
    [SerializeField] private Text _goldValue;

    private IEnumerator _updateStatTextCoroutine;

    private void OnEnable()
    {
        //_updateStatTextCoroutine = UpdateStatTexts();
        //StartCoroutine(_updateStatTextCoroutine);
    }

    private void OnDisable()
    {
        //StopCoroutine(_updateStatTextCoroutine);
    }

    /// <summary>
    /// TODO<br/>
    /// 씬에 Player가 배치되어 있지 않으면 NullReferenceError를 일으킴.
    /// Player를 배치한 다음 사용할 것.
    /// </summary>
    private IEnumerator UpdateStatTexts()
    {
        Player.PlayerData stats = Player.instance.Data;
        UpgradeManager upgradeStats = UpgradeManager.instance;
        WaitForSeconds waitTime = new WaitForSeconds(Nums.playerInformationUIRefreshTime);
        while (true)
        {
            _atkValue.text = $"{stats.Damage}";
            _healthValue.text = $"{stats.MaxHp}";
            _defValue.text = $"{stats.Defense}";
            _staminaValue.text = $"{stats.MaxSp:F0}";
            _atkSpeedValue.text = $"{stats.AttackSpeed:F0}%";
            _moveSpeedValue.text = $"{stats.MoveSpeed:F0}%";
            _restoreHealthValue.text = $"{upgradeStats.HpRecov}";
            _restoreStaminaValue.text = $"{Nums.staminaRecovery}";
            _goldValue.text = $"{InventoryManager.Instance.Gold}G";
            yield return waitTime;
        }
    }
}
