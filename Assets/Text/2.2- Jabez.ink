INCLUDE globals.ink

{Jabez_state :
-1: ->Jabezdefo
-2: ->JabezRoom105After
}

===Jabezdefo===
Need anything?#speaker:jabez
*[I have some questions.]
->JabezStandart
*[I should go.]
I am here if you need me.#speaker:jabez
->END


->JabezRoom105After


===JabezStandart===

*[What can you say about others? Why did they leave?]
    Everyone had their reasons. Some didn't like the payments, some just couldn't handle them. There was always another to fill the one's place. This motel can be tough sometimes. So many people, so many mistakes.#speaker:jabez
    ->JabezStandart
*[Did you see a sculptor woman?]
    A sculptor? What do you mean?#speaker:jabez
    A woman, who is a sculptor. She is tall and beautiful. #speaker:Player
    Why... I mean... No... Nah, I didn't.#speaker:jabez
    ~JessicaMCounter++
    ->JabezStandart
    I am here if you need me.#speaker:jabez
~Jabez_state= 1
->END

===JabezRoom105After===
What do you need ?#speaker:jabez
*[Did you see who lives in 105?]
 Which one was that? Ah. The last one. Nah, man. Nah. I didn't see anyone around it.#speaker:jabez
 Are you sure?#speaker:Player
 Yes... I mean, you should talk to the boss about it.#speaker:jabez
->JabezRoom105After
*[How can I get inside any room?]
Which one exactly?#speaker:jabez
Room 105. #speaker:Player
Then you shouldn't without asking the boss.#speaker:jabez
I didn't ask if I should or not, I asked How?#speaker:Player
Chill man... The Boss has all the keys. He holds them in his room. You can ask him... I should say, It has been a long time since that room had a guest.#speaker:jabez
So, I can get it from his room.#speaker:Player

-Please don't put the target sign on me...#speaker:jabez
*[Why are you scared of him?]
    I am not, but I have an agreement with the Boss. I wouldn't screw him even if I want.#speaker:jabez
    What agreement?#speaker:Player
    I can't talk about it. Just know that Boss is not the one pulling the strings.#speaker:jabez
    I will hold you outside it, for now...#speaker:Player
*[Okay.]

-Thanks. I'll be around.#speaker:jabez
~Jabez_state= 1
->END


