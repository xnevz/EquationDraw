grammar Grammar;

root
	: expression EOF
	;

expression
	: left=expression op=POW right=expression
	| left=expression op=(MULT | DIV | FLOOR_DIV) right=expression
	| left=expression op=(PLUS | MINUS) right=expression
	| funcName=variable? LPAREN fParam1=expression fOtherParams=multExpression RPAREN
	| sign=sgn number=atom
	;

sgn
	: (PLUS | MINUS)*
;

multExpression
   : multExprPart*
   ;

multExprPart
   : ',' expr=expression
   ;

atom
	: scientific /* or variable (later)*/
	;

scientific
	: SCI_NUMBER
	;

variable
	: VARIABLE
	;

VARIABLE
	: VALID_ID_START VALID_ID_CHAR*
	;

fragment VALID_ID_START
   : [a-zA-Z_]
   ;

fragment VALID_ID_CHAR
	: VALID_ID_START | [0-9]
	;

SCI_NUMBER
   : NUMBER (E SIGN? UNSIGNED_INTEGER)?
   ;

fragment NUMBER
   :  UNSIGNED_INTEGER ('.'UNSIGNED_INTEGER)?
   | '.'UNSIGNED_INTEGER
   ;

fragment UNSIGNED_INTEGER
   : [0-9]+
   ;


fragment E
   : 'E' | 'e'
   ;


fragment SIGN
   : ('+' | '-')
   ;


LPAREN
   : '('
   ;

RPAREN
   : ')'
   ;

   
PLUS
   : '+'
   ;

MINUS
   : '-'
   ;


MULT
   : '*'
   ;


DIV
   : '/'
   ;

FLOOR_DIV
   : '\\'
   ;
POINT
   : '.'
   ;

POW
   : '^'
   ;


WS: [ \t\n\r]+ -> skip;