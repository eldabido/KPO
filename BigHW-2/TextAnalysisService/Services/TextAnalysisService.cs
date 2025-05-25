using ResultLibrary;
using System.Text.RegularExpressions;

namespace TextAnalysisService.Services;

// Класс, занимающийся анализом текста.
public class TextAnalysisService : ITextAnalysisService
{
  public AnalysisResult AnalyzeText(string text)
  {
    return new AnalysisResult
    {
      ParagraphCount = CountParagraphs(text),
      WordCount = CountWords(text),
      CharacterCount = text.Length,
      AnalysisDate = DateTime.UtcNow
    };
  }
  // Подсчет абзацев и слов с помощью регулярных выражений.
  int CountParagraphs(string text) =>
    text.Split(new[] { "\r\n\r\n", "\n\n", "\r\r" }, StringSplitOptions.RemoveEmptyEntries).Length;

  int CountWords(string text) =>
    Regex.Matches(text, @"[\p{L}0-9']+").Count;
}
