# Snitch_9000
Snitch 9000 is a tool used to detect the use of sites such as Chegg and CourseHero in student submissions.
It is designed to be used by instructors to help them identify students who may be using these sites to cheat on assignments.

## Project Management Board
    https://aerisan.atlassian.net/jira/software/projects/PK399/boards/1

## Team Members
    - @Aerisan
    - @nukkienuk
    - @tonylin53
    - @SaamRM
    - @Hoomanbeen

## Languages
    - C#
    - CSS
    - HTML
    - NodeJS

# Installation

## Requirements
    1. Clone the repository
    2. Install the npm requirements under the 'front end' directory using CLI
        npm install react-scripts --save
        npm install react-router-dom
        npm install react-widgets --save
        npm install axiom

     - Dotnet requirements are restored upon build

## Run the webpage

    1. Navigate to the '/front end' directory
    2. Run the app using CLI
        npm start

## Run the server

    1. Navigate to the '/Snitch_9000 Server' directory
    2. Build the project using CLI
        dotnet build
    3. Run the project from '/Snitch_9000 Server/bin/Debug/net6.0/snitch_9000.exe'

## Future Plan (Ideas for future releases)
    -Allow users to register for an account where they can manage/add/delete their questions and view corresponding hits.
    -Adopt for a wider range of contract cheating sites.
