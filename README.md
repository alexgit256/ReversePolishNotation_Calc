# ReversePolishNotation_Calc
My RPN calculator with planned variable support. Expected to evolve into primitive full-turing programming language.
Input string is being divided into Terms - atomic structures such as operators, variables, functions, numbers, etc. Each Term has its own property: TermType, which can be one of those: ERR (damaged of unrecognized term), MRK (markup), OPR (operator), INT (integer), FLT (float), VAR (variable), FNC (function) or NUL (empty term for some reason idk yet).
