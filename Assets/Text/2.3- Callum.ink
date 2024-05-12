INCLUDE globals.ink

{Calum_state: 
-0:
//Calum wanders around.
Hey Uncle Ryker!#speaker:calum
Hey Kid, What's your name?#speaker:Player
Calum but my mom called me Cal.#speaker:calum

~Calum_state = 1
-1:->CalumFirstInter
}
===CalumFirstInter===
Calum?#speaker:Player
Yes, Uncle Ryker.#speaker:calum
*[Where is your mother?]
->CalumFamily
*[Did you see a sculptor woman around here]
->Calumthewoman
*[I need to go.]
->END

===CalumFamily===
Mom passed away. He left me with my father.#speaker:calum
*[Where is your father?]
    He is in our room. He doesn't want to play with me. But he promised. He didn't keep it. Where is your father?#speaker:calum
    No, he passed a long time ago. Sometimes it is best to put your losses beside.#speaker:Player
    Yes... but my father can't.#speaker:calum
    ->CalumFamily
*[What are you doing here?]
    My father told me, we would go on an adventure. Like my mother promised. But... But they never keep their promises. All we did is coming to this motel. Why did you come here?#speaker:calum
    I am looking for my adventure. #speaker:Player
    ->CalumFamily
*[Sorry for your loss. I want to ask you something different.]
->CalumFirstInter

===Calumthewoman===

What is a sculptor?#speaker:calum
 Well. The sculptor is the one who makes statues.#speaker:Player
 Like the statue of liberty?#speaker:calum
 Yes. Like that. What I looking for is not making statues those big.#speaker:Player
 My father told me about a woman, but we couldn't meet her yet. #speaker:calum
 ~JessicaMCounter++
 *[Do you know anything about her?]
    She makes art and save lives and they say she is beautiful.#speaker:calum
    **[Who says that?]
        Everybody around here. Didn't you hear?#speaker:calum
        No, but thanks.#speaker:Player
        ->Calumthewoman
    **[I should be going.]
    ->END
 *[Better to talk with your father then.]
 ->END