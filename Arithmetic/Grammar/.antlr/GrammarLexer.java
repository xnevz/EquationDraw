// Generated from d:\My Projects\EquationDraw\Arithmetic\Grammar\Grammar.g4 by ANTLR 4.8
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class GrammarLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.8", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, VARIABLE=2, SCI_NUMBER=3, LPAREN=4, RPAREN=5, PLUS=6, MINUS=7, 
		MULT=8, DIV=9, FLOOR_DIV=10, POINT=11, POW=12, WS=13;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"T__0", "VARIABLE", "VALID_ID_START", "VALID_ID_CHAR", "SCI_NUMBER", 
			"NUMBER", "UNSIGNED_INTEGER", "E", "SIGN", "LPAREN", "RPAREN", "PLUS", 
			"MINUS", "MULT", "DIV", "FLOOR_DIV", "POINT", "POW", "WS"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "','", null, null, "'('", "')'", "'+'", "'-'", "'*'", "'/'", "'\\'", 
			"'.'", "'^'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, "VARIABLE", "SCI_NUMBER", "LPAREN", "RPAREN", "PLUS", "MINUS", 
			"MULT", "DIV", "FLOOR_DIV", "POINT", "POW", "WS"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}


	public GrammarLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "Grammar.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\17l\b\1\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\3\2\3\2\3\3\3\3\7\3.\n\3\f\3\16\3\61\13\3\3\4\3\4"+
		"\3\5\3\5\5\5\67\n\5\3\6\3\6\3\6\5\6<\n\6\3\6\3\6\5\6@\n\6\3\7\3\7\3\7"+
		"\5\7E\n\7\3\7\3\7\5\7I\n\7\3\b\6\bL\n\b\r\b\16\bM\3\t\3\t\3\n\3\n\3\13"+
		"\3\13\3\f\3\f\3\r\3\r\3\16\3\16\3\17\3\17\3\20\3\20\3\21\3\21\3\22\3\22"+
		"\3\23\3\23\3\24\6\24g\n\24\r\24\16\24h\3\24\3\24\2\2\25\3\3\5\4\7\2\t"+
		"\2\13\5\r\2\17\2\21\2\23\2\25\6\27\7\31\b\33\t\35\n\37\13!\f#\r%\16\'"+
		"\17\3\2\7\5\2C\\aac|\3\2\62;\4\2GGgg\4\2--//\5\2\13\f\17\17\"\"\2m\2\3"+
		"\3\2\2\2\2\5\3\2\2\2\2\13\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2"+
		"\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2"+
		"\2\2\2\'\3\2\2\2\3)\3\2\2\2\5+\3\2\2\2\7\62\3\2\2\2\t\66\3\2\2\2\138\3"+
		"\2\2\2\rH\3\2\2\2\17K\3\2\2\2\21O\3\2\2\2\23Q\3\2\2\2\25S\3\2\2\2\27U"+
		"\3\2\2\2\31W\3\2\2\2\33Y\3\2\2\2\35[\3\2\2\2\37]\3\2\2\2!_\3\2\2\2#a\3"+
		"\2\2\2%c\3\2\2\2\'f\3\2\2\2)*\7.\2\2*\4\3\2\2\2+/\5\7\4\2,.\5\t\5\2-,"+
		"\3\2\2\2.\61\3\2\2\2/-\3\2\2\2/\60\3\2\2\2\60\6\3\2\2\2\61/\3\2\2\2\62"+
		"\63\t\2\2\2\63\b\3\2\2\2\64\67\5\7\4\2\65\67\t\3\2\2\66\64\3\2\2\2\66"+
		"\65\3\2\2\2\67\n\3\2\2\28?\5\r\7\29;\5\21\t\2:<\5\23\n\2;:\3\2\2\2;<\3"+
		"\2\2\2<=\3\2\2\2=>\5\17\b\2>@\3\2\2\2?9\3\2\2\2?@\3\2\2\2@\f\3\2\2\2A"+
		"D\5\17\b\2BC\7\60\2\2CE\5\17\b\2DB\3\2\2\2DE\3\2\2\2EI\3\2\2\2FG\7\60"+
		"\2\2GI\5\17\b\2HA\3\2\2\2HF\3\2\2\2I\16\3\2\2\2JL\t\3\2\2KJ\3\2\2\2LM"+
		"\3\2\2\2MK\3\2\2\2MN\3\2\2\2N\20\3\2\2\2OP\t\4\2\2P\22\3\2\2\2QR\t\5\2"+
		"\2R\24\3\2\2\2ST\7*\2\2T\26\3\2\2\2UV\7+\2\2V\30\3\2\2\2WX\7-\2\2X\32"+
		"\3\2\2\2YZ\7/\2\2Z\34\3\2\2\2[\\\7,\2\2\\\36\3\2\2\2]^\7\61\2\2^ \3\2"+
		"\2\2_`\7^\2\2`\"\3\2\2\2ab\7\60\2\2b$\3\2\2\2cd\7`\2\2d&\3\2\2\2eg\t\6"+
		"\2\2fe\3\2\2\2gh\3\2\2\2hf\3\2\2\2hi\3\2\2\2ij\3\2\2\2jk\b\24\2\2k(\3"+
		"\2\2\2\13\2/\66;?DHMh\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}