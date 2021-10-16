namespace Skysemi.With.CardUI
{
    public class Card
    {
        // public int Index{get {return this._index;}set{_index = value;}}
        private int _index;
        private ActionCards.ABase card;
        // public void Init(int inIndex, ActionCards.ABase implCard)
        public void Init(ActionCards.ABase implCard)
        {
            // this._index = inIndex;
            this.card = implCard;
        }

        public ActionCards.ABase GetActionCard()
        {
            return card;
        }
          
    }
}