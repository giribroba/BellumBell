using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    #region Attributes

    protected uint cardId;
    int gold;

    [HideInInspector]
    public CardsInfo initialInfo;

    Vector3 startSize;
    Coroutine changeSizeAnimation, moveToAnimation;

    [Header("UI card references")]
    public Image design;
    public Image backgroundImage, imageShadow, descShadow;

    public Text nameText, descText, lifeText, goldText, powerText;

    [HideInInspector] public Vector2 startPosition, finalPosition;
    [HideInInspector] public Quaternion startAngle, finalAngle;
    [HideInInspector] public int posInHand;


    #endregion

    #region Properties
    protected int Gold
    {
        get => gold;
        set
        {
            gold = value;
            // goldText.text = gold.ToString();
        }
    }
   

    #endregion

    #region Methods

    public virtual void ReceiveStartInfo(CardsInfo info)
    {
        initialInfo = info;

        cardId = info.cardId;
        Gold = info.gold;

        // design.sprite = info.design;

        
        
        // nameText.text = JsonReader.TranslateTo(UserPrefs.lenguage).cards[cardId].name;
        // descText.text = JsonReader.TranslateTo(UserPrefs.lenguage).cards[cardId].description;

    }
    public virtual Card OnHandBoardInstantiate(Transform boardTransform)
    {
        print("some type of card who havent action");
        return null;
    }
    
    public void ChangeSize(float size, float animationSpeed)
    {
        startSize = transform.GetComponent<RectTransform>().localScale;
        if (changeSizeAnimation is not null)
            StopCoroutine(changeSizeAnimation);
        changeSizeAnimation = StartCoroutine(SizeAnimation(size, animationSpeed));
    }
    public void StartToMove(float animationSpeed, float cardXMaxCurve, float cardYMaxCurve)
    {
        if (moveToAnimation is not null) 
            StopCoroutine(moveToAnimation);
        moveToAnimation = StartCoroutine(MoveToAnimation(animationSpeed, cardXMaxCurve, cardYMaxCurve));
    }
    IEnumerator SizeAnimation(float size, float animationSpeed)
    {
        RectTransform rectCard;
        float x, y;
        Vector3 proportion = new Vector3(116,174,1);
        x = 0;
        while (x <= 1)
        {
            x += (animationSpeed * Time.deltaTime);
            y = -x * x + 2 * x;
            rectCard = transform as RectTransform;
            rectCard.localScale = Vector3.Lerp(startSize, proportion * size, y);

            yield return null;
        }
    }
    IEnumerator MoveToAnimation(float animationSpeed, float cardXMaxCurve, float cardYMaxCurve)
    {
        RectTransform rectCard = transform.parent as RectTransform;
        float curvePosX, curvePosY;
        Vector3 finalPositionWithCurve;
        float x, y;

        x = 0;

        while (x <= 1)
        {
            x += (animationSpeed * Time.deltaTime);
            y = -x * x + 2 * x;

            curvePosX = (y * -cardXMaxCurve + finalPosition.x) + cardXMaxCurve;
            curvePosY = (y * -cardYMaxCurve + finalPosition.y) + cardYMaxCurve;
            finalPositionWithCurve = new Vector3(curvePosX, curvePosY);

            rectCard.transform.rotation = Quaternion.Lerp(startAngle, finalAngle, y);
            rectCard.anchoredPosition = Vector3.Lerp(startPosition, finalPositionWithCurve, y);

            yield return null;
        }
    }
    public void SetRaycastGraphic(bool condition)
    {
        transform.parent.GetComponent<Image>().raycastTarget = condition;
    }
    #endregion
}
