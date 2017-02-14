using System.Linq;

namespace HandleBarsVsFumanchu.Tests
{
    public class TestHelper
    {
        public static string GetExpectedCompilledTemplate(int templateSize = 200)
        {
            var data = DataFactory.GetDataModel();
            return string.Join("",
                Enumerable.Range(0, templateSize).Select(x => data.FirstName + data.IsReady + data.Note + data.LastName));
        }
    }
}