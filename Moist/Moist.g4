grammar Moist;

// Parser rules
program: statement*;

statement: semicolonTerminatedStatement | braceTerminatedStatement;

semicolonTerminatedStatement: (declaration | assignment | indexAssignment | functionCall | return) ';';
braceTerminatedStatement: ifStatement | whileStatement | forStatement | forEachStatement | functionDeclaration;

declaration: 'const'? Identificator ':=' expression;

assignment: Identificator '=' expression;

indexAssignment: Identificator '[' index ']' '=' expression;

expression: ExclamationMark? multiplyExpression (Plus multiplyExpression | Minus multiplyExpression)* (comparisonRightSide)?;

multiplyExpression: value (Multiply value | Divide value | FloorDivide value | Remainder value)*;

value: Identificator
    | basicTypeValue
    | functionCall
    | arrayIndexing
    | '(' expression ')';

comparisonRightSide: comparisonSign expression;
comparisonSign: (GreaterThan | GreaterOrEqual | LessThan | LessOrEqual | Equals | NotEquals);

basicTypeValue: Unit | Integer | Double | String | Boolean | array;

functionCall: Identificator '(' (expression (',' expression)*)? ')';

functionDeclaration: 'func' Identificator '(' (functionParameters)? ')' '{' statement* '}';
functionParameters: Identificator (',' Identificator)*;

ifStatement: 'if' '(' expression ')' '{' statement* '}' elseStatement?;
elseStatement: 'else' '{' statement* '}';

return: 'return' expression;

whileStatement: 'while' '(' expression ')' '{' statement* '}';

forStatement: 'for' '(' declaration? ',' expression? ',' assignment? ')' '{' statement* '}';

forEachStatement: 'for' '(' forEachVariable 'in' forEachCollection ')' '{' statement* '}';
forEachVariable: Identificator;
forEachCollection: expression;

arrayIndexing: arrayOrVariable '[' index ']';
arrayOrVariable: (Identificator | array);
index: (Identificator | expression);

// Lexer rules
// Types
Unit: 'unit';
Boolean: 'true' | 'false';
Integer: '0' | [1-9] [0-9]*;
Double: [0-9]+ '.' [0-9]+;
String: '"' (~["\\\r\n] | '\\' .)* '"';
array: '[' (expression (',' expression)*)? ']';

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

Identificator: [a-zA-Z_@][a-zA-Z0-9_]*;
Whitespaces: [ \t\r\n]+ -> skip;
Comments: '#' ~[\r\n]* -> skip;