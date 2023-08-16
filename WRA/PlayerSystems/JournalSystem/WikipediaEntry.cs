using UnityEngine;

namespace WRA.PlayerSystems.JournalSystem
{
   public abstract class WikipediaEntry : JournalEntry
   {
      public WikipediaCategories wikipediaCategory;
      public Sprite icon;

      public abstract (string labelName, string labelText)[] GetLabels();
   }
}
