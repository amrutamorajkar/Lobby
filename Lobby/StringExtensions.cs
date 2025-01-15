namespace Lobby
{
    public static class StringExtensions
    {
        /// <summary>
        /// Sanitizes html input and removes any occurences of script tag or other malicious tags
        /// </summary>
        /// <param name="input">Input string to be sanitized</param>
        /// <param name="matchScriptTag">Should match and remove script tags</param>
        /// <param name="matchTags">Array of other tags to be removed eg : onclick, onblur, onmouseover etc</param>
        /// <returns></returns>
        public static string SanitizeHTML(this string input, bool matchScriptTag, string[] matchTags)
        {
            if (matchScriptTag)
            {
                string start = "<script>";
                string end = "</script>";

                // remove script tag
                while (input.Contains(start))
                {
                    int startIndex = input.IndexOf(start);
                    int endIndex = input.IndexOf(end);

                    int strLength = endIndex == -1 ? (startIndex == -1 ? 0 : start.Length) : (endIndex + end.Length) - startIndex;

                    input = input.Remove(startIndex, strLength);
                }
            }

            //remove any other matching tags
            for (int i = 0; i < matchTags.Length; i++)
            {
                while (input.Contains(matchTags[i]))
                {
                    int startIndex = input.IndexOf(matchTags[i]);
                    input = input.Remove(startIndex, startIndex == -1 ? 0 : matchTags[i].Length);
                }
            }

            return input;
        }
    }
}
