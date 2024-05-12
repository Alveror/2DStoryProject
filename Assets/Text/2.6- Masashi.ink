INCLUDE globals.ink

{Masashi_state :
-0:
//Masashi is working in the restaurant.
How can I help you, sir?#speaker:masashi
Masashi, I assume?#speaker:Player
Yes... Who are you?#speaker:masashi
I am Ryker. I started as a housekeeper at Motel.#speaker:Player
Ah... Nice to meet you. #speaker:masashi
I have been told to see you about the card.#speaker:Player
Ah, you can give me the card.#speaker:masashi
~Masashi_state=1
-1: I am waiting for the card.#speaker:masashi
-2:->AfterCard

}

===AfterCard===
Do you need anything?#speaker:masashi
*{X>0}[Actually, I wanted to help Olivia with her check.]
Are you sure about it?#speaker:masashi
**[What is wrong with me helping her?]
She's up to no good. I think she is a fraud you know. Her newest role is the needy cute girl.#speaker:masashi
I can handle my own.#speaker:Player
Don't say I didn't warn you.#speaker:masashi
**[I am.]
--
~X=0
~Olivia_state=5
->AfterCard
*[What can you say about Motel?]
This is a good place. You know people who work here are awesome. The manager gives us a place that we can call home. It's been around 2 years since I started working here.#speaker:masashi
**[But, there is always a but...]
But I just feel like I stop dreaming about the career I could get. You know I always wanted to be a great chief, but when I come here it was a safe zone.#speaker:masashi
->AfterCard
**[Do you know anything about Jessica, a sculptor who lives in the motel?]
~JessicaMCounter++
Let me think... Jessica, no luck friend. I can remember most of the customers but I don't remember her.#speaker:masashi
***[Maybe she told you a different name]
If that's the case, I don't remember anyone's sentiment toward statues.#speaker:masashi
Ok.
->AfterCard
***[I understand]
->AfterCard
**[How nice for you.]
->AfterCard
*[I got to go.]
See you.#speaker:masashi
->END



