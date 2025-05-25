using ResultLibrary;

namespace TextAnalysisService.Services
{
  // Интерфейс для анализа текста.
  public interface ITextAnalysisService
  {
    AnalysisResult AnalyzeText(string text);
  }
}
