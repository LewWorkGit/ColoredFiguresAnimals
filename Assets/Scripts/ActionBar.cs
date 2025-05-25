using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class ActionBar : MonoBehaviour
{
    [Inject] private GameOverView gameOverView;
    [Inject] private FigureSpawner figureSpawner;

    public RectTransform[] slotsPosition;
    private GameObject[] slots = new GameObject[7];
    private List<GameObject> checkingSlotsList = new List<GameObject>();

    private int slotCount;

    //добовляет фигуру в пустой слот
    public void AddFigureToSlot(GameObject figure)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                slots[i] = figure;
                return;
            }
        }
    }

    //возваращает первый по списку пустой слот
    public Vector3 GetEmptySlotPosition()
    {
        int emptySlotNumber = 0;


        foreach (var item in slots)
        {
            if (item == null)
            {
                break;
            }
            else
            {
                emptySlotNumber++;
            }
        }

        return slotsPosition[emptySlotNumber].position;
    }
    //возвращает колличество занятых слотов
    public int GetSlotCount()
    {
        slotCount = 0;

        foreach (var item in slots)
        {
            if (item != null)
            {
                slotCount++;
            }
        }

        return slotCount;
    }

    //проверка формы,цвета и картинки у фигур в слотах
    public void CheckActionBar()
    {
        foreach (var item in slots)
        {
            checkingSlotsList.Clear();
           

            if (item == null)
            {
                continue;
            }
            foreach (var item_2 in slots)
            {    

                if (item_2 != null
                     && item.CompareTag(item_2.tag)
                     && item.GetComponent<FigureTypeProperties>().GetColor() == item_2.GetComponent<FigureTypeProperties>().GetColor()
                     && item.GetComponent<FigureTypeProperties>().GetImage() == item_2.GetComponent<FigureTypeProperties>().GetImage())
                {
                    checkingSlotsList.Add(item_2);

                    if (checkingSlotsList.Count == 3)
                    {
                        foreach (var item_3 in checkingSlotsList)
                        {
                            Destroy(item_3);
                        }
                    }
                }
            }
        }
        GameOver();
    }


    //проверяет условия для победы или проигрыша
    private void GameOver()
    {
        if (GetSlotCount() == 7)
        {
            gameOverView.Lose();
        }

        if (figureSpawner.figurePool.Count == 0)
        {
            gameOverView.Win();
        }
    }
}
