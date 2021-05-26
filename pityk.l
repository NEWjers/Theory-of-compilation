%{
#undef yywrap
#define yywrap() 1	
void display(char[],int);
int flag;
int num_lines = 1;
%}
%%

"yes" {
	int flag=0;
	display(yytext,flag);
}
"no" {
	int flag=1;
	display(yytext,flag);
}
"xor" {
	int flag=2;
	display(yytext,flag);
}
(x|y|z)(x|y|z|1)* {
	int flag=3;
	display(yytext,flag);
}
. { /* absorb others */ }
\n ++num_lines;
%%
void display(char a[],int flag)
{
	if(flag==0)
		printf("<row number=%d, key word:yes,%s>\n\n",num_lines,a);
	if(flag==1)
		printf("<row number=%d, key word:no,%s>\n\n",num_lines,a);
	if(flag==2)
		printf("<row number=%d, key word:xor,%s>\n\n",num_lines,a);
	if(flag==3)
		printf("<row number=%d, iden from{x,y,z,1}-, %s>\n\n",num_lines,a);

}
main()
{
	yylex();
}
