using System.Collections.Generic;
using UWarning.Data;
using UnityEngine;

namespace UWarning.Core
{
    public static class WarningCardRepo
    {
        private static Dictionary<string, WarningCard> catchedData = new();

        static WarningCardRepo()
        {
            var cards = Resources.LoadAll<WarningCard>(string.Empty);
            foreach (var card in cards)
            {
                if (catchedData.ContainsKey(card.Id))
                {
                    Debug.LogWarning("The card has a duplicate ID", card);
                    continue;
                }

                catchedData.Add(card.Id, card);
            }
        }

        public static WarningCard Get(string id)
        {
            if (catchedData.TryGetValue(id, out WarningCard card))
                return card;

            throw new System.Exception("There is no card with this ID");
        }
    }
}
