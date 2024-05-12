INCLUDE globals.ink

~Manager_state=1
{Manager_state:
-0:
//Manager sits at his desk.

Hey Ryker. How is it going?#speaker:Manager
Okay I guess. #speaker:Player
Great. If you need any clarification don't hesitate to ask me.#speaker:Manager
~Manager_state=1

-1:->ManagerStandart
}


===ManagerStandart===
Yes?#speaker:Manager
*{R105>0}[About 105...]
->About105
*[I have some questions.]
Go on.#speaker:Manager
->ManagerQuestion
*[I should go.]
->END

===About105===
What about it?#speaker:Manager
*[Who lives in there?]
It is empty for a very long time.#speaker:Manager
    **{ISR105>0}[I saw some furniture there, should be good to clean up.]
    Don't mind. The room was rented for about the whole season.#speaker:Manager
    ***[Who rented it.]
    I won't tell you.#speaker:Manager
    ~MfirstO=true
    ->DONE
    ***[Understood.]
    ->DONE
*[Can I get in?]
If I wanted that place to be entered, I would give you the key. Don't ask me.#speaker:Manager
->About105
*[I need to talk about another thing]
->ManagerStandart
===ManagerQuestion===
*[How can I get in the rooms, if there is no master key?]
When you need to enter any room, I will provide the key and when you are done with the cleaning, you will give it back. Understood?#speaker:Manager
**[Yes.]
Great.#speaker:Manager
->ManagerQuestion
**[Why is this secrecy?]
This is our policy.#speaker:Manager
Ok.#speaker:Player
->ManagerQuestion
*{JessicaMCounter>3}[Do you know anyone called Jessica?]
Jessica... The name sounds familiar.#speaker:Manager
She is a sculptor. #speaker:Player
Ah... Yes, I remember. She was an old customer. She was great.#speaker:Manager
How long ago did she go?#speaker:Player
Well... I can't be sure but more than 5 months. I didn't see her since.#speaker:Manager
~MfirstO=true
**[Which room did she stay in?]
I don't remember.#speaker:Manager
**[Do you know where did she go?]
I don't know.#speaker:Manager
--Why the hell all of a sudden, you started asking about her?#speaker:Manager
**[I heard from others. I love sculpts.]
Yes, we all do. Unfortunately, you won't find her here. At least for now.#speaker:Manager
->ManagerStandart
**[Actually, never mind.]
->ManagerStandart
*[I need to talk about another thing]
->ManagerStandart