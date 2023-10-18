using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.HelperModels
{
    public class WordParagraph
    {
        public List<(string, WordParagraphProperties)> Texts { get; set; }
        public WordParagraphProperties TextProperties { get; set; }
    }
}
