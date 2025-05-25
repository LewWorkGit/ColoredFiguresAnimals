using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FigureTypeSwitcher : MonoBehaviour
{
    [Inject] private FigureSpawner figureSpawner;
    [SerializeField] private Color[] figureColors;
    [SerializeField] private Sprite[] animalSprites;
    private List<GameObject> emptyFigureList = new List<GameObject>();

    private void Awake()
    {
        CreateFigureList();
        SwitchType();
    }

    public void SwitchType()
    {
        //получаем рандомные индексы цвета и спрайта, запоминаем тег(форму) фигуры
        int colorIndex = Random.Range(0, figureColors.Length);
        int spriteIndex = Random.Range(0, animalSprites.Length);
        string tagFigure = emptyFigureList[emptyFigureList.Count - 1].tag; ;

        //перебираем лист с пустыми фигурами с конца списка, присваиваем одинаковый цвет и картинку трём одинаковым фигурам, удоляем их из списка   
        for (int i = emptyFigureList.Count, j = 0; j < 3 && i > 0; i--)
        {
            if (emptyFigureList[i-1].tag == tagFigure)
            {
                FigureTypeProperties figureType = emptyFigureList[i - 1].GetComponent<FigureTypeProperties>();
                
                figureType.SetColor(figureColors[colorIndex]);
                figureType.SetAnimalImage(animalSprites[spriteIndex]);
                emptyFigureList.Remove(emptyFigureList[i - 1]);
                j++;
                
            }

        }

        //если список пуст, запускаем спавн фигур, если нет то рандомно меняем тип следующих 3-х фигур
        if (emptyFigureList.Count > 0)
        {
            SwitchType();
        }
        else
        {
            figureSpawner.SpawnFigure();
        }
    }

    public void CreateFigureList()
    {
        //заполняем список фигурами     
        emptyFigureList.AddRange(figureSpawner.figurePool);
    }

}
