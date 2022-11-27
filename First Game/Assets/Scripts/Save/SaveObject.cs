using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject : MonoBehaviour
{
    // массив во всеми яблоками на сцене при загрузке уровня
    public List<GameObject> applesInStart;

    void Start()
    {
        // находим все яблоки на сцене
        applesInStart = new List<GameObject>(GameObject.FindGameObjectsWithTag("Drop"));
        // загружаем настройки состояния яблок
        load();
    }

    public void load()
    {
        // если строка с состояниями яблок уже сохранена, то удаляем то яблоко,
        // индекс которого в сохранённой строке равен 0.
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
        // пробегамеся по массиву яблок и создаём строку, в которой 0 - яблока уже нет, 1 - яблоко есть
        // и сохраняем эту строку
        string appleStates = "";
        for (int i = 0; i < applesInStart.Count; i++)
        {
            if (applesInStart[i] != null) appleStates += "1";
            else appleStates += "0";
        }

        PlayerPrefs.SetString("appleStates", appleStates);
    }

    // для теста
    [ContextMenu("clear")]
   public void crearPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
