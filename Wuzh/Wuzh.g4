grammar Wuzh;

// Parser rules
program: (importStatement*)? statement*;

importStatement: 'import' String Semicolon;

statement: semicolonTerminatedStatement | braceTerminatedStatement;

semicolonTerminatedStatement: (declaration | assignment | indexAssignment | functionCall | return) Semicolon;
braceTerminatedStatement: ifStatement | whileStatement | forStatement | forEachStatement | functionDeclaration;

declaration: 'const'? Identificator Declare expression;

assignment: Identificator Assign expression;

indexAssignment: Identificator LeftSquareBracket index RightSquareBracket Assign expression;

expression: ExclamationMark? multiplyExpression (Plus multiplyExpression | Minus multiplyExpression)* (comparisonRightSide)?;

multiplyExpression: value (Multiply value | Divide value | FloorDivide value | Remainder value)*;

value: Minus? (Identificator
    | basicTypeValue
    | functionCall
    | arrayIndexing
    | LeftParenthesis expression RightParenthesis);

comparisonRightSide: comparisonSign expression;
comparisonSign: (GreaterThan | GreaterOrEqual | LessThan | LessOrEqual | Equals | NotEquals);

basicTypeValue: Unit | Integer | Double | String | Boolean | array | range | dictionary;

functionCall: Identificator LeftParenthesis (expression (Comma expression)*)? RightParenthesis;

functionDeclaration: 'func' Identificator LeftParenthesis (functionParameters)? RightParenthesis LeftCurlyBracket statement* RightCurlyBracket;
functionParameters: Identificator (Comma Identificator)*;

ifStatement: 'if' LeftParenthesis expression RightParenthesis LeftCurlyBracket statement* RightCurlyBracket elseStatement?;
elseStatement: 'else' LeftCurlyBracket statement* RightCurlyBracket;

return: 'return' expression;

whileStatement: 'while' LeftParenthesis expression RightParenthesis LeftCurlyBracket statement* RightCurlyBracket;

forStatement: 'for' LeftParenthesis declaration? Comma expression? Comma assignment? RightParenthesis LeftCurlyBracket statement* RightCurlyBracket;

forEachStatement: 'for' LeftParenthesis forEachVariable 'in' forEachCollection RightParenthesis LeftCurlyBracket statement* RightCurlyBracket;
forEachVariable: Identificator;
forEachCollection: expression;

arrayIndexing: arrayOrVariable LeftSquareBracket index RightSquareBracket;
arrayOrVariable: (Identificator | array);
index: (Identificator | expression);

array: LeftSquareBracket (expression (Comma expression)*)? Comma? RightSquareBracket;
range: LeftSquareBracket expression TwoDots expression RightSquareBracket;
dictionary: LeftCurlyBracket (dictionaryEntry (Comma dictionaryEntry)*)? Comma? RightCurlyBracket;
dictionaryEntry: String Colon expression;

// Lexer rules
// Types
Unit: 'unit';
Boolean: 'true' | 'false';
Integer: '0' | [1-9] [0-9]*;
Double: [0-9]+ '.' [0-9]+;
String: '"' (~["\\\r\n] | '\\' .)* '"';

// Operators and signs
Plus: '+';
Minus: '-';
Multiply: '*';
Divide: '/';
FloorDivide: '//';
Remainder: '%';
GreaterThan: '>';
GreaterOrEqual: '>=';
LessThan: '<';
LessOrEqual: '<=';
Equals: '==';
NotEquals: '!=';
And: '&&';
Or: '||';
ExclamationMark: '!';

// Punctuation
LeftParenthesis: '(';
RightParenthesis: ')';
LeftCurlyBracket: '{';
RightCurlyBracket: '}';
LeftSquareBracket: '[';
RightSquareBracket: ']';
Comma: ',';
Semicolon: ';';
Colon: ':';
TwoDots: '..';

Declare: ':=';
Assign: '=';

Identificator: [a-zA-Z_@][a-zA-Z0-9_]*;
Whitespaces: [ \t\r\n]+ -> skip;
Comments: '#' ~[\r\n]* -> skip;