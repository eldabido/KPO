namespace ResultLibrary
{
  // Результаты анализа файла.
  public class AnalysisResult
  {
    // Кол-во абзацев.
    public int ParagraphCount { get; set; }

    // Кол-во слов.
    public int WordCount { get; set; }

    // Кол-во символов.
    public int CharacterCount { get; set; }

    // Дата.
    public DateTime AnalysisDate { get; set; }

    // Вывод.
    public override string ToString() =>
        $"Paragraphs: {ParagraphCount}, Words: {WordCount}, Chars: {CharacterCount}";
  }
}
