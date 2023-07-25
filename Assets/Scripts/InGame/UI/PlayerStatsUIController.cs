using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUIController : MonoBehaviour
{
    [SerializeField] Text _atkValue;
    [SerializeField] Text _healthValue;
    [SerializeField] Text _defValue;
    [SerializeField] Text _staminaValue;
    [SerializeField] Text _atkSpeedValue;
    [SerializeField] Text _moveSpeedValue;
    [SerializeField] Text _restoreHealthValue;
    [SerializeField] Text _restoreStaminaValue;
    private IEnumerator _updateStatTextCoroutine;

    private void OnEnable()
    {
        // _updateStatTextCoroutine = UpdateStatTexts();
        // StartCoroutine(_updateStatTextCoroutine);
    }

    private void OnDisable(){
        // StopCoroutine(_updateStatTextCoroutine);
    }

    private IEnumerator UpdateStatTexts()
    {
        Player.PlayerData stats = Player.instance.Data;
        UpgradeManager upgradeStats = UpgradeManager.instance;
        while(true){
            _atkValue.text = $"{stats.Damage}";
            _healthValue.text = $"{stats.MaxHp}";
            _defValue.text = $"{stats.Defense}";
            _staminaValue.text = $"{stats.MaxSp}";
            _atkSpeedValue.text = $"{stats.AttackSpeed}";
            _moveSpeedValue.text = $"{stats.MoveSpeed}";
            _restoreHealthValue.text = $"{upgradeStats.HpRecov}";
            _restoreStaminaValue.text = $"{Nums.basicSpRecovery}";
            yield return new WaitForSeconds(0.05f);
        }
    }
}
