# DP4GDV, Assignment: Design Patterns
By: Lucas Hoogerbrugge

## The assignment
Select a gameplay system you would like to prototype, and select (min 3, max 5, singleton's excluded) design patterns that fit this particular gameplay system. Motivate your choice of design patterns in relation to the gameplay system's design challenges. Develop a functional code structure to showcase how the implemented design patterns will operate to enable the gameplay system.
Examples of Patterns you might select: Command, Observer, Prototype, State, Subclass Sandbox, Component, Event Queue, Service Locator, Object Pool, (Abstract) Factory, Finite State Machine, Decorator.
NOTE: The gameplay system itself does not need to be functional. For example: if you create a complex weapon generation system, the actual "weapons" do not need to be functional (can be simplified to a simple action, such as generating random values or debug logging), but the code structure that supports this feature should work (convincingly). Seek to build the functionality only insofar as it is necessary to design the implementation. 

## The requirements under my understanding
-	Choose a gameplay system
-	In documentation show examples and write out that system
-	Choose 3 design patterns (singleton excluded) that fit this gameplay system
-	Inside the documentation, argument why I choose them
-	Make a UML for my system
-	Do not add extra functionality besides what’s needed to finish the system
-	Make the gameplay system to your understanding
-	Uphold defined coding conventions (define coding conventions)
-	Deliver a pdf with documentation + a link to the github

## Deliverables
•	Github link to view final code structure
o	in case the repository is private, ensure all teachers are added as collaborators
•	Explanation of the selected gameplay system (with example references if they exist)
•	Motivation of the choice of design patterns
•	UML Class Diagram of implemented gameplay system (focussing on integration of design patterns)
 
## Chosen gameplay system
Gun system + inventory. Taking inspiration from: Doom, Quake, and Dusk.
Meaning: A system where the player is able to hold different guns depending on the numeric key buttons. 
Reuseable gun parts, such as shooting through a raycast, and shooting a entity.
Quake for example has a shotgun doing x damage, and takes x amount of ammo. But it also has a double barrel shotgun (or super shotgun) that deals more damage but takes more ammo.
However next to this, Quake also has a minigun like needle gun, that shoots projectile needles in rapid succession.
(Guns also shouldn’t be able to be switched to by the player, if the player hasn’t unlocked them yet.)
![image](https://github.com/user-attachments/assets/1badcc6a-a851-4516-a383-594e46680ba5)
![image](https://github.com/user-attachments/assets/d6819fc0-6bff-4b73-b748-50d348eadfe5)
![image](https://github.com/user-attachments/assets/03f3d86a-b232-4739-b99e-58a8f3e08f80)
 
## My chosen design patterns
1 Object pool
Each projectile type would have their own object pool, this would make the performance better since we don’t re create new objects constantly
2 Strategy
In the design pattern strategy, you have a class that’s considered the context, and different strategy classes. The context class then has one strategy class that it calls specific functions from defined in a base strategy interface.
This fits my gun situation perfectly, since each gun is able to shoot, yet they’d all do something different. So, a different strategy held by a gun class.
3 Builder
Each gun inside the game has different parameters and different things it shoots. Instead of having to define it as a separate class each time. I’m going to use a builder pattern that makes the gun instead. This way I avoid having to define specific classes for every gun. And easily lets me create new guns later

## Unified Modelling Language, Class diagram
![image](https://github.com/user-attachments/assets/c5e7c677-a8ae-4994-860a-f86048afd646)

## Coding conventions
Rules:
- Functions – should be short enough that they fit on your screen.
- Functions – should have a single purpose
- Functions/classes – Will be PascalCased, no matter what
- Interfaces – Are prefixed with a “I” and are PascalCased
- Variables – Should be private when they’re not being accessed anywhere else
- Variables – Are camalCased
- Variables – Are prefixed with a “_” if its serialized (visible) to the Unity inspector
