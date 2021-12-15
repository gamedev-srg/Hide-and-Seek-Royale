# :collision: **Games Dynamic Components** :collision:

## 1. :gift: **Objects main properties**: 

* :speak_no_evil: **Traps**:

    > HNS traps are a variety of objects that can take hit points away from other competitors when they touch them. Each trap takes the amount of HP according to it's size and rarity. The relevant equation to check that is:
    
    > :chart_with_upwards_trend: Round(Rarity/Size)  -> This will maintain balance for each and every trap.


* :eyes: **Obstacles**:

    > The games obstacles are designed to be set on the field in order to make visibility harder in some areas and allow the runners to hide from the seeker. This mechanism will allow the game to be harder and harder according to the amount, size and complexity of each and every obstacle in the game. The relevant equation for obstacles is:

    > :chart_with_upwards_trend: Round(terrain_size/5)  -> From our tests we concluded that fifth of the terrain is a good ratio for hiding obstacles.

    > It's important to mention that obstacles are pre-set on the map for now and may be randomized in future versions.

* :saxophone: **Catching stick AKA Weapon** :
    > At a future update the games catching feature which now is conducted via a machine gun will be change to a more user friendly stick or tube that will catch the other player when bumping into them.

## 2. :maple_leaf: **Item locations**:

* Traps 

    > Traps are also on a fixed location at this version and are scattered across the map according to their rarity. 

    > The more rare the less of the specific trap kind you will be able to find. Because traps reduce HP from the runners and the players which is a main component of the game they need to be balanced so the strongest  traps will be the hardest to get.

    > In order to achieve balance we reduced the number of the strongest trap according to the equation until we reached a state that the rarest trap can be found only once in the whole map. 

* Obstacles:

    > As mentioned in the previous paragraph, obstacles will be fixed on the map abd a 1/5 ratio according to the terrain size.

    > This keeps a challenging game that enables runners to run and hide but still makes gaps so the player can see them running from time to time if he focuses. 

## 3. :jack_o_lantern: **Object behaviors**:

> The main behavior which is created in the game due to it's game objects and obstacles is the "Hiding Behavior".

> As described in the ["Biology of fear" article](https://www.ncbi.nlm.nih.gov/pmc/articles/PMC3595162/), when in fear, people sometimes tend to hide. This is exactly what happens to the runner in our game and even to the seeker! 

> Because of the basic fear mechanism in every human the player and runners will change their behaviors according to instincts and not logically. 

## 4. :money_with_wings: **Finance system**:

> HideNSeek game has no financial system.

## 5. :information_source: **Player game progress information**:

* **Information**:

    > The only information the player will gain on the game before and during playing is the runners number and the amount of runners that are left in the game.

    > Each time a runner is our of the game, there will be a pop-up message alerting all the other players that one of the players has exited. 

    > This is very important in order to keep the stress over the players during the game, people fear the unknown...
    This topic was mentioned in a lot of researches and media, here is a simple example from BBC:

    > [Why we're so terrified of the unknown?](https://www.bbc.com/worklife/article/20211022-why-were-so-terrified-of-the-unknown)

* **3rd Person View**:

    > As mentioned in many articles and in the Abstract of this one: [Effects of Third Person Perspective on Affective Appraisal and Engagement: Findings From SECOND LIFE](https://journals.sagepub.com/doi/10.1177/1046878110365515)

    > 3rd person view makes the player feel more connected to the game because he feels more involved, this works in correlation with all other game aspects we are developing.

    > The more involved the player will feel the impact of the action and curiosity much more heavily. This will make the player want to play more and more in search of this excitement. 


## 6. :passport_control: **Character control mechanism**:

In HNS the player has a direct and in-direct control over the course of the game. Both of which has a **real-time** impact over the course of the game.

* **Direct**

    > Players control the game directly by catching runners with their stick. This has a direct effect over the course of the game and other player because they can see that on of the players was eliminated and feel the danger.

* **In-Direct**

    > Players can in-directly control the game via the trap system. By laying traps on the floor the player can make other players lost not by directly engaging them but by in-directly showing them the way out. 

## 7. :mortar_board: **Choices and Strategy**:

* **Choices**:

    * **Direction**:

        > In HNS game the player's main choices are the direction of movement and object uses.

        > Every direction the player will choose has an impact over the course of the game. These things may vary from location to location.. In some places he will not be able to go back so easily and in others he may.

        > Each direction can get him in a direct clash with a runner or make him avoid one.

* :computer: **Game strategies**:

    * :sparkler: **Blitz**

        > The straight forward strategy. Meant for people with less patient.

        > This will end the game sooner for the better or worse.

        > The Blitz player will go straight into action and will try to catch the runners right away in order to end the game as quick as possible.

    * :hourglass: **Shadow**

        > The shadow player has a hidden approach. He mostly uses traps and lures the other players into them.

        > This game strategy makes the overall playtime longer and required a lot of patient. But for a lot of people this is the safe way to go. 

        > Shadow players plan and rethink each and every step in order to make is safer. 