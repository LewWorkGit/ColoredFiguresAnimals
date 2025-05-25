using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class FigureSpawner : MonoBehaviour
{
    public List<GameObject> figurePool = new List<GameObject>();
    private List<GameObject> respawnBuffer = new List<GameObject>();

    [SerializeField] private int spawnDelayMs = 150;


    public async void SpawnFigure()
    {
        //заполнение листа для респавна фигур
        respawnBuffer.Clear();
        respawnBuffer.AddRange(figurePool);

        //деактивация всех фигур в листе
        foreach (var item in respawnBuffer)
        {
            item.SetActive(false);
        }

        // Создание индексов
        int[] indices = new int[respawnBuffer.Count];
        for (int i = 0; i < respawnBuffer.Count; i++) indices[i] = i;

        // Перемешивание
        for (int i = 0; i < respawnBuffer.Count; i++)
        {
            int temp = indices[i];
            int randomIndex = Random.Range(0, respawnBuffer.Count);
            indices[i] = indices[randomIndex];
            indices[randomIndex] = temp;
        }
        //рандомный спавн фигур
        foreach (var item in indices)
        {
            respawnBuffer[item].gameObject.SetActive(true);
            respawnBuffer[item].transform.localPosition = Vector3.zero;
            await Task.Delay(spawnDelayMs);
        }
    }


}
