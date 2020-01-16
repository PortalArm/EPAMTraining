using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace HomeWork04
{
    class TextInfo
    {
        StringBuilder _sb;

        // (?<=(?:^|\.)[\s\S]*\b) - задаем, что перед началом предложения должно быть либо начало всего текста (^), либо (|) точка (\.),
        // затем любое количество символов ([\s\S]*) перед началом слова (\b),
        // но не включаем эту часть в результат (?<=...)
        // [^.]+ - принимаем любое непустое множество символов, где нет точки
        // (\.|$) - задаем, что в конце предложения должна быть либо точка, либо конец всего текста

        //Шаблон для обнаружения предложения, точка выступает в качестве разделителя предложений.
        //private const string _sentencePattern = @"(?<=(?:^|\.)[\s\S]*\b)[^.]+(\.|$)";

        //Шаблон для обнаружения предложения с дополнительной возможностью использовать кавычки. Все внутри кавычек будет трактовано как часть предложения.
        private const string _sentencePattern = @"(?<=(?:^|\.)[\s]*(?=(?:""|\b)))(?:(""[^""]*?"")*[^.""]*)+(?:\.|$)";

        private const string _wordPattern = @"\b\w+\b";
        private const string _characterPattern = @"\w";
        public int Sentences { get; private set; }
        public int Words { get; private set; }

        //Количество буквенных и численных символов
        public int CharactersPure { get; private set; }
        //Количество всех символов
        public int Characters { get; private set; }
        public double AverageWordLength { get; private set; } // Symbols / Words
        public double AverageSentenceLength { get; private set; } //Words / Sentences
        public TextInfo(TextReader inputReader)
        {
            _sb = new StringBuilder(inputReader.ReadToEnd());
            string input = _sb.ToString();
            Characters = input.Length;

            var sentences = Regex.Matches(input, _sentencePattern);
            var words = Regex.Matches(input, _wordPattern);
            var characters = Regex.Matches(input, _characterPattern);

            Sentences = sentences.Count;
            Words = words.Count;
            CharactersPure = characters.Count;
            AverageSentenceLength = Words * 1f / Sentences;
            AverageWordLength = CharactersPure * 1f / Words;
        }

        public override string ToString() => string.Format(@"У введенного текста следующие характеристики:
Количество предложений:   {0,9}
Количество слов:          {1,9}
Количество символов/цифр: {2,9}
Средняя длина предложения:{3,9:0.000}
Средняя длина слова:      {4,9:0.000}
Количество всех символов: {5,9}", Sentences, Words, CharactersPure, AverageSentenceLength, AverageWordLength, Characters );

        //(?<=(?:^|\.)[\s\S]*\b)((".*\.+.*")+|[^.]+)(?:\.|$)
        //(?<=(?:^|\.)[\s\S]*\b)(?:("[^"]*")|[^.])+(?:\.|$)
    }
}
// ЛЮБОЙ СИМВОЛ ПОСЛЕ ТОЧКИ, КОТОРЫЙ 