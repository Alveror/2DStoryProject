INCLUDE globals.ink

{MrCP_state: 
-0:
Hey... HEY, YOU!#speaker:MrCP
Hey?#speaker:Player
Are you working here?#speaker:MrCP
No, I work at the motel.#speaker:Player
Motel huh... Do you know where the fuel guy is?#speaker:MrCP
No...#speaker:Player
You working here for a long time?#speaker:MrCP
Did started yesterday.#speaker:Player
Okay. Good luck.#speaker:MrCP
~talkedwithCP=1
~MrCP_state= 1
-1:->Whothefuckareyou

}

===Whothefuckareyou===
Yes?#speaker:MrCP
*[Who are you?]
    I am just passing by. I did want to buy gas.#speaker:MrCP
    ->Whothefuckareyou
*[Why are you looking for him]
I just wanted to buy something from the shop#speaker:MrCP
    ->Whothefuckareyou
*[I got to go]
Good Luck.#speaker:MrCP
->END