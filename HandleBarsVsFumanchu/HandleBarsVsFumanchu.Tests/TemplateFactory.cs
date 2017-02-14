using System.Linq;

namespace HandleBarsVsFumanchu.Tests
{
    public class TemplateFactory
    {
        public static string GetEmailTemplate(int templateSize = 200)
        {
            var template =
                Enumerable.Range(0, templateSize)
                    .Select(
                        x => @"{{#if IsReady}}{{FirstName}}{{#if IsReady}}{{IsReady}}{{Note}}{{/if}}{{LastName}}{{/if}}");
            return string.Join("", template);
        }
    }
}