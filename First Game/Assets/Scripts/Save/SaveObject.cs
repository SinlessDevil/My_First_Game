using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject : MonoBehaviour
{
    // ������ �� ����� �������� �� ����� ��� �������� ������
    public List<GameObject> applesInStart;

    void Start()
    {
        // ������� ��� ������ �� �����
        applesInStart = new List<GameObject>(GameObject.FindGameObjectsWithTag("Drop"));
        // ��������� ��������� ��������� �����
        load();
    }

    public void load()
    {
        // ���� ������ � ����������� ����� ��� ���������, �� ������� �� ������,
        // ������ �������� � ���������� ������ ����� 0.
        string applesStatePrefs = PlayerPrefs.GetString("appleStates");
        if (applesStatePrefs.Length != 0)
        {
            for (int i = 0; i < applesStatePrefs.Length; i++)
            {
                if (applesStatePrefs[i] == '0') Destroy(applesInStart[i]);
            }
        }
    }

    public void save()
    {
        // ����������� �� ������� ����� � ������ ������, � ������� 0 - ������ ��� ���, 1 - ������ ����
        // � ��������� ��� ������
        string appleStates = "";
        for (int i = 0; i < applesInStart.Count; i++)
        {
            if (applesInStart[i] != null) appleStates += "1";
            else appleStates += "0";
        }

        PlayerPrefs.SetString("appleStates", appleStates);
    }

    // ��� �����
    [ContextMenu("clear")]
   public void crearPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
