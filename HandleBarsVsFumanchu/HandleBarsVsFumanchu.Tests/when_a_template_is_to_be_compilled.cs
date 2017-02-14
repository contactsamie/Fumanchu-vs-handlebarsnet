using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace HandleBarsVsFumanchu.Tests
{
    public class when_a_template_is_to_be_compilled
    {
        private const int TemplateSize = 10000;
        private readonly ITestOutputHelper _output;
        private readonly string _expectedResult = TestHelper.GetExpectedCompilledTemplate(TemplateSize);
        private readonly string _template = TemplateFactory.GetEmailTemplate(TemplateSize);
        private readonly dynamic _model = DataFactory.GetDataModel();

        public when_a_template_is_to_be_compilled(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void use_handlebarsnet()
        {
            var watch = Stopwatch.StartNew();

            var compilation = HandlebarsDotNet.Handlebars.Compile(_template);
            string actualResult = compilation(_model);

            watch.Stop();

            AssertAndPrintResult(watch, actualResult);
        }

        [Fact]
        public void use_fumanchu()
        {
            var watch = Stopwatch.StartNew();

            var compilation = FuManchu.Handlebars.Compile("template-name", _template);
            string actualResult = FuManchu.Handlebars.Run("template-name", _model);

            watch.Stop();

            AssertAndPrintResult(watch, actualResult);
        }

        private void AssertAndPrintResult(Stopwatch watch, string actualResult)
        {
            _output.WriteLine("Took " + watch.Elapsed.TotalSeconds + " second(s).");
            Assert.Equal(_expectedResult, actualResult);
        }
    }
}