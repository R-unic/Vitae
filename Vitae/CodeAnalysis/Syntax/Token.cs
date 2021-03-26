using System.Collections.Generic;
using System.Linq;

namespace Vitae.CodeAnalysis.Syntax {
    public sealed class Token : SyntaxNode {
        public override SyntaxType Type { get; }
        public int Position { get; }
        public string Text { get; }
        public object Value { get; }
        public TextSpan Span => new TextSpan(Position, Text.Length);

        public Token(SyntaxType type, int pos, string text, object value) {
            Type = type;
            Position = pos;
            Text = text;
            Value = value;
        }
    }
}
