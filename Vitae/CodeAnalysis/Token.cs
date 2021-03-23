using System.Collections.Generic;
using System.Linq;

namespace Vitae.CodeAnalysis {
    public class Token : SyntaxNode {
        public int Position { get; }
        public string Text { get; }
        public object Value { get; }

        public Token(SyntaxType type, int pos, string text, object value) {
            Type = type;
            Position = pos;
            Text = text;
            Value = value;
        }

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            return Enumerable.Empty<SyntaxNode>();
        }

        public override SyntaxType Type { get; }
    }
}