namespace UnitTestMasters_Session7Assignment.Utility
{
    public class Bus : IBus
    {
        public void Send(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new Exception("Something is wrong");
            }
        }
    }
}