# Prototype_3
reupload of prototype3

this prototype was to experiment with a lot of technical aspects that I hadn't in my previous prototypes.

those include animations, animation events, & basic combat.

controls : A W D M

W: puts player on guard

M: attacks (only when player is on guard)

the goal of the game is to attack the enemy at the exact same time they are attacking the player. this causes a "parry" where the enemy drops their guard allowing the player to get a hit in. sometimes with perfect timing the player can get 2 hits as the parry can daamge the enemy depending on its timing. while their guard is up. the player does not take hp dmg (3 hit points for death) they instead take stamina damage (5 hit points) after which they are forced out of guard and have to retreat and wait for their stamina to come back. in hard mode the enemy has 10 hit points. in easy mode they only have 5.
however in hard mode the enemy starts attacking a bit later allowing the player opportunities to get 2-3 hits in. in easy mode the most hits the player can get before the enemy activates is 1.

problem : the enemy attacks randomly and the player's parry window is very small making reactionarily timing the parry almost impossible ( 1 tenth of a second)

I have built 2 different versions of the game. one where the enemy continues attacking randomly and the other where they attack at a set interval. the 2nd of those I have dubbed "easy mode".

Main Design question ? Do games need an easy mode ? was hard mode too hard ?

does the mechanic provide engagement ? I.e. does it geel like real combat ?

would you play a kind of game where combat is slow and methodical like this (without the typical jumping around and flashy abilities we are used to) ?

2/5 players chose to start with the real mode rather than the easy mode.
3/5 players said that games do need an easy mode 5/5 players said hard mode was too hard. 
4/5 players said the mechanic provided engagement because it wasn't mindless.
4/5 said that this kind of combat can provide a similar level of satisfaction to the more flashy action combat no real recommendations for improvement (other than fix one recurring bug) some people would like to play more levels with more enemies with different timing.
PS. If you wanna try easy mode, disable the randomizer on the Invoke("AttackInitiator") in the enemy behaviour script. also adjust enemy value from inspector.

