using UnityEngine;

namespace WRA.General.Journal
{
   public abstract class WikipediaEntry : JournalEntry
   {
      public WikipediaCategories wikipediaCategory;
      public Sprite icon;

      public abstract (string labelName, string labelText)[] GetLabels();
   }
}
