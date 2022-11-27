namespace Patterns
{
    public class Singleton<T>
    {
        public static T Instance
        {
            get
            {
                if(instance==null)
                {
                    instance = default(T);
                }
                return instance;
            }
        }

        protected static T instance;
    }
}
