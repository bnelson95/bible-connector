using System.Collections.Generic;

namespace BibleConnector.ESV
{
    public class PassageMeta
    {
        public string Canonical { get; set; }
        public List<int> ChapterStart { get; set; }
        public List<int> ChapterEnd { get; set; }
        public object PrevVerse { get; set; }
        public int NextVerse { get; set; }
        public object PrevChapter { get; set; }
        public List<int> NextChapter { get; set; }
    }

    public class EsvResponse
    {
        public string Query { get; set; }
        public string Canonical { get; set; }
        public List<List<int>> Parsed { get; set; }
        public List<PassageMeta> PassageMeta { get; set; }
        public List<string> Passages { get; set; }
    }
}
