INCLUDE globals.ink

/* The Manager sits at his table. Player comes to him.*/

Hello?#speaker:Manager
//a momentarily pause.
How may I help you?#speaker:Manager

* I want to apply for the housekeeper job.
* I am looking for jes...
  nitor, I mean the housekeeper job.I want to apply for.#speaker:Player
-Oh. I see.Ha-hah I almost ready to tell you we don't have empty room left. Can I see your resume?#speaker:Manager
I don't have it.#speaker:Player
Well... Let's start from the beginning. What is your name?#speaker:Manager
Ryker.#speaker:Player
I am Robert, you can call me Mr. Beck. You are  a silent guy, aren't you?</color>#speaker:Manager
I... I am sorry. I just need the job. I can get the paperwork done by the week.</color> #speaker:Player
Hmm... Ryker, you said? Can I get your ID?#speaker:Manager
/* Player gives the ID(Could be interactive for tutorial purposes)

Robert checks on ID. */

Let me hold on to it meanwhile. We shouldn't have any problem with this way.,
*Of course. It won't be a problem. I will get you the papers.
*Just give it back!
    When I get the papers right.#speaker:Player

-Now, you can sleep in the room next door, you will find your equipment there. We have 10 rooms in total. Ah... Sorry, I did rush a little bit. Jabez can show you around in the morning. You can rest. #speaker:Manager
Thank you.#speaker:Player