using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    public static UpdateManager instance;

    List<IUpdate> updateList = new();
    List<IUpdateUI> updateListUI = new();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(ManagedUpdateUI());
    }

    IEnumerator ManagedUpdateUI()
    {
        WaitForSeconds waitTime = new(Nums.uiDeltaTime);
        while (true)
        {
            foreach (IUpdateUI tmp in updateListUI)
            {
                if (tmp == null)
                {
                    RemoveUpdateUI(tmp);
                    continue;
                }
                tmp.ManagedUpdateUI();
            }
            yield return waitTime;
        }
    }

    private void Update()
    {
        foreach (IUpdate tmp in updateList)
        {
            if (tmp == null)
            {
                RemoveUpdate(tmp);
                continue;
            }
            tmp.ManagedUpdate();
        }
    }

    public void AddUpdate(IUpdate update) => updateList.Add(update);
    public void AddUpdateUI(IUpdateUI updateUI) => updateListUI.Add(updateUI);
    void RemoveUpdate(IUpdate update) => updateList.Remove(update);
    void RemoveUpdateUI(IUpdateUI updateUI) => updateListUI.Remove(updateUI);
}

public interface IUpdate
{
    public virtual void Register() => UpdateManager.instance.AddUpdate(this);
    public void ManagedUpdate();
}

public interface IUpdateUI
{
    public virtual void Register() => UpdateManager.instance.AddUpdateUI(this);
    public void ManagedUpdateUI();
}