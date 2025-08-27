# Bound-Exodus-CLI-Procedural-Room-Generator
This repo presents the main procedural generation algorithm that Bound Exodus will utilize when creating exploration maps.



## The problem
The main issue is solving how to create both unique but traversible "rooms" within the top down exploration system of Bound Exodus that allows players to fight enemies, explore secrets, and collect resources. Each area should respectively provide a level of "randomness" while also having control variables to not create complete insanity.
There must be a few rules defined for this problem:
1. Generation should be run based on seeded randomness, allowing for replication if a seed is manually entered
2. At no point should "islands" exist, every room should have at the minimum one way to get in/out
3. Generation should have 2 layers, the external layer is responsible for generating map layout as a whole, the internal layer is responsible for generating the room contents individually. Map layout should only know about what room types are adjacent to one another, which will affect heuristics for what room types should be generated
4. At no point should an adjacent room ever be blocked off by terrain or objects, however enemies can be placed directly in front of paths
5. ...

(Constraints will likely grow as the project expands)
