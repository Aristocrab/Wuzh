//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Wuzh.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class WuzhLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		Unit=10, Boolean=11, Integer=12, Double=13, String=14, Type=15, Plus=16, 
		Minus=17, Multiply=18, Divide=19, FloorDivide=20, Remainder=21, GreaterThan=22, 
		GreaterOrEqual=23, LessThan=24, LessOrEqual=25, Equals=26, NotEquals=27, 
		And=28, Or=29, ExclamationMark=30, LeftParenthesis=31, RightParenthesis=32, 
		LeftCurlyBracket=33, RightCurlyBracket=34, LeftSquareBracket=35, RightSquareBracket=36, 
		Comma=37, Semicolon=38, Colon=39, TwoDots=40, FunctionTypeSign=41, Declare=42, 
		Assign=43, Identificator=44, Whitespaces=45, Comments=46;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"Unit", "Boolean", "Integer", "Double", "String", "Type", "Plus", "Minus", 
		"Multiply", "Divide", "FloorDivide", "Remainder", "GreaterThan", "GreaterOrEqual", 
		"LessThan", "LessOrEqual", "Equals", "NotEquals", "And", "Or", "ExclamationMark", 
		"LeftParenthesis", "RightParenthesis", "LeftCurlyBracket", "RightCurlyBracket", 
		"LeftSquareBracket", "RightSquareBracket", "Comma", "Semicolon", "Colon", 
		"TwoDots", "FunctionTypeSign", "Declare", "Assign", "Identificator", "Whitespaces", 
		"Comments"
	};


	public WuzhLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public WuzhLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'import'", "'const'", "'func'", "'if'", "'else'", "'return'", "'while'", 
		"'for'", "'in'", "'unit'", null, null, null, null, null, "'+'", "'-'", 
		"'*'", "'/'", "'//'", "'%'", "'>'", "'>='", "'<'", "'<='", "'=='", "'!='", 
		"'&&'", "'||'", "'!'", "'('", "')'", "'{'", "'}'", "'['", "']'", "','", 
		"';'", "':'", "'..'", "'->'", "':='", "'='"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, "Unit", "Boolean", 
		"Integer", "Double", "String", "Type", "Plus", "Minus", "Multiply", "Divide", 
		"FloorDivide", "Remainder", "GreaterThan", "GreaterOrEqual", "LessThan", 
		"LessOrEqual", "Equals", "NotEquals", "And", "Or", "ExclamationMark", 
		"LeftParenthesis", "RightParenthesis", "LeftCurlyBracket", "RightCurlyBracket", 
		"LeftSquareBracket", "RightSquareBracket", "Comma", "Semicolon", "Colon", 
		"TwoDots", "FunctionTypeSign", "Declare", "Assign", "Identificator", "Whitespaces", 
		"Comments"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Wuzh.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static WuzhLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,46,326,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,2,34,7,34,2,35,
		7,35,2,36,7,36,2,37,7,37,2,38,7,38,2,39,7,39,2,40,7,40,2,41,7,41,2,42,
		7,42,2,43,7,43,2,44,7,44,2,45,7,45,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,
		1,1,1,1,1,1,1,1,1,2,1,2,1,2,1,2,1,2,1,3,1,3,1,3,1,4,1,4,1,4,1,4,1,4,1,
		5,1,5,1,5,1,5,1,5,1,5,1,5,1,6,1,6,1,6,1,6,1,6,1,6,1,7,1,7,1,7,1,7,1,8,
		1,8,1,8,1,9,1,9,1,9,1,9,1,9,1,10,1,10,1,10,1,10,1,10,1,10,1,10,1,10,1,
		10,3,10,154,8,10,1,11,1,11,1,11,3,11,159,8,11,1,11,5,11,162,8,11,10,11,
		12,11,165,9,11,3,11,167,8,11,1,12,4,12,170,8,12,11,12,12,12,171,1,12,1,
		12,4,12,176,8,12,11,12,12,12,177,1,13,1,13,1,13,1,13,5,13,184,8,13,10,
		13,12,13,187,9,13,1,13,1,13,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,
		14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,
		14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,
		14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,3,14,236,8,14,1,15,1,15,1,16,
		1,16,1,17,1,17,1,18,1,18,1,19,1,19,1,19,1,20,1,20,1,21,1,21,1,22,1,22,
		1,22,1,23,1,23,1,24,1,24,1,24,1,25,1,25,1,25,1,26,1,26,1,26,1,27,1,27,
		1,27,1,28,1,28,1,28,1,29,1,29,1,30,1,30,1,31,1,31,1,32,1,32,1,33,1,33,
		1,34,1,34,1,35,1,35,1,36,1,36,1,37,1,37,1,38,1,38,1,39,1,39,1,39,1,40,
		1,40,1,40,1,41,1,41,1,41,1,42,1,42,1,43,1,43,5,43,306,8,43,10,43,12,43,
		309,9,43,1,44,4,44,312,8,44,11,44,12,44,313,1,44,1,44,1,45,1,45,5,45,320,
		8,45,10,45,12,45,323,9,45,1,45,1,45,0,0,46,1,1,3,2,5,3,7,4,9,5,11,6,13,
		7,15,8,17,9,19,10,21,11,23,12,25,13,27,14,29,15,31,16,33,17,35,18,37,19,
		39,20,41,21,43,22,45,23,47,24,49,25,51,26,53,27,55,28,57,29,59,30,61,31,
		63,32,65,33,67,34,69,35,71,36,73,37,75,38,77,39,79,40,81,41,83,42,85,43,
		87,44,89,45,91,46,1,0,7,1,0,49,57,1,0,48,57,4,0,10,10,13,13,34,34,92,92,
		3,0,64,90,95,95,97,122,4,0,48,57,65,90,95,95,97,122,3,0,9,10,13,13,32,
		32,2,0,10,10,13,13,344,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,
		0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,
		0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,
		0,31,1,0,0,0,0,33,1,0,0,0,0,35,1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,0,0,41,
		1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,0,0,47,1,0,0,0,0,49,1,0,0,0,0,51,1,0,0,
		0,0,53,1,0,0,0,0,55,1,0,0,0,0,57,1,0,0,0,0,59,1,0,0,0,0,61,1,0,0,0,0,63,
		1,0,0,0,0,65,1,0,0,0,0,67,1,0,0,0,0,69,1,0,0,0,0,71,1,0,0,0,0,73,1,0,0,
		0,0,75,1,0,0,0,0,77,1,0,0,0,0,79,1,0,0,0,0,81,1,0,0,0,0,83,1,0,0,0,0,85,
		1,0,0,0,0,87,1,0,0,0,0,89,1,0,0,0,0,91,1,0,0,0,1,93,1,0,0,0,3,100,1,0,
		0,0,5,106,1,0,0,0,7,111,1,0,0,0,9,114,1,0,0,0,11,119,1,0,0,0,13,126,1,
		0,0,0,15,132,1,0,0,0,17,136,1,0,0,0,19,139,1,0,0,0,21,153,1,0,0,0,23,166,
		1,0,0,0,25,169,1,0,0,0,27,179,1,0,0,0,29,235,1,0,0,0,31,237,1,0,0,0,33,
		239,1,0,0,0,35,241,1,0,0,0,37,243,1,0,0,0,39,245,1,0,0,0,41,248,1,0,0,
		0,43,250,1,0,0,0,45,252,1,0,0,0,47,255,1,0,0,0,49,257,1,0,0,0,51,260,1,
		0,0,0,53,263,1,0,0,0,55,266,1,0,0,0,57,269,1,0,0,0,59,272,1,0,0,0,61,274,
		1,0,0,0,63,276,1,0,0,0,65,278,1,0,0,0,67,280,1,0,0,0,69,282,1,0,0,0,71,
		284,1,0,0,0,73,286,1,0,0,0,75,288,1,0,0,0,77,290,1,0,0,0,79,292,1,0,0,
		0,81,295,1,0,0,0,83,298,1,0,0,0,85,301,1,0,0,0,87,303,1,0,0,0,89,311,1,
		0,0,0,91,317,1,0,0,0,93,94,5,105,0,0,94,95,5,109,0,0,95,96,5,112,0,0,96,
		97,5,111,0,0,97,98,5,114,0,0,98,99,5,116,0,0,99,2,1,0,0,0,100,101,5,99,
		0,0,101,102,5,111,0,0,102,103,5,110,0,0,103,104,5,115,0,0,104,105,5,116,
		0,0,105,4,1,0,0,0,106,107,5,102,0,0,107,108,5,117,0,0,108,109,5,110,0,
		0,109,110,5,99,0,0,110,6,1,0,0,0,111,112,5,105,0,0,112,113,5,102,0,0,113,
		8,1,0,0,0,114,115,5,101,0,0,115,116,5,108,0,0,116,117,5,115,0,0,117,118,
		5,101,0,0,118,10,1,0,0,0,119,120,5,114,0,0,120,121,5,101,0,0,121,122,5,
		116,0,0,122,123,5,117,0,0,123,124,5,114,0,0,124,125,5,110,0,0,125,12,1,
		0,0,0,126,127,5,119,0,0,127,128,5,104,0,0,128,129,5,105,0,0,129,130,5,
		108,0,0,130,131,5,101,0,0,131,14,1,0,0,0,132,133,5,102,0,0,133,134,5,111,
		0,0,134,135,5,114,0,0,135,16,1,0,0,0,136,137,5,105,0,0,137,138,5,110,0,
		0,138,18,1,0,0,0,139,140,5,117,0,0,140,141,5,110,0,0,141,142,5,105,0,0,
		142,143,5,116,0,0,143,20,1,0,0,0,144,145,5,116,0,0,145,146,5,114,0,0,146,
		147,5,117,0,0,147,154,5,101,0,0,148,149,5,102,0,0,149,150,5,97,0,0,150,
		151,5,108,0,0,151,152,5,115,0,0,152,154,5,101,0,0,153,144,1,0,0,0,153,
		148,1,0,0,0,154,22,1,0,0,0,155,167,5,48,0,0,156,163,7,0,0,0,157,159,5,
		95,0,0,158,157,1,0,0,0,158,159,1,0,0,0,159,160,1,0,0,0,160,162,7,1,0,0,
		161,158,1,0,0,0,162,165,1,0,0,0,163,161,1,0,0,0,163,164,1,0,0,0,164,167,
		1,0,0,0,165,163,1,0,0,0,166,155,1,0,0,0,166,156,1,0,0,0,167,24,1,0,0,0,
		168,170,7,1,0,0,169,168,1,0,0,0,170,171,1,0,0,0,171,169,1,0,0,0,171,172,
		1,0,0,0,172,173,1,0,0,0,173,175,5,46,0,0,174,176,7,1,0,0,175,174,1,0,0,
		0,176,177,1,0,0,0,177,175,1,0,0,0,177,178,1,0,0,0,178,26,1,0,0,0,179,185,
		5,34,0,0,180,184,8,2,0,0,181,182,5,92,0,0,182,184,9,0,0,0,183,180,1,0,
		0,0,183,181,1,0,0,0,184,187,1,0,0,0,185,183,1,0,0,0,185,186,1,0,0,0,186,
		188,1,0,0,0,187,185,1,0,0,0,188,189,5,34,0,0,189,28,1,0,0,0,190,191,5,
		65,0,0,191,192,5,110,0,0,192,236,5,121,0,0,193,194,5,85,0,0,194,195,5,
		110,0,0,195,196,5,105,0,0,196,236,5,116,0,0,197,198,5,66,0,0,198,199,5,
		111,0,0,199,200,5,111,0,0,200,236,5,108,0,0,201,202,5,73,0,0,202,203,5,
		110,0,0,203,236,5,116,0,0,204,205,5,68,0,0,205,206,5,111,0,0,206,207,5,
		117,0,0,207,208,5,98,0,0,208,209,5,108,0,0,209,236,5,101,0,0,210,211,5,
		83,0,0,211,212,5,116,0,0,212,213,5,114,0,0,213,214,5,105,0,0,214,215,5,
		110,0,0,215,236,5,103,0,0,216,217,5,65,0,0,217,218,5,114,0,0,218,219,5,
		114,0,0,219,220,5,97,0,0,220,236,5,121,0,0,221,222,5,68,0,0,222,223,5,
		105,0,0,223,224,5,99,0,0,224,236,5,116,0,0,225,226,5,68,0,0,226,227,5,
		105,0,0,227,228,5,99,0,0,228,229,5,116,0,0,229,230,5,105,0,0,230,231,5,
		111,0,0,231,232,5,110,0,0,232,233,5,97,0,0,233,234,5,114,0,0,234,236,5,
		121,0,0,235,190,1,0,0,0,235,193,1,0,0,0,235,197,1,0,0,0,235,201,1,0,0,
		0,235,204,1,0,0,0,235,210,1,0,0,0,235,216,1,0,0,0,235,221,1,0,0,0,235,
		225,1,0,0,0,236,30,1,0,0,0,237,238,5,43,0,0,238,32,1,0,0,0,239,240,5,45,
		0,0,240,34,1,0,0,0,241,242,5,42,0,0,242,36,1,0,0,0,243,244,5,47,0,0,244,
		38,1,0,0,0,245,246,5,47,0,0,246,247,5,47,0,0,247,40,1,0,0,0,248,249,5,
		37,0,0,249,42,1,0,0,0,250,251,5,62,0,0,251,44,1,0,0,0,252,253,5,62,0,0,
		253,254,5,61,0,0,254,46,1,0,0,0,255,256,5,60,0,0,256,48,1,0,0,0,257,258,
		5,60,0,0,258,259,5,61,0,0,259,50,1,0,0,0,260,261,5,61,0,0,261,262,5,61,
		0,0,262,52,1,0,0,0,263,264,5,33,0,0,264,265,5,61,0,0,265,54,1,0,0,0,266,
		267,5,38,0,0,267,268,5,38,0,0,268,56,1,0,0,0,269,270,5,124,0,0,270,271,
		5,124,0,0,271,58,1,0,0,0,272,273,5,33,0,0,273,60,1,0,0,0,274,275,5,40,
		0,0,275,62,1,0,0,0,276,277,5,41,0,0,277,64,1,0,0,0,278,279,5,123,0,0,279,
		66,1,0,0,0,280,281,5,125,0,0,281,68,1,0,0,0,282,283,5,91,0,0,283,70,1,
		0,0,0,284,285,5,93,0,0,285,72,1,0,0,0,286,287,5,44,0,0,287,74,1,0,0,0,
		288,289,5,59,0,0,289,76,1,0,0,0,290,291,5,58,0,0,291,78,1,0,0,0,292,293,
		5,46,0,0,293,294,5,46,0,0,294,80,1,0,0,0,295,296,5,45,0,0,296,297,5,62,
		0,0,297,82,1,0,0,0,298,299,5,58,0,0,299,300,5,61,0,0,300,84,1,0,0,0,301,
		302,5,61,0,0,302,86,1,0,0,0,303,307,7,3,0,0,304,306,7,4,0,0,305,304,1,
		0,0,0,306,309,1,0,0,0,307,305,1,0,0,0,307,308,1,0,0,0,308,88,1,0,0,0,309,
		307,1,0,0,0,310,312,7,5,0,0,311,310,1,0,0,0,312,313,1,0,0,0,313,311,1,
		0,0,0,313,314,1,0,0,0,314,315,1,0,0,0,315,316,6,44,0,0,316,90,1,0,0,0,
		317,321,5,35,0,0,318,320,8,6,0,0,319,318,1,0,0,0,320,323,1,0,0,0,321,319,
		1,0,0,0,321,322,1,0,0,0,322,324,1,0,0,0,323,321,1,0,0,0,324,325,6,45,0,
		0,325,92,1,0,0,0,13,0,153,158,163,166,171,177,183,185,235,307,313,321,
		1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}