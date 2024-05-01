using Post_EDU.Application.HelperContracts;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

public class SlugHelper : ISlugHelper
{
    public string Active(string sourceStr)
    {
        // Переводим русские буквы в транслит
        sourceStr = Transliterate(sourceStr);

        // Удаление специальных символов и приведение к нижнему регистру
        var normalizedString = RemoveDiacritics(sourceStr).ToLowerInvariant();

        // Замена пробелов и других символов на дефисы
        normalizedString = Regex.Replace(normalizedString, @"\s", "-", RegexOptions.Compiled);

        // Удаление недопустимых символов
        normalizedString = Regex.Replace(normalizedString, @"[^a-z0-9\s-_]", "", RegexOptions.Compiled);

        // Замена последовательностей дефисов на один дефис
        normalizedString = Regex.Replace(normalizedString, @"-+", "-", RegexOptions.Compiled);

        // Обрезка длинных слагов
        if (normalizedString.Length > 100)
        {
            normalizedString = normalizedString.Substring(0, 100);
        }

        // Удаление дефисов в начале и в конце строки
        normalizedString = normalizedString.Trim('-');

        return normalizedString;
    }

    private string Transliterate(string text)
    {
        // Словарь для транслитерации русских букв
        var translitMap = new Dictionary<char, string>
        {
            {'а', "a"}, {'б', "b"}, {'в', "v"}, {'г', "g"}, {'д', "d"}, {'е', "e"},
            {'ё', "yo"}, {'ж', "zh"}, {'з', "z"}, {'и', "i"}, {'й', "y"}, {'к', "k"},
            {'л', "l"}, {'м', "m"}, {'н', "n"}, {'о', "o"}, {'п', "p"}, {'р', "r"},
            {'с', "s"}, {'т', "t"}, {'у', "u"}, {'ф', "f"}, {'х', "kh"}, {'ц', "ts"},
            {'ч', "ch"}, {'ш', "sh"}, {'щ', "shch"}, {'ъ', ""}, {'ы', "y"}, {'ь', ""},
            {'э', "e"}, {'ю', "yu"}, {'я', "ya"}
        };

        var transliteratedStringBuilder = new StringBuilder();

        foreach (var c in text)
        {
            if (translitMap.ContainsKey(c))
            {
                transliteratedStringBuilder.Append(translitMap[c]);
            }
            else if (char.IsLetterOrDigit(c))
            {
                transliteratedStringBuilder.Append(c);
            }
        }

        return transliteratedStringBuilder.ToString();
    }

    private string RemoveDiacritics(string text)
    {
        var normalizedString = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }
}
