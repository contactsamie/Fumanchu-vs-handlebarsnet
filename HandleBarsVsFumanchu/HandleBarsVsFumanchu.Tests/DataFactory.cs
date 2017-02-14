namespace HandleBarsVsFumanchu.Tests
{
    public class DataFactory
    {
        public static dynamic GetDataModel()
        {
            return new
            {
                FirstName = "John",
                LastName = "Doe",
                IsReady = true,
                Note = "Yay!"
            };
        }
    }
}