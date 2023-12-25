namespace WRA.General.Patterns.Singletons
{
    public class Singleton<T> where T : new()
    {
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }

                return instance;
            }
        }

        protected static T instance;
    }
}
