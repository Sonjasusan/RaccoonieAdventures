using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    //XP
    public class XPAddedGameEvent : GameEvent
    {
        public int amount;

        public XPAddedGameEvent(int amount)
        {
            this.amount = amount;
        }
    }
    //Leveli
    public class LevelChangedGameEvent : GameEvent
    {
        public int newLvl;

        public LevelChangedGameEvent(int currLvl)
        {
            newLvl = currLvl;   
        }   
    }

    // Currencyt - kolikot / timantit

    public class CurrencyChangedGameEvent : GameEvent
    {
        public int amount;
        public CurrencyType currencyType;

        public CurrencyChangedGameEvent(int amount,CurrencyType currencyType)
        {
            this.amount = amount;
            this.currencyType = currencyType;
        }
    }

    public class NotEnoughCurrencyGameEvent : GameEvent //Kun ei ole tarpeeksi
    {
        public int amount;
        public CurrencyType currencyType;

        public NotEnoughCurrencyGameEvent(int amount, CurrencyType currencyType)
        {
            this.amount = amount;
            this.currencyType = currencyType;
        }
    }

    public class EnoughCurrencyGameEvent : GameEvent
    {

    }
}
