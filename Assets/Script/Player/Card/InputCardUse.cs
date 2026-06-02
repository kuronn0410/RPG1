using UnityEngine;

public class InputCardUse : MonoBehaviour
{


   void Update()
   {
       if (Input.GetKeyDown(KeyCode.Alpha1))
       {
            Debug.Log("Use Card 1");
            UseCard(0);
            

       }
       if(Input.GetKeyDown(KeyCode.Alpha2))
       {
            Debug.Log("Use Card 2");
            UseCard(1);
       }
       if(Input.GetKeyDown(KeyCode.Alpha3))
       {
            Debug.Log("Use Card 3");
            UseCard(2);
       }
       if(Input.GetKeyDown(KeyCode.Alpha4))
       {
            UseCard(3);
       }
       if(Input.GetKeyDown(KeyCode.Alpha5))
       {
            UseCard(4);
       }
    }

    private void UseCard(int cardIndex)
    {
        if (cardIndex < 0 || cardIndex >= CardDeckManager.setcards.Count)
        {
            return;
        }
        CardType cardType = CardDeckManager.setcards[cardIndex];
        CardDeckManager.Instance.RemoveCardFromDeck(cardType);
        CardAbilityManeger.Instance.UseCardAbility(cardType);
        Debug.Log($"Used Card: {cardType}");
    }
}
