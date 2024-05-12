INCLUDE globals.ink

{Valente_state:
-0:
//Valente plays guitar at the bar.
Yo, Bro!#speaker:valente
Hey.#speaker:Player
Name is Valente.#speaker:valente
Ryker.#speaker:Player
Do you play guitar?#speaker:valente
No. #speaker:Player
I am somewhat popular around here. Girls do love musicians, you should learn one or two tricks.#speaker:valente
I'll think about it.#speaker:Player
~Valente_state=1

-1:->ValenteisBasic
-2:->ValenteNeedsPaper
-3:->ValentesPencil
-4:->Ireallyneedthatpaper
-5:->Somealonetime
}

===ValenteisBasic===
*[You live in the motel?]
Yes, Bro. You?#speaker:valente
I am the new worker.#speaker:Player
Coool.#speaker:valente
->ValenteisBasic
*[You seem into girls.]
Yes, did you see Eleanor? She is hot. I MEAN HOT HOT...#speaker:valente
You know Jessica. #speaker:Player
Nah, Bro. Who is she? If you miss your chance...#speaker:valente
Shut up...#speaker:Player
Chill...#speaker:valente
~JessicaMCounter++
->ValenteisBasic
*[I should go.]
--Actually. Since you are a worker. #speaker:valente
Yes?#speaker:Player
I need something so important. #speaker:valente
What is it?#speaker:Player
It is crucial. #speaker:valente
...#speaker:Player
Can you get me a paper to write something on it?#speaker:valente
**[I will look around.]
THAT'S DOPE!#speaker:valente
~Valente_state=2
->END
**[No, go find someone for your footwork.]
Since it is a grand thing, I'll be waiting for you to change your mind.#speaker:valente
~Valente_state=4
->END

===ValenteNeedsPaper===
Yoo, did you find the paper?#speaker:valente
->END
===Ireallyneedthatpaper===
BRO, THAT'S BIG, I NEED THE PAPERS. NOW.#speaker:valente
*[Ok, I will get it]
Jeez. Thanks!#speaker:valente
~Valente_state=2
->END
*[I don't think so.]
Shit...#speaker:valente
->END
===ValentesPencil===
The pencil man. We need a pencil.#speaker:valente
->END

===Somealonetime===
I need some alone time.#speaker:valente
->END