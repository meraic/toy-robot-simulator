# README #

This repository implements the Toy Robot Simulator.

## Getting Started ##

### Dependencies ###
* You will need to install the following:
    * [.Net 5](https://dotnet.microsoft.com/download/dotnet/5.0)

### Toy Robot Commands ###
The following commands operate the robot on the table.
```robotframework
     place    Places the robot on the table at an x,y coordinate facing a compass direction of NORTH, SOUTH, EAST or WEST "place x y facing"
     move     Moves the robot 1 unit in the direction it's facing.
     left     Rotates the robot left to a new facing.
     right    Rotates the robot right to a new facing.
     report   Report on the robot's current position and facing.
     exit     Quits the simulator
```

### Examples ###

Running commands in interactive mode
```robotframework
    place 1,2,north
    move
    move
    left
    move
    report
```