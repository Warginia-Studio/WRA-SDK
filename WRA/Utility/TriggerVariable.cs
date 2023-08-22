namespace WRA.Utility
{
    public class TriggerVariable
    {
        private bool state = false;
    
        public void Active()
        {
            state = true;
        }

        public bool GetState()
        {
            var currentState = state;
            state = false;
            return currentState;
        }
    }
}
