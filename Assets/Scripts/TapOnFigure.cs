using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class TapOnFigure : MonoBehaviour, IPointerDownHandler
{
    [Inject] private FigureSpawner figureSpawner;
    [Inject] private ActionBar actionBar;

    private float moveDuration = 0.5f;
    private  int maxSlots = 7;


    //тап по фигуре
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (actionBar.GetSlotCount() < maxSlots)
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().simulated = false;
            figureSpawner.figurePool.Remove(gameObject);


            transform.rotation = Quaternion.Euler(Vector3.zero);
            transform.DOMove(actionBar.GetEmptySlotPosition(), moveDuration)
                .OnComplete(() =>
                {
                    actionBar.CheckActionBar();
                });
            actionBar.AddFigureToSlot(gameObject);
        }
    }
}
