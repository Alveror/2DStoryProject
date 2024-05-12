INCLUDE globals.ink

{Olivia_state:
-0:
//Olivia sits at one of the tables.

How can I help you?#speaker:olivia
I am working for the motel. #speaker:Player
Really? I live there but I have never seen you around.#speaker:olivia
I just started yesterday as a housekeeper.#speaker:Player
Ah... That's nice. I am Olivia from Room 103.#speaker:olivia
I am Ryker.#speaker:Player
Actually, can I ask something from you?#speaker:olivia
What is it?#speaker:Player
Ah, never mind.#speaker:olivia
~Olivia_state=4

-1:->Oliviastandart
-2:->OliviaQuestActive
-3:->OliviaGiveChance
-4:->Oliviabasic
-5:->OliviaAfterQuest

}
===OliviaAfterQuest===
Thank you! You are awesome#speaker:olivia.
Since you helped me, I want to help you. Do you have#speaker:olivia
~Olivia_state=1
~OQ=1
->Oliviastandart

===Oliviastandart===
Any question?#speaker:olivia
*[You don't know anything about Jessica?]
I heard she was at the motel and she was in Room 105.#speaker:olivia
~R105=0
~OfirstM=true
~JessicaMCounter++
**[How do you know?]
Well, she is popular. I heard her name. Probably, everyone did.#speaker:olivia
->Oliviastandart
**[How can I get into room 105.]
You need the key... or I can help you at night if you find me.#speaker:olivia
->Oliviastandart
*[Is Eleanor another alias for Jessica?]
No, she is a rich woman, who is looking to buy Jessica's works. But Jessica didn't want to sell. So, Eleanor tried to hire me. As you can see I have some skills on my sleeves.#speaker:olivia
**[Why did you mention her?]
As I said, she hired me, but I don't know if I want to work for her.#speaker:olivia
**[Could she know about Jessica?]
Perhaps... But I am sure she can give you something.#speaker:olivia
--Just find me at night. We can make something work for each other.#speaker:olivia
->Oliviastandart
*[I should go now.]
I will be around.#speaker:olivia
->END

===Oliviabasic===
Yes?#speaker:olivia
*[What do you need exactly?]
->Oliviaquest
*[Did you see a woman named Jessica,?]
Jessica... I didn't feel a spark.#speaker:olivia
She is an artist, and should be a resident of the motel.
Maybe you are asking for Eleanor?#speaker:olivia
A red-dressed beauty, she was in for art. You should find her in the bar at night.#speaker:olivia
Thanks.#speaker:Player
->END
*[I should go now.]
->END
===Oliviaquest===
I... How could  I say... I can't pay for my meal. If you could pay for it, I would appreciate it.#speaker:olivia
*[Of course. No problem.]
You are a savior. You can talk to Masashi about it.#speaker:olivia
~X=1
~Olivia_state=2
->END
*[No. I can't.]
Oh... I hope you change your mind.#speaker:olivia
~Olivia_state=3
->END

===OliviaQuestActive===
I'll be waiting for you to pay for it.#speaker:olivia
->END

===OliviaGiveChance===
Did you change your mind?#speaker:olivia
*[Yes.]
Good. You can talk to Masashi.#speaker:olivia
~X=1
->OliviaQuestActive
*[No.]
I will be still hoping for it.#speaker:olivia
->END
