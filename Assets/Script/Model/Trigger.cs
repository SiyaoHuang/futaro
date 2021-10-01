namespace Script
{
    public class Trigger
    {
        private bool value = false;

        public bool get()
        {
            if (value)
            {
                value = false;
                return true;
            }

            return false;
        }

        public void set()
        {
            value = true;
        }
    }
}