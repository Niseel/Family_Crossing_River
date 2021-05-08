% start([3,2,0,0,0]).

goal([0,0,3,2,1]).

% danger([A,B,C,D,E]) :- .
% A - Adult Left 
% B - Children Left
% C - Adult Right
% D - Children Right
% E - Boat side (0-1  left-right)

adult_left_right([A,B,C,D,0], [X,Y,Z,T,1]) :- 
  A > 0, X is A - 1, 
  Y is B, 
  Z is C + 1, 
  T is D.

adult_right_left([A,B,C,D,1], [X,Y,Z,T,0]) :- 
  C > 0, X is A + 1, 
  Y is B, 
  Z is C - 1, 
  T is D.

kid_left_right([A,B,C,D,0], [X,Y,Z,T,1]) :- 
  X is A, 
  B > 0, Y is B - 1,  
  Z is C, 
  T is D + 1.


kid_right_left([A,B,C,D,1], [X,Y,Z,T,0]) :- 
  X is A, 
  D > 0, Y is B + 1,
  Z is C, 
  T is D - 1.

children_left_right([A,B,C,D,0], [X,Y,Z,T,1]) :- 
  X is A, 
  B > 1, Y is B - 2,
  Z is C, 
  T is D + 2.

children_right_left([A,B,C,D,1], [X,Y,Z,T,0]) :- 
  X is A, 
  D > 1, Y is B + 2,
  Z is C, 
  T is D - 2.

generateState(N, X) :- adult_left_right(N, X).
generateState(N, X) :- adult_right_left(N, X).
generateState(N, X) :- kid_left_right(N, X).
generateState(N, X) :- kid_right_left(N, X).
generateState(N, X) :- children_left_right(N, X).
generateState(N, X) :- children_right_left(N, X).

problem(X,P,[X|P]):-goal(X),!.
problem(X,P,L):-generateState(X,Y),X\=Y,\+member(Y,P),problem(Y,[X|P],L).

q(R) :- problem([3,2,0,0,0], [], R).

% test 
% adult_left_right([3,2,0,0,0])

% p(R) :- cross([2,2,1,0,0,0,0], [], R).
% start([2,2,1,0,0,0,0]). 